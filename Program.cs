// Benjamin Johnson, 2/25, Lab-3
using System.Net;

Console.Clear();

// Greeting - Step #2
Console.WriteLine(@"
----------------------------------------------------------------------
|                             Mastermind                             |
| Welcome to the game of mastermind! I have chosen 4 letters between |
|    'a' and 'g' and have arranged them in a particular order.       |
|  Your job is to guess the letters and put them in the right order. |
----------------------------------------------------------------------");

// Creating the secret word - Step #3
string secret = "";
Random rand = new Random();

for (int i = 0; i < 4; i++)
{
    char temp = (char) rand.Next(97,104);
    while(true)
    {
        if (secret.Contains(temp))
            temp = (char) rand.Next(97,104);
        else
        {
            secret += temp;
            break;
        }
    }  
}
Console.WriteLine($"              Secret word: {secret} (needed for debugging)"); // Written for debugging

// Prompting the User to guess the word - Step #3
int guessNumber = 0; // Step #4

do 
{
    guessNumber++;
    Console.WriteLine($"Guess #{guessNumber}: Please guess a sequence of 4 lowercase letters with no repeats.");
    string? guess = Console.ReadLine();
    if (secret[0] == guess[0] && secret[1] == guess[1] && secret[2] == guess[2] && secret[3] == guess[3])
    {   
        break;
    }
    // Checking letter positions - Step #5 and Step #6
    else 
    {
        int correctPositions = 0; // Resetting correct Positions
        int incorrectPostiions = 0; // Resetting incorrect Positions
        for (int i = 0; i < secret.Length; i++)
        {
            if (secret[i] == guess[i]) // Step #5
            {
                correctPositions++;
            }
            if (secret.Contains(guess[i]) && secret[i] != guess[i]) // Step #6
            {
                incorrectPostiions++;
            }
        }
        Console.WriteLine($"    -{correctPositions} letters in the correct positions\n    -{incorrectPostiions} letters in the incorrect positions");
    }
}
while (true);

Console.Write("Congratulations, you've won");