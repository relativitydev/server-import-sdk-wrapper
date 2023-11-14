namespace Relativity.Server.DataExchange.Wrapper
{
	internal class BulkArtifactImportSettings : ImportSettings, IBulkArtifactImportSettings
	{
		private readonly kCura.Relativity.DataReaderClient.Settings settings;

		public BulkArtifactImportSettings(kCura.Relativity.DataReaderClient.Settings settings)
			: base(settings)
		{
			this.settings = settings;
		}

		public int ArtifactTypeId
		{
			get => this.settings.ArtifactTypeId;
			set => this.settings.ArtifactTypeId = value;
		}

		public string BulkLoadFileFieldDelimiter
		{
			get => this.settings.BulkLoadFileFieldDelimiter;
			set => this.settings.BulkLoadFileFieldDelimiter = value;
		}

		public bool DisableControlNumberCompatibilityMode
		{
			get => this.settings.DisableControlNumberCompatibilityMode;
			set => this.settings.DisableControlNumberCompatibilityMode = value;
		}

		public bool DisableExtractedTextFileLocationValidation
		{
			get => this.settings.DisableExtractedTextFileLocationValidation;
			set => this.settings.DisableExtractedTextFileLocationValidation = value;
		}

		public bool? DisableNativeLocationValidation
		{
			get => this.settings.DisableNativeLocationValidation;
			set => this.settings.DisableNativeLocationValidation = value;
		}

		public bool? DisableNativeValidation
		{
			get => this.settings.DisableNativeValidation;
			set => this.settings.DisableNativeValidation = value;
		}

		public string FileNameColumn
		{
			get => this.settings.FileNameColumn;
			set => this.settings.FileNameColumn = value;
		}

		public string FileSizeColumn
		{
			get => this.settings.FileSizeColumn;
			set => this.settings.FileSizeColumn = value;
		}

		public bool FileSizeMapped
		{
			get => this.settings.FileSizeMapped;
			set => this.settings.FileSizeMapped = value;
		}

		public string FolderPathSourceFieldName
		{
			get => this.settings.FolderPathSourceFieldName;
			set => settings.FolderPathSourceFieldName = value;
		}

		public string LongTextColumnThatContainsPathToFullText
		{
			get => this.settings.LongTextColumnThatContainsPathToFullText;
			set => this.settings.LongTextColumnThatContainsPathToFullText = value;
		}

		public char MultiValueDelimiter
		{
			get => this.settings.MultiValueDelimiter;
			set => this.settings.MultiValueDelimiter = value;
		}

		public char NestedValueDelimiter
		{
			get => this.settings.NestedValueDelimiter;
			set => this.settings.NestedValueDelimiter = value;
		}

		public string NativeFilePathSourceFieldName
		{
			get => this.settings.NativeFilePathSourceFieldName;
			set => this.settings.NativeFilePathSourceFieldName = value;
		}

		public string OIFileIdColumnName
		{
			get => this.settings.OIFileIdColumnName;
			set => this.settings.OIFileIdColumnName = value;
		}

		public bool OIFileIdMapped
		{
			get => this.settings.OIFileIdMapped;
			set => this.settings.OIFileIdMapped = value;
		}

		public string OIFileTypeColumnName
		{
			get => this.settings.OIFileTypeColumnName;
			set => this.settings.OIFileTypeColumnName = value;
		}

		public string SupportedByViewerColumn
		{
#if WRAPPER_SDK
			get => this.settings.SupportedByViewerColumn;
			set => settings.SupportedByViewerColumn = value;
#else
			get
			{
				// Not supported.
				return string.Empty;
			}

			set
			{
				// Not supported.
			}
#endif
		}
	}
}