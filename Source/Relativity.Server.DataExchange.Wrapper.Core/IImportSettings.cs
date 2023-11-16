namespace Relativity.Server.DataExchange.Wrapper
{
	using System.Collections.Generic;
	using System.Text;

	/// <summary>
	/// Represents common import settings.
	/// </summary>
	public interface IImportSettings
	{
		string AuditLevel
		{
			get;
			set;
		}

		bool Billable
		{
			get;
			set;
		}

		bool CopyFilesToDocumentRepository
		{
			get;
			set;
		}

		string DataGridIDColumnName
		{
			get;
			set;
		}

		int DestinationFolderArtifactID
		{
			get;
			set;
		}

		bool? DisableExtractedTextEncodingCheck
		{
			get;
			set;
		}

		bool DisableUserSecurityCheck
		{
			get;
			set;
		}

		Encoding ExtractedTextEncoding
		{
			get;
			set;
		}

		bool ExtractedTextFieldContainsFilePath
		{
			get;
			set;
		}

		int IdentityFieldId
		{
			get;
			set;
		}

		bool LoadImportedFullTextFromServer
		{
			get;
			set;
		}

		int? MaximumErrorCount
		{
			get;
			set;
		}

		bool MoveDocumentsInAppendOverlayMode
		{
			get;
			set;
		}

		string NativeFileCopyMode
		{
			get;
			set;
		}

		IList<int> ObjectFieldIdListContainsArtifactId
		{
			get;
			set;
		}

		string OverlayBehavior
		{
			get;
			set;
		}

		string OverwriteMode
		{
			get;
			set;
		}

		string ParentObjectIdSourceFieldName
		{
			get;
			set;
		}

		string RelativityPassword
		{
			get;
			set;
		}

		string RelativityUsername
		{
			get;
			set;
		}

		string SelectedIdentifierFieldName
		{
			get;
			set;
		}

		bool SendEmailOnLoadCompletion
		{
			get;
			set;
		}

		long StartRecordNumber
		{
			get;
			set;
		}

		string WebServiceURL
		{
			get;
			set;
		}

		int WorkspaceId
		{
			get;
			set;
		}
	}
}