class Program
{
    static string CanSumToLargest(int[] numbers)
    {
        if (numbers.Length < 2)
            return "Array must contain at least two elements.";

        // Find the largest number
        int largestNumber = numbers.Max();

        // Remove the largest number from the array

        int[] others = numbers.Where(x => x != largestNumber).ToArray();


        // Create a HashSet to store possible sums
        HashSet<int> possibleSums = new HashSet<int>();

        // Generate all possible sums
        GenerateSums(0, 0);

        // Check if the largest number is in the set of possible sums
        return possibleSums.Contains(largestNumber) ? "Possible" : "Not possible";

        // Local function to generate all possible sums
        void GenerateSums(int index, int currentSum)
        {
            if (index == numbers.Length)
            {
                possibleSums.Add(currentSum);
                return;
            }

            // Include the current number in the sum
            GenerateSums(index + 1, currentSum + numbers[index]);

            // Exclude the current number from the sum
            GenerateSums(index + 1, currentSum);
        }
    }

    static void Main(string[] args)
    {
        int[] inputArray = new int[] { 5, 7, 10, 14, 12, 8, 2, 3 };
        string result = CanSumToLargest(inputArray);
        Console.WriteLine(result);
    }
}
