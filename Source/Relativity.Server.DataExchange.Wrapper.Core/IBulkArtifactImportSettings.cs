namespace Relativity.Server.DataExchange.Wrapper
{
	/// <summary>
	/// Represents document and object import settings.
	/// Implements the <see cref="Relativity.Server.DataExchange.Wrapper.IImportSettings" />
	/// </summary>
	/// <seealso cref="Relativity.Server.DataExchange.Wrapper.IImportSettings" />
	public interface IBulkArtifactImportSettings : IImportSettings
	{
		int ArtifactTypeId
		{
			get;
			set;
		}

		string BulkLoadFileFieldDelimiter
		{
			get;
			set;
		}

		bool DisableControlNumberCompatibilityMode
		{
			get;
			set;
		}

		bool DisableExtractedTextFileLocationValidation
		{
			get;
			set;
		}

		bool? DisableNativeLocationValidation
		{
			get;
			set;
		}

		bool? DisableNativeValidation
		{
			get;
			set;
		}

		string FileNameColumn
		{
			get;
			set;
		}

		string FileSizeColumn
		{
			get;
			set;
		}

		bool FileSizeMapped
		{
			get;
			set;
		}

		string LongTextColumnThatContainsPathToFullText
		{
			get;
			set;
		}

		char MultiValueDelimiter
		{
			get;
			set;
		}

		char NestedValueDelimiter
		{
			get;
			set;
		}

		string NativeFilePathSourceFieldName
		{
			get;
			set;
		}

		string OIFileIdColumnName
		{
			get;
			set;
		}

		bool OIFileIdMapped
		{
			get;
			set;
		}

		string OIFileTypeColumnName
		{
			get;
			set;
		}

		string SupportedByViewerColumn
		{
			get;
			set;
		}
	}
}