/*
* Determine which games would have been possible if the bag had been loaded with only 12 red cubes, 13 green cubes, and 14 blue cubes. What is the sum of the IDs of those games?
*/


struct Game{
    public int GameNumber;
    public int MaxRedCount = 0;
    public int MaxGreenCount = 0;
    public int MaxBlueCount = 0;

    public Game(int gameNum)
    {
        GameNumber = gameNum;
    }

    public int getProductOfMax(){
        return MaxRedCount * MaxBlueCount * MaxGreenCount;
    }
}

class Program1
{
    static void Main()
    {
        int sumOfSquares = 0;

        LinkedList<Game> gameInfo = GetGameInfoFromFile("Input.txt");
        foreach (var game in gameInfo)
        {
            int sumOfMax = game.getProductOfMax();
            Console.WriteLine("Game {0}, Sum of max: {1}", game.GameNumber, sumOfMax);
            sumOfSquares += sumOfMax;
        }

        Console.WriteLine("Sum of squares: {0}", sumOfSquares);
    }

    static LinkedList<Game> GetGameInfoFromFile(string fileName)
    {
        LinkedList<string> inputLines = GetInputLines(fileName);
        LinkedList<Game> gameInfo = new();

        //Can we just grab the max occurrence of each colour and discard the rest?
        foreach (var line in inputLines)
        {
            gameInfo.AddLast(ConstructGameFromLine(line));
        }

        return gameInfo;
    }

    static Game ConstructGameFromLine(string inputLine)
    {
        string[] splitAtColon = inputLine.Split(":");
        int gameNumber = int.Parse(splitAtColon[0].Split(" ")[1]);
        Game game = new(gameNumber);

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

    static LinkedList<string> GetInputLines(string fileName)
    {
        LinkedList<string> inputs = new();

        StreamReader reader = new(fileName);

        if (reader != null)
        {
            string? line;
            while ((line = reader.ReadLine()) != null)
            {
                inputs.AddLast(line);
            }
            reader.Close();
        }
        return inputs;
    }
}
