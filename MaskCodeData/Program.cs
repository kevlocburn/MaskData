using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MaskCodeData
{
    class Program
    {
        public class Rule
        {
            public int index;
            public int length;
            // public List<String> codes;
            public string[] codes;

            public Rule(int index, int length, string[] codes)//List<string> codes)
            {
                this.index = index;
                this.length = length;
                this.codes = codes;
            }
        }
        static void Main(string[] args)
        {
            //object start length index has match. loop through

            //


            //data in file
            /* 
             976782222299999uuuuu
             000008888855555     
             55555111116666600000
             11111     37383          
             mmmmmaaaaa11111bbbbb
             66666111116666611111
             */
            List<Rule> rules = new List<Rule>();
            // rules.Add(new Rule(5, 5, new List<string>() { "11111", "22222", "33333" }));
            rules.Add(new Rule(5, 5, ICD10.codes));
            rules.Add(new Rule(10, 5, new string[] { "44444", "55555", "66666" }));

            string fileName = @"c:\test\sampleText.txt";
            using (StreamWriter outputFile = new StreamWriter(@"C:\test\testresult.txt", true))

                //read the line of earch file and find the codes in the fixed width
                foreach (string line in File.ReadLines(fileName))
                {
                    var modifiedLine = line;
                    foreach(Rule rule in rules)
                    {
                        var mask = "";
                        for (var i = 0; i < rule.length; i++) 
                            mask += "#";

                        var chunk = modifiedLine.Substring(rule.index, rule.length);
                        if (rule.codes.Contains(chunk))
                        {
                            var pre = modifiedLine.Substring(0, rule.index);
                            var post = modifiedLine.Substring(rule.index + rule.length, modifiedLine.Length - (rule.index + rule.length));
                            modifiedLine = pre + mask + post;
                        }
                    }

                    outputFile.WriteLine(modifiedLine);


                    //foreach each object code 

                    //var partOne = line.Substring(0, 5);

                    //var partTwo = line.Substring(5, 5);

                    ////codes that need to be masked at this file location
                    //string[] partTwoArray = { "11111", "22222", "33333" };
                    //var replacePartTwo = partTwo.Replace(partTwo, "#####");
                    //var partThree = line.Substring(10, 5);
                    ////codes that need to be masked at this file location
                    //string[] partThreeArray = { "44444", "55555", "66666" };
                    //var replacePartThree = partThree.Replace(partThree, "#####");

                    //var partFour = line.Substring(15, 5);

                    ////and so on  

                    //    //if the code matches one of the strings in the array, replace the string with ##### and write the line
                    // if ((partTwoArray.Any(partTwo.Contains)) && (partThreeArray.Any(partThree.Contains)))
                    //{
                    //    outputFile.WriteLine("{0}{1}{2}{3}", partOne, replacePartTwo, replacePartThree, partFour);
                    //}
                    //else if (partTwoArray.Any(partTwo.Contains))
                    //{
                    //    outputFile.WriteLine("{0}{1}{2}{3}", partOne, replacePartTwo, partThree, partFour);
                    //}
                    //else if (partThreeArray.Any(partThree.Contains))
                    //{
                    //    outputFile.WriteLine("{0}{1}{2}{3}", partOne, partTwo, replacePartThree, partFour);
                    //}
                   

                    //else
                    //{
                    //    outputFile.WriteLine("{0}{1}{2}{3}", partOne, partTwo, partThree, partFour);
                    //}
                }


            //output data
            /*
                    97678#####99999uuuuu
                    0000088888#####     
                    55555##########00000
                    11111     37383     
                    mmmmmaaaaa11111bbbbb
                    66666##########11111

           */
        }
    }
}
