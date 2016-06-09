using HomeBudgetSystem.Data.Models;
using HomeBudgetSystem.Helpers;
using HomeBudgetSystem.StorageAPI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HomeBudgetSystem.ViewModels
{
    public class DailyExpensesViewModel : INotifyPropertyChanged
    {
        private IDaysRepository repository;

        public DailyExpensesViewModel(IDaysRepository repo) : this(repo, DateTime.Today)
        { }

        public DailyExpensesViewModel(IDaysRepository repo, DateTime day)
        {
            repository = repo;
            currentDay = repo.GetDayByDate(day);
            currentDate = day;

            NextDay = new Command(parameter =>
            {
                currentDate = currentDate.Add(new TimeSpan(1, 0, 0, 0));
                OnPropertyChanged("DateText");
                repo.GetDayByDate(currentDate);
                OnPropertyChanged("Expenses");
            },
                parameter => true);
            PreviousDay = new Command(parameter => 
            {
                currentDate = currentDate.Subtract(new TimeSpan(1, 0, 0, 0));
                OnPropertyChanged("DateText");
                repo.GetDayByDate(currentDate);
                OnPropertyChanged("Expenses");
            },
                parameter => true);
        }

        private DateTime currentDate;
        private Day currentDay;

        public IEnumerable<Transaction> Expenses
        {
            get
            {
                return currentDay.Expenses;
            }
        }

        public string DateText
        {
            get
            {
                if (DateTime.Today.ToShortDateString() == currentDate.ToShortDateString())
                    return "Today";
                else
                    return currentDate.ToShortDateString();
            }
        }

        public ICommand NextDay { get; set; }
        public ICommand PreviousDay { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
