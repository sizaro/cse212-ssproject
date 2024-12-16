using System.Collections.Generic;

public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  
    /// For example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  
    /// Assume that length is a positive integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // Step 1: Create an array to store the multiples, with the size equal to 'length'
        double[] multiples = new double[length];
        
        // Step 2: Use a loop to fill the array with multiples of 'number'
        for (int i = 0; i < length; i++)
        {
            // Each multiple is simply 'number' * (i + 1)
            multiples[i] = number * (i + 1);
        }
        
        // Step 3: Return the filled array of multiples
        return multiples;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  
    /// For example, if the data is List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and the amount is 3, 
    /// the list after the function runs should be List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.
    /// </summary>
    /// <param name="data">The list of integers to rotate</param>
    /// <param name="amount">The number of positions to rotate to the right</param>
    public static void RotateListRight(List<int> data, int amount)
    {
        //Use modulo to get the effective amount of rotation needed.
        //This handles cases where amount is larger than the list size.
        amount = amount % data.Count;
        
        //If the amount is 0, no rotation is needed, so we can return early.
        if (amount == 0) return;
        
        //Use GetRange to get the last 'amount' elements (the rotated part).
        List<int> rotatedPart = data.GetRange(data.Count - amount, amount);
        
        //Use GetRange to get the remaining elements before the rotated part.
        List<int> remainingPart = data.GetRange(0, data.Count - amount);

        //Clear the original list and then add the two parts in rotated order.
        data.Clear();
        data.AddRange(rotatedPart); // Add the last 'amount' elements first
        data.AddRange(remainingPart); // Then add the remaining elements after

        // Result: data list is now rotated to the right by 'amount' positions
    }
}
