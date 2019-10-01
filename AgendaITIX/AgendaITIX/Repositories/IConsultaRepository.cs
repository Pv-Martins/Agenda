using AgendaITIX.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AgendaITIX.Repositories
{
    public interface IConsultaRepository
    {
        string SaveConsulta(Consulta consulta);
        IList<Consulta> GetConsultas();
        Consulta GetConsulta(int idConsulta);
        void RemoveConsulta(int idConsulta);
        Consulta UpdateConsulta(int id, Consulta consulta);
    }
}