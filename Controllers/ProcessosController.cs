using API_Processos_Core.Models;
using API_Processos_Core.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace API_Processos_Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcessosController : ControllerBase
    {
        private readonly ProcessoRepositorio _repositorio;

        public ProcessosController(ProcessoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            try
            {
                IList<string> resultado = new List<string>();
                IList<Processo> lista = _repositorio.GetAll();
                foreach (var item in lista)
                {
                    string numeroProcesso = double.Parse(item.Numero).ToString("#######:##-####-#-##-####").Replace("-", ".").Replace(":", "-"); // Formato "#######-##.####.#.##.####"
                    string valorProcesso = string.Format("{0:0,0.00}", item.Valor);
                    resultado.Add(item.Id.ToString() + "|" + numeroProcesso + "|" + item.DataCriacao.ToString("dd/MM/yyyy") + "|" + valorProcesso + "|" + item.Escritorio.Nome);
                }
                return new JsonResult(new { resultado = resultado });
            }
            catch (Exception ex)
            {
                string erro = ex.Message;
                return null;
            }
        }

        [HttpGet]
        [Route("Group")]
        public ActionResult GetCountByEscritorio()
        {
            try
            {
                IList<string> resultado = new List<string>();
                IList<string> lista = _repositorio.GetGroupsByOffice();
                return new JsonResult(new { resultado = lista });
            }
            catch (Exception ex)
            {
                string erro = ex.Message;
                return null;
            }
        }
    }
}