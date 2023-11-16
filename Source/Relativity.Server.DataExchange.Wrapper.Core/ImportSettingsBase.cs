namespace Relativity.Server.DataExchange.Wrapper
{
	using System;
	using System.Collections.Generic;
	using System.Text;

	public class ImportSettingsBase : MarshalByRefObject
	{
		public int ArtifactTypeId
		{
			get;
			set;
		}

		public string AuditLevel
		{
			get;
			set;
		}

		public bool Billable
		{
			get;
			set;
		}

		public bool CopyFilesToDocumentRepository
		{
			get;
			set;
		}

		public int DestinationFolderArtifactID
		{
			get;
			set;
		}

		public bool? DisableExtractedTextEncodingCheck
		{
			get;
			set;
		}

		public bool DisableUserSecurityCheck
		{
			get;
			set;
		}

		public Encoding ExtractedTextEncoding
		{
			get;
			set;
		}

		public bool ExtractedTextFieldContainsFilePath
		{
			get;
			set;
		}

		public string FolderPathSourceFieldName
		{
			get;
			set;
		}

		public int IdentifyFieldArtifactId
		{
			get;
			set;
		}

		public bool LoadImportedFullTextFromServer
		{
			get;
			set;
		}

		public int? MaximumErrorCount
		{
			get;
			set;
		}

		public bool MoveDocumentsInAppendOverlayMode
		{
			get;
			set;
		}

		public string NativeFileCopyMode
		{
			get;
			set;
		}

		public IList<int> ObjectFieldIdListContainsArtifactId
		{
			get;
			set;
		}

		public string OverlayBehavior
		{
			get;
			set;
		}

		public string OverwriteMode
		{
			get;
			set;
		}

		public string SelectedIdentifierFieldName
		{
			get;
			set;
		}

		public bool SendEmailOnLoadCompletion
		{
			get;
			set;
		}

		public long StartRecordNumber
		{
			get;
			set;
		}

		public string SupportedByViewerColumn
		{
			get;
			set;
		}
	}
}