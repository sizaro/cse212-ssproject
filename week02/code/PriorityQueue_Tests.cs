using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add one item, then dequeue it.
    // Expected Result: The item is dequeued correctly.
    // Defect(s) Found: None
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Item1", 1);  // Enqueue an item with priority 1
        
        var dequeuedValue = priorityQueue.Dequeue();  // Dequeue the item
        
        Assert.AreEqual("Item1", dequeuedValue, "Dequeue did not return the expected value.");
    }

    [TestMethod]
    // Scenario: Add multiple items with different priorities, then dequeue.
    // Expected Result: The item with the highest priority is dequeued.
    // Defect(s) Found: None
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Item1", 1);  // Lower priority
        priorityQueue.Enqueue("Item2", 3);  // Higher priority
        priorityQueue.Enqueue("Item3", 2);  // Medium priority
        
        var dequeuedValue = priorityQueue.Dequeue();  // Dequeue should return "Item2"
        
        Assert.AreEqual("Item2", dequeuedValue, "Dequeue did not return the item with the highest priority.");
    }

    [TestMethod]
    // Scenario: Add multiple items with the same priority, then dequeue.
    // Expected Result: FIFO behavior should be followed, and the first item added should be dequeued.
    // Defect(s) Found: None
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Item1", 2);  // Priority 2
        priorityQueue.Enqueue("Item2", 2);  // Priority 2
        priorityQueue.Enqueue("Item3", 2);  // Priority 2
        
        var dequeuedValue = priorityQueue.Dequeue();  // Dequeue should return "Item1" (FIFO)
        
        Assert.AreEqual("Item1", dequeuedValue, "Dequeue did not return the first item added with the same priority.");
    }

    [TestMethod]
    // Scenario: Attempt to dequeue from an empty queue.
    // Expected Result: An InvalidOperationException should be thrown.
    // Defect(s) Found: None
    public void TestPriorityQueue_4()
    {
        var priorityQueue = new PriorityQueue();
        
        // Expecting an InvalidOperationException because the queue is empty
        Assert.ThrowsException<InvalidOperationException>(() => priorityQueue.Dequeue(), "Dequeue should throw an exception when the queue is empty.");
    }

    [TestMethod]
    // Scenario: Add multiple items with the same highest priority, then dequeue.
    // Expected Result: FIFO behavior should be followed, and the first item added should be dequeued.
    // Defect(s) Found: None
    public void TestPriorityQueue_5()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Item1", 5);  // Highest priority
        priorityQueue.Enqueue("Item2", 5);  // Highest priority
        priorityQueue.Enqueue("Item3", 5);  // Highest priority
        
        var dequeuedValue = priorityQueue.Dequeue();  // Dequeue should return "Item1"
        
        Assert.AreEqual("Item1", dequeuedValue, "Dequeue did not return the first item added with the same highest priority.");
    }
}
