using AnalizationCountStepts.Models;
using System.Collections.Generic;

namespace AnalizationCountStepts.Services
{
    public static class GenericCountDay<T>
    {
        public static List<T> CountDay(string name, Day[][] day, string type)
        {
            List<T> arrey = new List<T>();
            for (int i = 0; i < day.Length; i++)
            {
                for (int j = 0; j < day[i].Length; j++)
                {
                    if (name == day[i][j].User)
                    {
                        switch (type)
                        {
                            case "Rang": arrey.Add((T)(object)day[i][j].Rank); break;
                            case "Steps": arrey.Add((T)(object)day[i][j].Steps); break;
                            case "Status": arrey.Add((T)(object)day[i][j].Status); break;
                        }
                    }
                }
            }
            return arrey;
        }
    }
}
