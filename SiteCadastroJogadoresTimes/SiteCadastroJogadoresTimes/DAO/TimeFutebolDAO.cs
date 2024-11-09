using SiteCadastroJogadoresTimes.Models;
using System.Data.SqlClient;
using System.Data;

namespace SiteCadastroJogadoresTimes.DAO
{
	public class TimeFutebolDAO : PadraoDAO<TimeFutebolViewModel>
	{
		protected override void SetTabela()
		{
			tabela = "TimeFutebol";
		}
		protected override SqlParameter[] CriarParametros(TimeFutebolViewModel model)
		{
			
			object imgByte = model.logotipoTimeByte;
			if (imgByte == null) imgByte = DBNull.Value;
			SqlParameter[] sp;
			if (model.id == null || model.id == 0)
			{
				sp = new SqlParameter[]
				{
					new SqlParameter("NomeDoEstadio",model.nomeDoEstadio),
					new SqlParameter("nome",model.nome),
					new SqlParameter("LogotipoTime",imgByte)


				};
			}
			else
			{
				sp = new SqlParameter[]
				{
					new SqlParameter("id",model.id),
					new SqlParameter("NomeDoEstadio",model.nomeDoEstadio),
					new SqlParameter("nome",model.nome),
					new SqlParameter("LogotipoTime",imgByte)


				};

			}
			return sp;
		}

		protected override TimeFutebolViewModel MontarModel(DataRow registro)
		{
			TimeFutebolViewModel model = new TimeFutebolViewModel();
			model.id = Convert.ToInt32(registro["id"]);

			model.logotipoTimeByte = registro["logotipoTime"] as byte[]; 

			model.nomeDoEstadio = Convert.ToString(registro["NomeDoEstadio"]);
			model.nome = Convert.ToString(registro["nome"]);

			return model;
		}
	}
}
