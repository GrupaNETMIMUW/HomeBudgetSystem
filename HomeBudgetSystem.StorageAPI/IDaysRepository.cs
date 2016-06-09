using HomeBudgetSystem.Data.Models;
using System;
using System.Collections.Generic;

namespace HomeBudgetSystem.StorageAPI
{
    public interface IDaysRepository
    {
        IEnumerable<Day> GetAllDays();
        Day GetDayByDate(DateTime date);

        void RemoveDay(Day day);

        void UpdateDay(Day day);
    }
}
