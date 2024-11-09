namespace SiteCadastroJogadoresTimes.Models
{
	public class TimeFutebolViewModel : PadraoViewModel
	{
		public string nome { get; set; }
		public string nomeDoEstadio { get; set; }
		public IFormFile logotipoTime {  get; set; }
		public byte[] logotipoTimeByte { get; set; }
		public string logotipoTime64 { 
			get {
				if (logotipoTimeByte != null)
					return Convert.ToBase64String(logotipoTimeByte);
				else
					return string.Empty;
				
			} 
		}

		public byte[] ConvertImageToByte(IFormFile file)
		{
			if (file != null)
				using (var ms = new MemoryStream())
				{
					file.CopyTo(ms);
					return ms.ToArray();
				}
			else
				return null;
		}

	}
}
