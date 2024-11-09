using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using SiteCadastroJogadoresTimes.DAO;
using SiteCadastroJogadoresTimes.Models;

namespace SiteCadastroJogadoresTimes.Controllers
{
	public class TimeFutebolController : PadraoController<TimeFutebolViewModel>
	{
		public TimeFutebolController() { 
			dao = new TimeFutebolDAO();
		}

		protected override void ValidarDados(TimeFutebolViewModel model, string operacao)
		{

			base.ValidarDados(model, operacao);
			
			if(string.IsNullOrEmpty( model.nomeDoEstadio))
				ModelState.AddModelError("nomeDoStadio", "Nome do Estadio está vazio");

			if (string.IsNullOrEmpty(model.nome))
				ModelState.AddModelError("nome", "Nome está vazio");

			if (model.logotipoTime == null && operacao == "I")
				ModelState.AddModelError("logotipoTime","Adicione uma imagem");
			

			if (model.logotipoTime != null && model.logotipoTime.Length / 1024 / 1024 >= 2)
				ModelState.AddModelError("logotipoTime", "Imagem limitada a 2 mb.");

			if (ModelState.IsValid)
			{
				if(operacao == "A" && model.logotipoTime == null)
				{
					TimeFutebolViewModel temp = dao.Consulta(model.id);
					model.logotipoTimeByte = temp.logotipoTimeByte;

				}
				else
				{
					model.logotipoTimeByte = model.ConvertImageToByte(model.logotipoTime);

				}
			}



		}
	}
}
