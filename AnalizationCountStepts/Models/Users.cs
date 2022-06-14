using System.Collections.Generic;
using System.Linq;

namespace AnalizationCountStepts.Models
{
    public class Users
    {
        public List<int> Rank { get; set; }
        public string Name { get; set; }
        public List<int> Steps { get; set; }
        public List<string> Status { get; set; }
        public int AverageResolt
        {
            get
            {
                return Steps.Sum() / Steps.Count;
            }
        }
        public int BestResolt
        {
            get
            {
                return Steps.Max();
            }
        }
        public int BadResolt
        {
            get
            {
                return Steps.Min();
            }
        }
    }
}
