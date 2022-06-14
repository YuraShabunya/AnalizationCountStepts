using AnalizationCountStepts.Models;
using System.Windows;
using System.Windows.Controls;
using AnalizationCountStepts.Services;
using System.Windows.Media;
using System;
using AnalizationCountStepts.ViewModels;

namespace AnalizationCountStepts
{   
    public partial class MainWindow : Window
    {
        private Users user;
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ViewModelUsers();
        }

        private void dgTodoList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            user = (Users)dgTodoList.SelectedItem;
            double MaxX = 0, MaxY = user.BestResolt,
                MinX = 0, MinY = user.BadResolt;

            double[] daysX = new double[user.Steps.Count];
            double[] resoltY = new double[user.Steps.Count];
            for (int i = 0; i < daysX.Length; i++)
            {
                daysX[i] = i + 1;
                resoltY[i] = user.Steps[i];
                if (resoltY[i] == MaxY)
                    MaxX = daysX[i];
                if (resoltY[i] == MinY)
                    MinX = daysX[i];
            }
            //Drow
            Analiz.Plot.Clear();
            Analiz.Plot.AddScatter(daysX, resoltY);
            Analiz.Plot.AddPoint(MaxX, MaxY, System.Drawing.Color.Green, 10);
            Analiz.Plot.AddPoint(MinX, MinY, System.Drawing.Color.Red, 10);
            Analiz.Refresh();
        }

        private void dgTodoList_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            user = e.Row.DataContext as Users;
            if (1 - (double)user.AverageResolt / (double)user.BestResolt >= 0.2
                    || 1 - (double)user.BadResolt / (double)user.AverageResolt >= 0.2)
            {
                e.Row.Background = new SolidColorBrush(Colors.Green);
            }
            else
            {
                e.Row.Background = new SolidColorBrush(Colors.Azure);
            }
        }
    }
}
