using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BancoFIAP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BancoFIAP.Controllers
{
    public class ClienteController : Controller
    {

        private static List<Cliente> _lista = new List<Cliente>();

        public IActionResult Index()
        {
            return View(_lista);
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            CarregaTipoConta();
            return View();
        }

        private void CarregaTipoConta()
        {
            List<string> contas = new List<string>();
            contas.Add("Conta corrente");
            contas.Add("Conta poupança");
            contas.Add("Conta Investimento");

            ViewBag.conta = new SelectList(contas);
        }

        [HttpPost]
        public IActionResult Cadastrar(Cliente cliente)
        {
            if (_lista.Any())
            {
                cliente.Codigo = _lista[_lista.Count - 1].Codigo + 1;
            }
            else
            {
                cliente.Codigo = 1;
            }
           
            _lista.Add(cliente);
            TempData["msg"] = "Cliente cadastrado com sucesso!";
            return RedirectToAction("Cadastrar");
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            CarregaTipoConta();
            var cliente = _lista.Find(c => c.Codigo == id);
            return View(cliente);
        }

        [HttpPost]
        public IActionResult Editar(Cliente cliente)
        {            
            _lista[_lista.FindIndex(c => c.Codigo == cliente.Codigo)] = cliente;
            TempData["msg"] = "Cliente atualizado!";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Remover(int id)
        {
            _lista.RemoveAt(_lista.FindIndex(c => c.Codigo == id));
            TempData["msg"] = "Cliente removido!";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Pesquisar(string nome)
        {
            var cliente = _lista.Find(c => c.Nome == nome);
            TempData["msg"] = "Clientre encontrado!";
            return View(cliente);
        }

        [HttpPost]
        public IActionResult Pesquisar(Cliente cliente)
        {
            if(_lista.Exists(c => c.Nome == cliente.Nome))
            {
                return View(cliente);
            }
            else
            {
                return null;
            }
        }
    }
}
