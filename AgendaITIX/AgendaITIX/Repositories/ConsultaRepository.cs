using AgendaITIX.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgendaITIX.Repositories
{
    public class ConsultaRepository : BaseRepository<Consulta>, IConsultaRepository
    {
        private readonly IPacienteRepository pacienteRepository;

        public ConsultaRepository(ApplicationContext context,
            IPacienteRepository pacienteRepository) : base(context)
        {
            this.pacienteRepository = pacienteRepository;
        }

        public string SaveConsulta(Consulta consulta)
        {
            if ((consulta.DataIni < consulta.DataFim) &&
               (!dbSet.Where(x => ((x.DataIni < consulta.DataIni && consulta.DataIni < x.DataFim) || 
                                  (x.DataIni < consulta.DataFim && consulta.DataFim < x.DataFim) ||
                                  (consulta.DataIni < x.DataIni && x.DataIni < consulta.DataFim))).Any()))
            {
                consulta.Paciente.Update(pacienteRepository.GetPaciente(consulta.PacienteId));
                dbSet.Add(new Consulta(consulta.Paciente, consulta.DataIni, consulta.DataFim, consulta.Observacoes));
                context.SaveChanges();
                return "Dados Salvos com sucesso.";
            }
            else
            {
                return "Favor conferir as datas informadas.";
            }

        }

        public IList<Consulta> GetConsultas()
        {
            foreach (Consulta consulta in dbSet.ToList()){
                consulta.Paciente.Update(pacienteRepository.GetPaciente(consulta.PacienteId));
            }
            return dbSet.ToList();
        }

        public Consulta GetConsulta(int idConsulta)
        {
            Consulta consulta = dbSet.Where(x => x.Id == idConsulta).SingleOrDefault();
            consulta.Paciente.Update(pacienteRepository.GetPaciente(consulta.PacienteId));
            return consulta;
        }

        public void RemoveConsulta(int idConsulta)
        {
            dbSet.Remove(GetConsulta(idConsulta));
            context.SaveChanges();
        }

        public Consulta UpdateConsulta(int id, Consulta consulta)
        {
            consulta.Paciente.Update(pacienteRepository.GetPaciente(consulta.PacienteId));

            var consultaDB =
                dbSet.Where(c => c.Id == id)
                .SingleOrDefault();

            if (consultaDB == null)
            {
                throw new ArgumentNullException("Consulta Inexistente");
            }

            consultaDB.Update(consulta);
            context.SaveChanges();
            return consultaDB;
        }
    
    }
}
