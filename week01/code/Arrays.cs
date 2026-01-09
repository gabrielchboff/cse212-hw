public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // Thinking process: The function should create and return an array of multiples of a number. 
        //The starting number and the number of multiples are provided as inputs to the function. 
        //For example, MultiplesOf(3,5), where the 3 is the starting number and 5 is the number of multiples, 
        //would result in <double>{3, 6, 9, 12, 15}. 
        // The lenght proposes the end of the array
        // The number is the starting number of the array
        // the number that is a multiple of a number is the rest of divivion = 0;
        
        // Using LINQ concept providing method for working with sequences of data to
        // create, transform, and query collections.
        return Enumerable
                .Range(1, length) // It produces the range we need, being the length the end
                .Select(i => number * i) // Applies to selected number the multiplicity
                .ToArray(); // It transforms the range into an array
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.
        //Come up with a plan on how to implement the RotateListRight function. This function receives a list of data and an amount to rotate to the right.
        // 
        // For example, if the data is <List>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 5
        // then the list after the function runs should be <List>{5, 6, 7, 8, 9, 1, 2, 3, 4}.
        // If the data is <List>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list
        // after the function runs should be <List>{7, 8, 9, 1, 2, 3, 4, 5, 6}. The value of
        // amount will be in the range of 1 and data.Count, inclusive.
        // The function gets the center to the end and puts the end into the start
        // What is the middle off this list? The integer division of the lenght
        
        // Normalize rotation amount
        amount %= data.Count;
        if (amount == 0)
            return;
        
        // Local reverse logic
        void Reverse(int start, int end)
        {
            while (start < end)
            {
                (data[start], data[end]) = (data[end], data[start]);
                start++;
                end--;
            }
        }

        // Step 1: Reverse entire list
        Reverse(0, data.Count - 1);

        // Step 2: Reverse first 'amount' elements
        Reverse(0, amount - 1);

        // Step 3: Reverse the remaining elements
        Reverse(amount, data.Count - 1);
        
    }
}
