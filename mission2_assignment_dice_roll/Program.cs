// Jacob Thomas
// IS 413 Section 2

// Mission 2 Assignment: Dice Roll
// Description: Simulates rolling 2 dice the number of rolls the user specifies

namespace mission2_assignment_dice_roll;

class Program
{

    public static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the dice throwing simulator!");
        
        // Putting game inside a do while loop to play multiple times
        string keepPlaying;
        do
        {
            // Play the game
            playGame();
            
            // Prompt user if they would like to play again
            Console.Write("\nPress \"y\" to play again, or any other key to exit. ");
            keepPlaying = Console.ReadLine();
            
        } while (keepPlaying.ToUpper() == "Y");
        
        Console.WriteLine("\nThank you for using the dice throwing simulator. Goodbye!");
    }

    private static void playGame()
    {
        // Prompt User to enter number of dice to roll
        Console.Write("\nHow many dice rolls would you like to simulate? ");
        int numRolls;
        // Error handling so that it won't break when a using puts in a non int.
        try
        {
            numRolls = int.Parse(Console.ReadLine());
        }
        catch (Exception e)
        {
            Console.WriteLine("\nOpps! You didn't enter a whole number. Please only input a whole number as the number of rolls.");
            return;
        }

        // Get roll results from the Dice class. Pass in the number of rolls determined by the user.
        int[] results = Dice.RollResults(numRolls);
        
        // Display some text for the user
        Console.WriteLine("\nDICE ROLLING SIMULATOR RESULTS");
        Console.WriteLine("Each \"*\" represents 1% of the total number of rolls.");
        Console.WriteLine($"Total number of rolls: {numRolls}\n");
        
        // Loop through results. Index is the sum result and value is the number of times it was rolled.
        for (int i = 0; i < results.Length; i++)
        {
            // Calculate the percent of total rolls of the count of this sum.
            double percent = (double)results[i] / numRolls * 100;
            // Round to the nearest whole number
            percent = Math.Round(percent);
            
            // Add 2 to the index to get the actual sum of dice.
            int dieFaceValue = i + 2;
            
            // Log the histogram bar.
            Console.WriteLine((dieFaceValue + ": ").PadRight(5) + histBar(percent).PadRight(35) + (percent + "%").PadRight(8) + results[i] + " Rolls");
        }
    }

    // Creates a histogram bar string of *. 1 for each percent passed in.
    private static string histBar(double percent)
    {
        string bar = "";
        // Loop through as many times as the percent.
        for (int j = 1; j < percent; j++)
        {
            //Add a * to the string
            bar += "*";
        }
        return bar;
    }
}