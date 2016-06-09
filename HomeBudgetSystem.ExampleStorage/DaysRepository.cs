using HomeBudgetSystem.Data.Models;
using HomeBudgetSystem.StorageAPI;
using System;
using System.Collections.Generic;

namespace HomeBudgetSystem.ExampleStorage
{
    public class DaysRepository : IDaysRepository
    {
        public IEnumerable<Day> GetAllDays()
        {
            return new Day[0];
        }
        public Day GetDayByDate(DateTime date)
        {
            return new Day
            {
                Id = date,
                Expenses = new List<Transaction>() {
                    new Transaction { Owner = "Ja", Title = "Zakupy", Amount = 22.76M}
                }
            };
        }

        public void RemoveDay(Day day)
        {

        }

        public void UpdateDay(Day day)
        {

        }
    }
}
