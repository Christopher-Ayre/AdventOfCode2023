using System.Data.SqlTypes;
using System.IO;
using System.Text;

class Program1
{
    static void Main()
    {
        try
        {
            LinkedList<string> inputs = getInputs("./Input");
            int total = 0;
            foreach(string input in inputs)
            {
                char[] charArray = input.ToCharArray();

                int one = getFirstNumberOfCharArray(charArray);
                Array.Reverse(charArray);
                int two = getFirstNumberOfCharArray(charArray);
                
                total += Int32.Parse(one.ToString() + two.ToString());
            }

            Console.WriteLine(total);
            Console.ReadLine();
        }
        catch (Exception e)
        {
            Console.WriteLine("Somethong went wrong processing the file: " + e.Message);
        }
    }

    static int getFirstNumberOfCharArray(char[] str)
    {
        for(int ii = 0; ii < str.Length; ii++)
        {
            if(isCharAnInt(str[ii]))
            {
                return str[ii];
            }
        }
        throw new ArgumentException("Couldnt find a number in the given array");
    }

    static bool isCharAnInt(char character)
    {
        if(character >= 48 && character <= 57)
        {
            return true;
        }
        return false;
    }

    static LinkedList<string> getInputs(string fileName)
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
