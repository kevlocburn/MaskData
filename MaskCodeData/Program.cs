using System;
using System.IO;
using System.Linq;

namespace MaskCodeData
{
    class Program
    {
        static void Main(string[] args)
        {

            //data in file
            /* 
             976782222299999uuuuu
             000008888855555     
             55555111116666600000
             11111     37383          
             mmmmmaaaaa11111bbbbb  
             
             */
            string fileName = @"c:\test\sampleText.txt";
            using (StreamWriter outputFile = new StreamWriter(@"C:\test\testresult.txt", true))

                //read the line of earch file and find the codes in the fixed width
                foreach (string line in File.ReadLines(fileName))
                {
                    var partOne = line.Substring(0, 5);

                    var partTwo = line.Substring(5, 5);

                    //codes that need to be masked at this file location
                    string[] partTwoArray = { "11111", "22222", "33333" };
                    var replacePartTwo = partTwo.Replace(partTwo, "#####");
                    var partThree = line.Substring(10, 5);
                    //codes that need to be masked at this file location
                    string[] partThreeArray = { "44444", "55555", "66666" };
                    var replacePartThree = partThree.Replace(partThree, "#####");

                    var partFour = line.Substring(15, 5);

                    //and so on  

                    //if the code matches one of the strings in the array, replace the string with #####
                    if (partTwoArray.Any(partTwo.Contains))
                    {
                        outputFile.WriteLine("{0}{1}{2}{3}", partOne, replacePartTwo, partThree, partFour);
                    }
                    //if the code matches one of the strings in the array, replace the string with #####
                    else if (partThreeArray.Any(partThree.Contains))
                    {
                        outputFile.WriteLine("{0}{1}{2}{3}", partOne, partTwo, replacePartThree, partFour);
                    }
                    //if the code matches both of the strings in the array, replace the string with #####
                    else if ((partTwoArray.Any(partTwo.Contains)) && (partThreeArray.Any(partThree.Contains)))
                    {
                        outputFile.WriteLine("{0}{1}{2}{3}", partOne, replacePartTwo, replacePartThree, partFour);
                    }
                    //write the line as it is
                    else
                    {
                        outputFile.WriteLine("{0}{1}{2}{3}", partOne, partTwo, partThree, partFour);
                    }
                }


              //output data
              /*
                    97678#####99999uuuuu
                    0000088888#####     
                    55555#####6666600000
                    11111     37383     
                    mmmmmaaaaa11111bbbbb
             
             */
        }
    }
}
