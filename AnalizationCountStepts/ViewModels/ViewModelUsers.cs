using AnalizationCountStepts.Models;
using AnalizationCountStepts.Services;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

namespace AnalizationCountStepts.ViewModels
{
    public class ViewModelUsers
    {
        private Users selectedUser;
        public List<Users> users { get; set; }

        private RelayCommand export;
        private RelayCommand otherCol;
        public Users SelectedUser
        {
            get { return selectedUser; }
            set
            {
                selectedUser = value;
            }
        }

        public ViewModelUsers()
        {
            Day[][] _day = new Day[30][];
            for (int i = 0; i < 30; i++)
            {

                FileIOServise _fileIOServise = new FileIOServise(i);
                try
                {
                    _day[i] = _fileIOServise.LoadDate();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            ConvertDayToUsers edit = new ConvertDayToUsers();
            users = edit.general(_day);
        }

        public RelayCommand Export
        {
            get
            {
                return export ??
                  (export = new RelayCommand(obj =>
                  {
                      Users user = selectedUser;
                      FileIOServise _fileIOServise;
                      _fileIOServise = new FileIOServise($"{Environment.CurrentDirectory}\\user.json");
                      if (user is not null)
                          try
                          {
                              _fileIOServise.SaveData(user);
                              MessageBox.Show($"{Environment.CurrentDirectory}\\user.json \n Готово!");
                          }
                          catch (Exception ex)
                          {
                              MessageBox.Show(ex.ToString());
                          }
                      else
                          MessageBox.Show("Выберите пользователя!");
                  }));
            }
        }
    }
}
