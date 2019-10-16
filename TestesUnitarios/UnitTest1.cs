using API_Processos_Core.Models;
using API_Processos_Core.Repositories;
using System.Collections.Generic;
using Xunit;

namespace TestesUnitarios
{
    public class TestesUnitariosParaProcessos
    {
        public readonly ProcessoRepositorio _repositorio;

        public TestesUnitariosParaProcessos()
        {
            _repositorio = new ProcessoRepositorio(new Contexto());
        }

        [Fact]
        public void ShouldGetFiveElements()
        {
            IList<Processo> processos = _repositorio.GetAll();
            Assert.Equal(5, processos.Count);
        }

        [Fact]
        public void ShouldGetNotNullList()
        {
            IList<string> agrupamentos = _repositorio.GetGroupsByOffice();
            Assert.NotNull(agrupamentos);
        }
    }
}
