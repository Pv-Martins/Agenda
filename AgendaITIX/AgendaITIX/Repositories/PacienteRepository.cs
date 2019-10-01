using AgendaITIX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgendaITIX.Repositories
{
    public class PacienteRepository : BaseRepository<Paciente>, IPacienteRepository
    {
        public PacienteRepository(ApplicationContext context) : base(context)
        {
        }

        public void SavePaciente(Paciente paciente)
        {
            dbSet.Add(new Paciente(paciente.Nome, paciente.DtNascimento));
            context.SaveChanges();
        }

        public Paciente GetPaciente(int idPaciente)
        {
            return dbSet.Where(x => x.Id == idPaciente).SingleOrDefault();
        }
    }
}
