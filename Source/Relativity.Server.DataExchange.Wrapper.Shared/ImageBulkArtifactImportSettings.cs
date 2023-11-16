namespace Relativity.Server.DataExchange.Wrapper
{
	using kCura.Relativity.DataReaderClient;

	internal class ImageBulkArtifactImportSettings : ImportSettings, IImageBulkArtifactImportSettings
	{
		private readonly ImageSettings settings;

		public ImageBulkArtifactImportSettings(ImageSettings settings)
			: base(settings)
		{
			this.settings = settings;
		}

		public int ArtifactTypeId
		{
			get => this.settings.ArtifactTypeId;
			set => this.settings.ArtifactTypeId = value;
		}

		public bool AutoNumberImages
		{
			get => this.settings.AutoNumberImages;
			set => this.settings.AutoNumberImages = value;
		}

		public string BatesNumberField
		{
			get => this.settings.BatesNumberField;
			set => this.settings.BatesNumberField = value;
		}

		public int BeginBatesFieldArtifactID
		{
			get => this.settings.BeginBatesFieldArtifactID;
			set => this.settings.BeginBatesFieldArtifactID = value;
		}

		public bool? DisableImageLocationValidation
		{
			get => this.settings.DisableImageLocationValidation;
			set => this.settings.DisableImageLocationValidation = value;
		}

		public bool? DisableImageTypeValidation
		{
			get => this.settings.DisableImageTypeValidation;
			set => this.settings.DisableImageTypeValidation = value;
		}

		public string DocumentIdentifierField
		{
			get => this.settings.DocumentIdentifierField;
			set => this.settings.DocumentIdentifierField = value;
		}

		public string FileLocationField
		{
			get => this.settings.FileLocationField;
			set => this.settings.FileLocationField = value;
		}

		public string FolderPathSourceFieldName
		{
			get => this.settings.FolderPathSourceFieldName;
			set => settings.FolderPathSourceFieldName = value;
		}

		public bool ForProduction
		{
			get => this.settings.ForProduction;
			set => this.settings.ForProduction = value;
		}

		public string ImageFilePathSourceFieldName
		{
			get => this.settings.ImageFilePathSourceFieldName;
			set => this.settings.ImageFilePathSourceFieldName = value;
		}

		public int ProductionArtifactID
		{
			get => this.settings.ProductionArtifactID;
			set => this.settings.ProductionArtifactID = value;
		}

		public string SelectedCasePath
		{
			get => this.settings.SelectedCasePath;
			set => this.settings.SelectedCasePath = value;
		}
	}
}