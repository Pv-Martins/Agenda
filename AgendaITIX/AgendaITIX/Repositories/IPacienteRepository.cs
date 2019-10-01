using AgendaITIX.Models;
using System.Collections.Generic;

namespace AgendaITIX.Repositories
{
    public interface IPacienteRepository
    {
        void SavePaciente(Paciente paciente);
        Paciente GetPaciente(int id);
    }
}