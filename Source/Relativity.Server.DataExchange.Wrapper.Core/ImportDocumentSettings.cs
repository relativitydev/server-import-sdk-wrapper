namespace Relativity.Server.DataExchange.Wrapper
{
	using System.Data;

	public class ImportDocumentSettings : ImportSettingsBase
	{
		public string BulkLoadFileFieldDelimiter { get; set; }
		public string DataGridIDColumnName { get; set; }
		public bool DisableControlNumberCompatibilityMode { get; set; }
		public bool DisableExtractedTextFileLocationValidation { get; set; }
		public bool? DisableNativeLocationValidation { get; set; }
		public bool? DisableNativeValidation { get; set; }
		public IDataReader DataSource { get; set; }
		public string FileNameColumn { get; set; }
		public string FileSizeColumn { get; set; }
		public bool FileSizeMapped { get; set; }
		public string LongTextColumnThatContainsPathToFullText { get; set; }
		public char MultiValueDelimiter { get; set; }
		public char NestedValueDelimiter { get; set; }
		public string NativeFilePathSourceFieldName { get; set; }
		public string OIFileIdColumnName { get; set; }
		public bool OIFileIdMapped { get; set; }
		public string OIFileTypeColumnName { get; set; }
		public string ParentObjectIdSourceFieldName { get; set; }
	}
}