using AgendaITIX.Models;

namespace AgendaITIX.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationContext context;
        private IRepository<Consulta> consultas;
        private IRepository<Paciente> pacientes;

        public UnitOfWork(ApplicationContext context)
        {
            this.context = context;
        }

        public IRepository<Consulta> Consultas {
            get
            {
                return consultas ??
                    (consultas = new BaseRepository<Consulta>(context));
            }
        }

        public IRepository<Paciente> Pacientes
        {
            get
            {
                return pacientes ??
                    (pacientes = new BaseRepository<Paciente>(context));
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
