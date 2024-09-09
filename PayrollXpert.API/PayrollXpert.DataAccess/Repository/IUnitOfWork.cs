﻿using Bulky.DataAccess.Repository;

namespace PayrollXpert.DataAccess.Repository
{
    public interface IUnitOfWork
    {
        IEmployeeRepository Employee { get; }

        void save();
    }
}
