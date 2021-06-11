using System;

namespace CaixaTroco.Infraestrutura.Data.Interfaces
{
    public interface IEFCoreDataService
    {
        public void InitializeDB(IServiceProvider serviceProvider);
    }
}
