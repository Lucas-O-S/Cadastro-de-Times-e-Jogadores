using Microsoft.AspNetCore.Mvc;
using SiteCadastroJogadoresTimes.DAO;
using SiteCadastroJogadoresTimes.Models;

namespace SiteCadastroJogadoresTimes.Controllers
{
	public class JogadoresController : PadraoController<JogadoresViewModel>
	{
		public JogadoresController()
		{
			dao = new JogadoresDAO();
		}
        public override IActionResult Create()
        {
            try
            {
                ViewBag.operacao = "I";
                JogadoresViewModel model = new JogadoresViewModel();
                ViewBag.posicoes = Enum.GetValues(typeof(JogadoresDAO.posicoes)).Cast<JogadoresDAO.posicoes>().ToList();
                TimeFutebolDAO tDAO = new TimeFutebolDAO();
                List<TimeFutebolViewModel> times = tDAO.Listagem();
                ViewBag.times = times;
                return View(NomeViewForm, model);
            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel(erro.ToString()));
            }
        }
        public override IActionResult Edit(int id)
        {
            try
            {
                ViewBag.operacao = "A";
                JogadoresViewModel model = dao.Consulta(id);
                ViewBag.posicoes = Enum.GetValues(typeof(JogadoresDAO.posicoes)).Cast<JogadoresDAO.posicoes>().ToList();
                TimeFutebolDAO tDAO = new TimeFutebolDAO();
                List<TimeFutebolViewModel> times = tDAO.Listagem();
                ViewBag.times = times;
                if (model == null)
                    return RedirecionaParaIndex(model);
                else
                    return View(NomeViewForm, model);
            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel(erro.ToString()));
            }


        }

        protected override void ValidarDados(JogadoresViewModel model, string operacao)
		{

			base.ValidarDados(model, operacao);

			if (string.IsNullOrEmpty(model.nome))
				ModelState.AddModelError("nome", "Nome está vazio");
		}
	}
}
