/*
* Determine which games would have been possible if the bag had been loaded with only 12 red cubes, 13 green cubes, and 14 blue cubes. What is the sum of the IDs of those games?
*/

//Read input vector<structs>
//Check total number of reds against allowed reds etc....

using System.Text.RegularExpressions;

struct Game{
    public int GameNumber;
    public int MaxRedCount = 0;
    public int MaxGreenCount = 0;
    public int MaxBlueCount = 0;

    public Game(int gameNum)
    {
        GameNumber = gameNum;
    }
}

class Program1
{
    static void Main()
    {
        int totalRed = 12;
        int totalGreen = 13;
        int totalBlue = 14;

        int runningTotal = 0;

        LinkedList<Game> gameInfo = getGameInfoFromFile("Input.txt");
        foreach (var game in gameInfo)
        {
            if(isGamePossible(totalRed, totalGreen, totalBlue, game))
            {
                runningTotal += game.GameNumber;
            }
        }

        Console.WriteLine(runningTotal);
    }

    static bool isGamePossible(int totalRed, int totalGreen, int totalBlue, Game game)
    {
        return game.MaxRedCount <= totalRed && game.MaxGreenCount <= totalGreen && game.MaxBlueCount <= totalBlue;
    }

    static LinkedList<Game> getGameInfoFromFile(string fileName)
    {
        LinkedList<string> inputLines = getInputLines(fileName);
        LinkedList<Game> gameInfo = new LinkedList<Game>();

        //Can we just grab the max occurrence of each colour and discard the rest?
        foreach (var line in inputLines)
        {
            gameInfo.AddLast(constructGameFromLine(line));
        }

        return gameInfo;
    }

    static Game constructGameFromLine(string inputLine)
    {
        string[] splitAtColon = inputLine.Split(":");
        int gameNumber = int.Parse(splitAtColon[0].Split(" ")[1]);
        Game game = new Game(gameNumber);

        string[] drawFromHat = splitAtColon[1].Split(";");
        foreach (string draw in drawFromHat)
        {
            foreach (string stoneInfo in draw.Split(","))
            {
                string[] split = stoneInfo.Trim().Split(" "); //Trim to remove leading spaces after commas
                int number = int.Parse(split[0]);
                string colour = split[1];

                switch(colour)
                {
                    case "red":
                    game.MaxRedCount = Math.Max(number, game.MaxRedCount);
                    break;

                    case "blue":
                    game.MaxBlueCount = Math.Max(number, game.MaxBlueCount);
                    break;

                    case "green":
                    game.MaxGreenCount = Math.Max(number, game.MaxGreenCount);
                    break;
                }
            }
        }

        return game;
    }

    static LinkedList<string> getInputLines(string fileName)
    {
        var line = "";
        LinkedList<string> inputs = new LinkedList<string>();

        StreamReader reader = new StreamReader(fileName);

        if (reader != null)
        {
            while ((line = reader.ReadLine()) != null)
            {
                inputs.AddLast(line);
            }
            reader.Close();
        }
        return inputs;
    }
}