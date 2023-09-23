using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson1.Day8
{
    
        public partial class DemoB
        {

            static MemoryStream memoryStream = new MemoryStream();
            //Using BinaryWriter to store random byte value
            public static void WriteBytesToMemoryStream()
            {
                Console.WriteLine("MemoryStream Length " + memoryStream.Length);
                int arrayLength = 10;
                byte[] dataArray = new byte[arrayLength];

                // Create random numbers and fill the dataArray
                Random r1 = new Random();
                r1.NextBytes(dataArray);
                StringBuilder str = new StringBuilder(arrayLength);
                for (int i = 0; i < arrayLength; i++)
                {
                    str.Append(dataArray[i]);
                    str.Append(";");
                }
                Console.WriteLine(str);



                //bool flag = true;
                //byte[] data = BitConverter.GetBytes(flag);
                BinaryWriter binWriter = new BinaryWriter(memoryStream);
                // read data (the random numbers) from dataArray and write to MemoryStream
                binWriter.Write(dataArray);
                Console.WriteLine("Write Completed " + memoryStream.Length);
            }
            //Using BinaryReader
            public static void ReadBytesFromMemoryStream()
            {
                if (memoryStream.Length == 0)
                {
                    Console.WriteLine("Memory Stream is Empty");
                    return;
                }
                // Create the reader using the stream from the writer.
                BinaryReader binReader = new BinaryReader(memoryStream);
                // Set Position to the beginning of the stream.
                binReader.BaseStream.Position = 0;
                // Read and verify the data.
                int arrayLength = (int)memoryStream.Length;
                byte[] verifyArray = binReader.ReadBytes(arrayLength);
                StringBuilder str = new StringBuilder(arrayLength);
                for (int i = 0; i < arrayLength; i++)
                {
                    str.Append(verifyArray[i]);
                    str.Append(";");
                }
                Console.WriteLine(str);
            }
        //Using BinaryWriter to store String 
        public static void WriteStringToMemoryStream()
        {
            Console.WriteLine("MemoryStream Length " + memoryStream.Length);
            Console.WriteLine("Enter a String ");
            String inputData = Console.ReadLine();
            if (inputData == null)
            {
                System.Console.WriteLine("INPUT IS EMPTY");
                return;
            }
            byte[] dataArray = System.Text.Encoding.ASCII.GetBytes(inputData);
            BinaryWriter binWriter = new BinaryWriter(memoryStream);
            // read data(the random numbers) from dataArray and write to MemoryStream
            binWriter.Write(dataArray);
            Console.WriteLine("Write Completed " + memoryStream.Length);
        }
        //Using BinaryReader to read string from MemoryStream
        public static void ReadStringFromMemoryStream()
        {
            if (memoryStream.Length == 0)
            {
                Console.WriteLine("Memory Stream is Empty");
                return;
            }
            // Create the reader using the stream from the writer.
            BinaryReader binReader = new BinaryReader(memoryStream);
            // Set Position to the beginning of the stream.
            binReader.BaseStream.Position = 0;
            // Read and verify the data.
            int arrayLength = (int)memoryStream.Length;
            // memoryStream.Length is Long but binReader.ReadBytes(int)
            byte[] verifyArray = binReader.ReadBytes(arrayLength);
            String stringOutput = Encoding.ASCII.GetString(verifyArray);
            Console.WriteLine(stringOutput);
        }
        }
}

