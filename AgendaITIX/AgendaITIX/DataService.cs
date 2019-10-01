using AgendaITIX.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AgendaITIX
{
    class DataService : IDataService
    {
        private readonly ApplicationContext context;

        public DataService(ApplicationContext context )
        {
            this.context = context;
        }

        public void InicializaDB()
        {
            context.Database.Migrate();
        }
    }
}
