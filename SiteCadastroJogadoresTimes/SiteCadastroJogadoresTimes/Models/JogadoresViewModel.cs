using System.Runtime.CompilerServices;

namespace SiteCadastroJogadoresTimes.Models
{
	public class JogadoresViewModel : PadraoViewModel
	{
		public string nome { get; set; }
		public int posicao { get; set; }
		public int timeId {  get; set; }

		public string nomePosicao { get; set; }
		public string nomeTime { get; set; }
		
	}
}
