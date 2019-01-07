using projetoWhois.APIs.Whois;
using projetoWhois.DAL;
using projetoWhois.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.Mvc;

namespace projetoWhois.Controllers
{
    public class HomeController : Controller
    {
        private WhoisContext _db = new WhoisContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Buscas()
        {
            var listaDados = new List<WhoisInfo>();
            listaDados= _db.WhoisInfo.ToList();
            listaDados.Reverse();
            return View(listaDados);
        }

        [HttpPost]
        public ActionResult Consulta(string dominio)
        {
            try
            {
                if (string.IsNullOrEmpty(dominio)) throw new NullReferenceException();
                if (!DomainIsValid(dominio)) throw new Exception();

                var dados = new WhoisClient().BuscarInfo(dominio);
                _db.WhoisInfo.Add(dados);
                _db.SaveChanges();
                return View("Index",new ResponseView() {Message = "Domínio pesquisado com sucesso", Success = true, WhoisInfo = dados });
            }
            catch (Exception ex)
            {
                return View("Index",new ResponseView() { Message = "Domínio inválido", Success = false});
                throw;
            }
           
        }

        public bool DomainIsValid(string domain)
        {
            var regex = @"^((?!-))(xn--)?[a-z0-9][a-z0-9-_]{0,61}[a-z0-9]{0,1}\.(xn--)?([a-z0-9\-]{1,61}|[a-z0-9-]{1,30}\.[a-z]{2,})$";
            var match = Regex.Match(domain, regex, RegexOptions.IgnoreCase);
            return match.Success;
        }
    }
}