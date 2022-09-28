using System;
using System.IO;
using Newtonsoft.Json.Linq;

namespace TestTask
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter path to json file");
                var filePath = Console.ReadLine();
                var json = CheckFileExisting(filePath);
                Console.WriteLine("Enter json path");
                var jsonPath = Console.ReadLine();
                Console.WriteLine(ParseJson(jsonPath,json));
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        //Checking if a file exists
        public static string CheckFileExisting(string filePath)
        {
            bool fileExist = File.Exists(filePath);
            if (fileExist)
            {
                var json = File.ReadAllText(filePath);
                return json;
            }
            else
            {
                throw new Exception("File does not exist.");
            }
        }
        //Getting information about a json file
        public static JToken ParseJson(string jsonPath,string json)
        {
            try
            {
                JToken o = JToken.Parse(json);
                JToken currentField = o.SelectToken(jsonPath);
                if (currentField == null) throw new Exception("error");
                return currentField;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
