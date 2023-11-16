namespace Relativity.Server.DataExchange.Wrapper
{
	using System;
	using System.Collections.Generic;
    using System.Globalization;
    using System.Text;

	internal class ImportSettings : MarshalByRefObject, IImportSettings
	{
		private readonly kCura.Relativity.DataReaderClient.ImportSettingsBase settings;

		public ImportSettings(kCura.Relativity.DataReaderClient.ImportSettingsBase settings)
		{
			this.settings = settings;
		}

		public string AuditLevel
		{
			get => this.settings.AuditLevel.ToString();
			set => settings.AuditLevel =
				GetEnumValue<kCura.EDDS.WebAPI.BulkImportManagerBase.ImportAuditLevel>(nameof(this.settings.AuditLevel),
					value);
		}

		public bool Billable
		{
			get => this.settings.Billable;
			set => settings.Billable = value;
		}

		public bool CopyFilesToDocumentRepository
		{
			get => this.settings.CopyFilesToDocumentRepository;
			set => settings.CopyFilesToDocumentRepository = value;
		}

		public string DataGridIDColumnName
		{
			get => this.settings.DataGridIDColumnName;
			set => settings.DataGridIDColumnName = value;
		}

		public int DestinationFolderArtifactID
		{
			get => this.settings.DestinationFolderArtifactID;
			set => settings.DestinationFolderArtifactID = value;
		}

		public bool? DisableExtractedTextEncodingCheck
		{
			get => this.settings.DisableExtractedTextEncodingCheck;
			set => settings.DisableExtractedTextEncodingCheck = value;
		}

		public bool DisableUserSecurityCheck
		{
			get => this.settings.DisableUserSecurityCheck;
			set => settings.DisableUserSecurityCheck = value;
		}

		public Encoding ExtractedTextEncoding
		{
			get => this.settings.ExtractedTextEncoding;
			set => settings.ExtractedTextEncoding = value;
		}

		public bool ExtractedTextFieldContainsFilePath
		{
			get => this.settings.ExtractedTextFieldContainsFilePath;
			set => settings.ExtractedTextFieldContainsFilePath = value;
		}

		public int IdentityFieldId
		{
			get => this.settings.IdentityFieldId;
			set => settings.IdentityFieldId = value;
		}

		public bool LoadImportedFullTextFromServer
		{
			get => this.settings.LoadImportedFullTextFromServer;
			set => settings.LoadImportedFullTextFromServer = value;
		}

		public int? MaximumErrorCount
		{
			get => this.settings.MaximumErrorCount;
			set => settings.MaximumErrorCount = value;
		}

		public bool MoveDocumentsInAppendOverlayMode
		{
			get => this.settings.MoveDocumentsInAppendOverlayMode;
			set => settings.MoveDocumentsInAppendOverlayMode = value;
		}

		public string NativeFileCopyMode
		{
			get => this.settings.NativeFileCopyMode.ToString();
			set => settings.NativeFileCopyMode =
				this.GetEnumValue<kCura.Relativity.DataReaderClient.NativeFileCopyModeEnum>(
					nameof(settings.NativeFileCopyMode), value);
		}

		public IList<int> ObjectFieldIdListContainsArtifactId
		{
			get => this.settings.ObjectFieldIdListContainsArtifactId;
			set => settings.ObjectFieldIdListContainsArtifactId = value;
		}

		public string OverlayBehavior
		{
			get => this.settings.OverlayBehavior.ToString();
			set => settings.OverlayBehavior = this.GetEnumValue<kCura.EDDS.WebAPI.BulkImportManagerBase.OverlayBehavior>(nameof(settings.OverlayBehavior), value);
		}

		public string OverwriteMode
		{
			get => this.settings.OverwriteMode.ToString();
			set => settings.OverwriteMode =
				this.GetEnumValue<kCura.Relativity.DataReaderClient.OverwriteModeEnum>(nameof(settings.OverwriteMode),
					value);
		}

		public string ParentObjectIdSourceFieldName
		{
			get => this.settings.ParentObjectIdSourceFieldName;
			set => settings.ParentObjectIdSourceFieldName = value;
		}

		public string RelativityPassword
		{
			get => this.settings.RelativityPassword;
			set => settings.RelativityPassword = value;
		}

		public string RelativityUsername
		{
			get => this.settings.RelativityUsername;
			set => settings.RelativityUsername = value;
		}

		public string SelectedIdentifierFieldName
		{
			get => this.settings.SelectedIdentifierFieldName;
			set => settings.SelectedIdentifierFieldName = value;
		}

		public bool SendEmailOnLoadCompletion
		{
			get => this.settings.SendEmailOnLoadCompletion;
			set => settings.SendEmailOnLoadCompletion = value;
		}

		public long StartRecordNumber
		{
			get => this.settings.StartRecordNumber;
			set => settings.StartRecordNumber = value;
		}

		public string WebServiceURL
		{
			get => this.settings.WebServiceURL;
			set => settings.WebServiceURL = value;
		}

		public int WorkspaceId
		{
			get => this.settings.CaseArtifactId;
			set => settings.CaseArtifactId = value;
		}

		protected TEnum GetEnumValue<TEnum>(string name, string value) where TEnum : struct
		{
			TEnum returnValue;
			if (Enum.TryParse(value, false, out returnValue))
			{
				return returnValue;
			}

			System.Diagnostics.Trace.TraceWarning(
				"Failed to convert the {0} enum setting value {1} to the {2} type.",
				name, value, typeof(TEnum));
			throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture,
				"The import job cannot be created because the the {0} setting defines value '{1}' that cannot be converted.",
				name, value));
		}
	}
}