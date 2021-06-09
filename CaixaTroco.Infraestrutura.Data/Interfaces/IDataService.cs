using System;

namespace CaixaTroco.Infraestrutura.Data.Interfaces
{
    public interface IDataService
    {
        public void InitializeDB(IServiceProvider serviceProvider);
    }
}
