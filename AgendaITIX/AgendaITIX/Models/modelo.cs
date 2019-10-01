using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace AgendaITIX.Models
{
    [DataContract]
    public abstract class BaseModel
    {
        [DataMember]
        public int Id { get; protected set; }
    }

    public class Paciente : BaseModel
    {
         public Paciente()
        {
        }

        public Paciente(int id)
        {
            this.Id = id;
        }

        public Paciente(string nome, DateTime dtNascimento)
        {
            Nome = nome;
            DtNascimento = dtNascimento;
        }

        [MinLength(5, ErrorMessage = "Nome deve ter no mínimo 3 caracteres")]
        [MaxLength(50, ErrorMessage = "Nome deve ter no máximo 35 caracteres")]
        [Required(ErrorMessage = "Nome é obrigatório")]
        public string Nome { get; set; } = "";

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "A Data de Nascimento é obrigatoria")]
        public DateTime DtNascimento { get; set; }

        internal void Update(Paciente novoPaciente)
        {
            this.Nome = novoPaciente.Nome;
            this.DtNascimento = novoPaciente.DtNascimento;
        }
    }

    public class Consulta : BaseModel
    {
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy-hh-mm}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "A Data Inicial é obrigatoria")]
        public DateTime DataIni { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy-hh-mm}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "A Data Final é obrigatoria")]
        public DateTime DataFim { get; set; }

        public String Observacoes { get; set; }

        [Required]
        public int PacienteId { get; set; }

        public Consulta()
        {
            Paciente = new Paciente();
        }

        public Consulta(int id)
        {
            this.Id = id;
        }

        public Consulta(Paciente paciente, DateTime dataIni, DateTime dataFim, String observacoes)
        {
            this.Paciente = paciente;
            this.DataIni = dataIni;
            this.DataFim = dataFim;
            this.Observacoes = observacoes;
        }

        [Required]
        public virtual Paciente Paciente { get; private set; }

        internal void Update(Consulta novaConsulta)
        {
            this.Paciente = novaConsulta.Paciente;
            this.DataIni = novaConsulta.DataIni;
            this.DataFim = novaConsulta.DataFim;
            this.Observacoes = novaConsulta.Observacoes;
        }

    }
}
