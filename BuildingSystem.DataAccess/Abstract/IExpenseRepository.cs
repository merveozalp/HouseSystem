﻿using Entites.Entitiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingSystem.DataAccess.Abstract
{
    public interface IExpenseRepository:IGenericRepository<Expense>
    {
        Task<List<Expense>> GetAllExpenses();
    }
}
