using API_Processos_Core.Models;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API_Processos_Core.Repositories
{
    public class ProcessoRepositorio
    {
        private readonly Contexto _contexto;
        public IList<Escritorio> _escritorios;
        public IList<Processo> _processos;

        public ProcessoRepositorio(Contexto contexto)
        {
            _contexto = contexto;
            _escritorios = new List<Escritorio>();
            _processos = new List<Processo>();
            // Carga de dados
            Escritorio e1 = new Escritorio(); e1.Id = 1; e1.Nome = "Escritório I"; _escritorios.Add(e1);
            Escritorio e2 = new Escritorio(); e2.Id = 2; e2.Nome = "Escritório II"; _escritorios.Add(e2);
            Escritorio e3 = new Escritorio(); e3.Id = 3; e3.Nome = "Escritório III"; _escritorios.Add(e3);
            Processo p1 = new Processo(); p1.Id = 1; p1.Numero = "011111111111111111"; p1.DataCriacao = new DateTime(2019, 1, 1); p1.Valor = 1000M; p1.EscritorioId = 1; p1.Escritorio = e1; _processos.Add(p1);
            Processo p2 = new Processo(); p2.Id = 2; p2.Numero = "022222222222222222"; p2.DataCriacao = new DateTime(2018, 1, 10); p2.Valor = 1500M; p2.EscritorioId = 2; p2.Escritorio = e2; _processos.Add(p2);
            Processo p3 = new Processo(); p3.Id = 3; p3.Numero = "033333333333333333"; p3.DataCriacao = new DateTime(2017, 12, 7); p3.Valor = 2000M; p3.EscritorioId = 3; p3.Escritorio = e3; _processos.Add(p3);
            Processo p4 = new Processo(); p4.Id = 4; p4.Numero = "044444444444444444"; p4.DataCriacao = new DateTime(2016, 5, 31); p4.Valor = 1700M; p4.EscritorioId = 3; p4.Escritorio = e3; _processos.Add(p4);
            Processo p5 = new Processo(); p5.Id = 5; p5.Numero = "055555555555555555"; p5.DataCriacao = new DateTime(2015, 3, 1); p5.Valor = 2000M; p5.EscritorioId = 3; p5.Escritorio = e3; _processos.Add(p5);
        }

        public List<Processo> GetAll()
        {
            List<Processo> processo = _processos.OrderBy(x => x.Escritorio.Nome).ThenBy(x => x.Numero).ToList();
            return processo;
        }

        public List<string> GetGroupsByOffice()
        {
            List<string> resultado = new List<string>();

            var listaAgrupamentos = _escritorios
                                    .Join(_processos, escritorio => escritorio.Id, processo => processo.EscritorioId, (escritorio, processo) => new { escritorio, processo })
                                    .GroupBy(x => new { x.escritorio.Nome })
                                    .Select(g => new { nome = g.Key.Nome, qtProcessos = g.Count() }).ToList();
            listaAgrupamentos = listaAgrupamentos.OrderBy(x => x.nome).ToList();

            foreach (var item in listaAgrupamentos)
                resultado.Add(item.nome + "|" + item.qtProcessos.ToString());
            return resultado;
        }
    }
}