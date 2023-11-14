namespace Relativity.Server.DataExchange.Wrapper
{
	using System;

	/// <summary>
	/// Represents the import connection information class object.
	/// Implements the <see cref="System.MarshalByRefObject" />
	/// </summary>
	/// <seealso cref="System.MarshalByRefObject" />
	public sealed class ImportConnectionInfo : MarshalByRefObject
	{
		/// <summary>
		/// Gets or sets the Relativity login username.
		/// </summary>
		/// <value>
		/// The name of the user.
		/// </value>
		public string UserName
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the Relativity login password.
		/// </summary>
		/// <value>
		/// The password.
		/// </value>
		public string Password
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets a value indicating whether to login using the Relativity Service Account (RSA).
		/// This is the recommended approach when importing data from an Agent or Custom Page but is only supported by the SDK.
		/// </summary>
		/// <value>
		/// <see langword="true" /> to login using the Relativity Service Account; otherwise, <see langword="false" />.
		/// </value>
		public bool UseRsaBearerToken
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the workspace artifact identifier.
		/// </summary>
		/// <value>
		/// The artifact identifier.
		/// </value>
		public int WorkspaceId
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the Relativity WebAPI service URL.
		/// </summary>
		/// <value>
		/// The URL.
		/// </value>
		public string WebServiceUrl
		{
			get;
			set;
		}
	}
}