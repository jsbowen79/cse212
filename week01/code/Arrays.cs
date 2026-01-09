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
        
        /*Plan: 
        1) Create a new array to hold the numbers.
        2) Use a for loop with a variable (i) as an iterator starting at 0. 
        3) End the for loop when the iterator variable is equal to the length parameter of the function. 
        4) Multiply the number parameter by successive integers starting at 1 for each iteration of the loop.
           This can be done by adding 1 to the iterator variable.
        5) Add the above product to the new array at the index equal to the iterator variable.
        6) Once the for loop has completed, return the new array.   */
        
        double[] multiplesArray = new double[length];

        for (int i = 0; i < length; i++)
        {
            multiplesArray[i] = number * (i + 1);
        }
       
        return multiplesArray; 
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
    
        /*
        Plan: 
        1) Use a for loop with a variable (i) as an iterator starting at 0. 
        2)End the loop when the iterator is equal to the amount parameter. 
        3)For each iteration of the loop, copy the number copy the number at the end of the list to a new variable. 
        4)Insert the new variable into the list at the beginning. 
        5)Remove the number from the end of the list.
        */

        for (int i=0; i <amount; i++)
        {
            int target = data[^1]; 
            data.Insert(0, target);
            data.RemoveAt(data.Count-1); 
        }
    }
}
