using AnalizationCountStepts.Models;
using System;
using System.Collections.Generic;

namespace AnalizationCountStepts.Services
{
    public class ConvertDayToUsers
    {
        private List<Users> _users = new List<Users>();
        public List<Users> general(Day[][] day)
        {

            for (int i = 0; i < 30; i++)
            {
                for (int j = 0; j < day[i].Length; j++)
                {
                    if (Comparison(day[i][j].User) || _users.Count == 0)
                    {
                        _users.Add(new Users
                        {
                            Name = day[i][j].User,
                            Steps = GenericCountDay<int>.CountDay(day[i][j].User, day, "Steps"),
                            Rank = GenericCountDay<int>.CountDay(day[i][j].User, day, "Rang"),
                            Status = GenericCountDay<string>.CountDay(day[i][j].User, day, "Status")
                        });
                    }
                }
            }

            return _users;
        }
        private bool Comparison(string str)
        {
            bool role = true;
            foreach (Users user in _users)
                if (user.Name == str)
                    role = false;
            return role;
        }
    }
}
