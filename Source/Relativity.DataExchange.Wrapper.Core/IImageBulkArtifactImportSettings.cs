namespace Relativity.Server.DataExchange.Wrapper
{
	/// <summary>
	/// Represents image or production-based import settings.
	/// Implements the <see cref="Relativity.DataExchange.Wrapper.IImportSettings" />
	/// </summary>
	/// <seealso cref="Relativity.DataExchange.Wrapper.IImportSettings" />
	public interface IImageBulkArtifactImportSettings : IImportSettings
	{
		int ArtifactTypeId
		{
			get;
			set;
		}

		bool AutoNumberImages
		{
			get;
			set;
		}

		string BatesNumberField
		{
			get;
			set;
		}

		int BeginBatesFieldArtifactID
		{
			get;
			set;
		}

		bool? DisableImageLocationValidation
		{
			get;
			set;
		}

		bool? DisableImageTypeValidation
		{
			get;
			set;
		}

		string DocumentIdentifierField
		{
			get;
			set;
		}

		string FileLocationField
		{
			get;
			set;
		}

		bool ForProduction
		{
			get;
			set;
		}

		string ImageFilePathSourceFieldName
		{
			get;
			set;
		}

		int ProductionArtifactID
		{
			get;
			set;
		}

		string SelectedCasePath
		{
			get;
			set;
		}
	}
}