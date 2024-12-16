/// <summary>
/// This queue is circular.  When people are added via AddPerson, then they are added to the 
/// back of the queue (per FIFO rules).  When GetNextPerson is called, the next person
/// in the queue is saved to be returned and then they are placed back into the back of the queue.  Thus,
/// each person stays in the queue and is given turns.  When a person is added to the queue, 
/// a turns parameter is provided to identify how many turns they will be given.  If the turns is 0 or
/// less than they will stay in the queue forever.  If a person is out of turns then they will 
/// not be added back into the queue.
/// </summary>
public class TakingTurnsQueue
{
    private readonly Queue<Person> _people = new Queue<Person>();

    public int Length => _people.Count;

    /// <summary>
    /// Add a person to the queue with a name and number of turns. If turns <= 0, they have infinite turns.
    /// </summary>
    public void AddPerson(string name, int turns)
    {
        var person = new Person(name, turns);
        _people.Enqueue(person);
    }

    /// <summary>
    /// Dequeues the next person in line. If they have turns left or infinite turns, re-add them to the queue.
    /// Throws an InvalidOperationException if the queue is empty.
    /// </summary>
    public Person GetNextPerson()
    {
        if (_people.Count == 0)
        {
            throw new InvalidOperationException("No one in the queue.");
        }

        // Dequeue the next person in line
        Person person = _people.Dequeue();

        // If person has finite turns left
        if (person.Turns > 1)
        {
            // Decrement the turns, and re-enqueue them if they still have turns
            person.Turns -= 1;
            _people.Enqueue(person);
        }
        // If person has infinite turns, re-enqueue them without decrementing
        else if (person.Turns <= 0)
        {
            _people.Enqueue(person);
        }

        return person;
    }

    public override string ToString()
    {
        return string.Join(", ", _people.Select(p => p.Name));
    }
}
