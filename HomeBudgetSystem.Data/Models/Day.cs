using System;
using System.Collections.Generic;

namespace HomeBudgetSystem.Data.Models
{
    public class Day
    {
        public DateTime Id { get; set; }
        public List<Transaction> Expenses { get; set; }
        public List<Transaction> Incomes { get; set; }
    }
}
