using AnalizationCountStepts.Models;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Windows;

namespace AnalizationCountStepts.Services
{
    public class FileIOServise
    {
        private readonly string PATH;

        public FileIOServise(int i)
        {
            PATH = $"{Environment.CurrentDirectory}\\TestData\\day{i + 1}.json";
        }
        public FileIOServise(string PATH)
        {
            this.PATH = PATH;
        }

        public Day[] LoadDate()
        {
            var fileExists = File.Exists(PATH);
            if(!fileExists)
            {
                File.CreateText(PATH).Dispose();
                return new Day[0];
            }
            using (var reader = File.OpenText(PATH))
            {
                var fileText = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<Day[]>(fileText);
            }
        }

        public void SaveData(Users users)
        {
            using (StreamWriter writer = File.CreateText(PATH))
            {
                string output = JsonConvert.SerializeObject(users);
                writer.Write(output);
            }
        }
    }
}
