using System;

namespace API_Processos_Core.Models
{
    public class Processo
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public DateTime DataCriacao { get; set; }
        public decimal Valor { get; set; }
        public int EscritorioId { get; set; }
        public Escritorio Escritorio { get; set; }
    }
}