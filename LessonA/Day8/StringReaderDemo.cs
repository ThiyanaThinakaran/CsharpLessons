using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson1.Day8
{
    internal class StringReaderDemo
    {
        public static void PeekAndReadCharacters()
        {
            string readerText = "Tom and Jerry is an American animated media franchise and series of comedy short films created in 1940 by William Hanna and Joseph Barbera.\n" +
                " Best known for its 161 theatrical short films by Metro-Goldwyn-Mayer, the series centers on the rivalry between the titular characters of a cat named Tom and a mouse named Jerry.\n " +
                "Many shorts also feature several recurring characters.";



            Console.WriteLine("Original text:\n\n{0}", readerText);
            Console.WriteLine("*****************************************");
            StringReader strReader = new StringReader(readerText);
            // Peek to see if the next character exists
            try
            {
                while (strReader.Peek() > -1)
                {
                    // Read a line from the Stream and display it on the console
                    Console.WriteLine(strReader.ReadLine() + "--");
                }
                Console.WriteLine("Data Read Complete!");
            }
            finally
            {
                //Close the stringReader
                strReader.Close();
            }
        }
    }
}
