using System;
using System.IO;
using System.Collections.Generic;
using dotnet_code_challenge.Processors;
using dotnet_code_challenge.Model;
using System.Reflection;

namespace dotnet_code_challenge
{
    class Program
    {
        static void Main(string[] args)
        {
            XMLProcessor xmlProc;
            JSONProcessor jsonProc;
            List<Horse> horses = new List<Horse>();

            //Get list of all files in the path. (FeedData directory)
            string feedPath = Path.Combine(@"C:\Users\Manes\Desktop\BetEasy-Coding-Challenge\code-challenge\dotnet-code-challenge\FeedData");
            string[] fileList = Directory.GetFiles(feedPath);
            foreach(string path in fileList)
            {
                //Fire the XML processor
                if (Path.GetExtension(path).Equals(".xml"))
                {
                    xmlProc = new XMLProcessor(path);
                    horses.AddRange(xmlProc.Process());
                }

                //Fire the JSON processor
                if (Path.GetExtension(path).Equals(".json"))
                {
                    jsonProc = new JSONProcessor();
                    horses.AddRange(jsonProc.Process(Path.GetFileName(path)));
                }
            }

            if (horses.Count > 0)
            {
                Console.WriteLine("********** HORSE LIST **********");

                foreach (Horse horse in horses)
                {
                    Console.WriteLine(horse.Name + "  -  " + horse.Price);
                }

                Console.WriteLine("********************************");
            }
            else
            {
                Console.WriteLine("No horses found!");
            }
        }
    }
}
