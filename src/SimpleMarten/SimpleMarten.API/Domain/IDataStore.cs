using System;
using System.Threading.Tasks;

namespace SimpleMarten.API.Domain
{
    public interface IDataStore : IDisposable
    {
        IPolicyAccountRepository PolicyAccounts { get; }

        Task CommitChanges();
    }
}