/*
* Determine which games would have been possible if the bag had been loaded with only 12 red cubes, 13 green cubes, and 14 blue cubes. What is the sum of the IDs of those games?
*/

//Read input vector<structs>
//Check total number of reds against allowed reds etc....

using System.Text.RegularExpressions;

struct Game{
    int GameNumber;
    int RedCount;
    int GreenCount;
    int BlueCount;
}

class Program1
{
    static void Main()
    {
        
    }

    static LinkedList<Game> getGameInfoFromFile(string fileName)
    {
        LinkedList<string> inputLines = getInputLines(fileName);
        LinkedList<Game> gameInfo = new LinkedList<Game>();

        //Can we just grab the max occurrence of each colour and discard the rest?

        return gameInfo;
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