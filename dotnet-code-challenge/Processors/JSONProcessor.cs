using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using dotnet_code_challenge.Model;
using Newtonsoft.Json;

namespace dotnet_code_challenge.Processors
{
    class JSONProcessor
    {
        public List<Horse> Process(string filename)
        {
            List<Horse> horses = new List<Horse>();
            try
            {
                using (StreamReader sr = new StreamReader(
                    Path.Combine(@"C:\Users\Manes\Desktop\BetEasy-Coding-Challenge\code-challenge\dotnet-code-challenge\FeedData", filename)
                    ))
                {
                    string json = sr.ReadToEnd();
                    dynamic jsonData = JsonConvert.DeserializeObject(json);
                    if (jsonData != null)
                    {
                        foreach (var market in jsonData.Markets)
                        {
                            foreach (var selection in market.Selections)
                            {
                                horses.Add(new Horse { Name = selection.Tags.name, Price = selection.Price });
                            }
                        }
                    }
                }
            }
            catch(FileNotFoundException fex)
            {
                throw new Exception("JSON file not found");
            }
            catch(Exception ex)
            {
                throw new Exception("Unexpected JSON format");
            }

            return horses;
        }
    }
}
