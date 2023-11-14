namespace Relativity.DataExchange.Wrapper
{
	using System.Data;

	public class ImportImageSettings : ImportSettingsBase
	{
		public bool AutoNumberImages { get; set; }
		public string BatesNumberField { get; set; }
		public DataTable DataSource { get; set; }
		public bool? DisableImageLocationValidation { get; set; }
		public bool? DisableImageTypeValidation { get; set; }
		public string DocumentIdentifierField { get; set; }
		public string FileLocationField { get; set; }
		public bool ForProduction { get; set; }
		public string ImageFilePathSourceFieldName { get; set; }
	}
}