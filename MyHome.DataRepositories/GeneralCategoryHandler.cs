﻿using System.Collections.Generic;
using System.Linq;
using MyHome.Persistence;

namespace MyHome.DataRepository
{
    // TODO - QC - Create a service that merges the categories
    public class GeneralCategoryHandler
    {
        private readonly AccountingDataContext _dataContext;

        public GeneralCategoryHandler(AccountingDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IEnumerable<string> GetAllCategoryNames()
        {
            var categoryNames = new List<string> { "Total Expenses" };
            categoryNames.AddRange(_dataContext.ExpenseCategories.Select(c => c.Name));
            categoryNames.Add("Total Income");

            foreach (var incomeCategoryName in _dataContext.IncomeCategories.Select(c => c.Name))
            {
                if (categoryNames.Contains(incomeCategoryName))
                {
                    categoryNames[categoryNames.IndexOf(incomeCategoryName)] = $"{incomeCategoryName} - Expense";
                    categoryNames.Add($"{incomeCategoryName} - Income");
                }
                else
                {
                    categoryNames.Add(incomeCategoryName);
                }
            }

            return categoryNames;
        }

        public IEnumerable<string> GetAllCategoryNames(string categoryType)
        {
            switch (categoryType.ToLower())
            {
                case "expense":
                    {
                        return _dataContext.ExpenseCategories.Select(c => c.Name).ToList();
                    }
                case "income":
                    {
                        return _dataContext.IncomeCategories.Select(c => c.Name).ToList();
                    }
                default:
                    {
                        return new List<string>();
                    }
            }
        }
    }
}