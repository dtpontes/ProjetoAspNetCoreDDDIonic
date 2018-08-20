using System;
using System.Collections.Generic;
using System.Text;

namespace YouLearn.Domain.Interfaces.Transactions
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}
