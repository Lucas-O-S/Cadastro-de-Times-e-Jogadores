using SiteCadastroJogadoresTimes.Models;
using System.Data;
using System.Data.SqlClient;

namespace SiteCadastroJogadoresTimes.DAO
{
	public class JogadoresDAO : PadraoDAO<JogadoresViewModel>
	{
        public enum posicoes { Goleiro, Atacante, Meia, Zagueiro, Lateral }

        protected override void SetTabela()
		{
			tabela = "jogadores";
		}
		protected override SqlParameter[] CriarParametros(JogadoresViewModel model)
		{
			SqlParameter[] sp;
			if (model.id == null || model.id == 0)
			{
				sp = new SqlParameter[]
				{
					new SqlParameter("posicao",model.posicao),
					new SqlParameter("nome",model.nome),
					new SqlParameter("timeId",model.timeId)


				};
			}
			else
			{
				sp = new SqlParameter[]
				{	
					new SqlParameter("id",model.id),
					new SqlParameter("posicao",model.posicao),
					new SqlParameter("nome",model.nome),
					new SqlParameter("timeId",model.timeId)


				};

			}
			return sp;
		}

		protected override JogadoresViewModel MontarModel(DataRow registro)
		{
			JogadoresViewModel model = new JogadoresViewModel();
			model.id = Convert.ToInt32(registro["id"]);
			model.posicao = Convert.ToInt32(registro["posicao"]);
			model.timeId = Convert.ToInt32(registro["timeId"]);
			model.nome = Convert.ToString(registro["nome"]);
			TimeFutebolDAO timesFutebolDAO = new TimeFutebolDAO();
			TimeFutebolViewModel time = timesFutebolDAO.Consulta(model.timeId);
			model.nomeTime = time.nome;
			model.nomePosicao = Enum.GetName(typeof (posicoes), model.posicao) ;

			return model;
		}
	}
}
