namespace mission2_assignment_dice_roll;

public class Dice
{
    // Gathers the roll results from 2 simulated dice and returns them in an array
    public static int[] RollResults(int numRolls)
    {   
        // 11 spots for the 11 possible rolls with 2 dice
        int[] results = new int[11];
        
        // Generate a roll for the designated number of rolls
        for (int i = 0; i < numRolls; i++)
        {
            // Add together the 2 dice to get the sum of the rolls. Subtract 2 to place in the correct index.
            int rollNumIndex = SingleDieRoll() + SingleDieRoll() - 2;
            // Add one to this sum index to show that this number was rolled once.
            results[rollNumIndex] += 1;
        }
        
        return results;
    }
    
    // Create a Random class to use to get the random number.
    private static Random _random = new Random();

    private static int SingleDieRoll()
    {
        // Call the method within this class.
        return _random.Next(1, 7);
    }
    
}