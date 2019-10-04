using AgendaITIX.Models;

namespace AgendaITIX.Repositories
{
    public interface IUnitOfWork
    {
        IRepository<Consulta> Consultas { get; }
        IRepository<Paciente> Pacientes { get;  }
        void Save();
    }
}