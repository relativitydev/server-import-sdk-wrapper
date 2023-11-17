namespace Relativity.Server.DataExchange.Wrapper
{
	using System;

	/// <summary>
	/// Represents the plugin configuration class object. This class cannot be inherited.
	/// Implements the <see cref="System.MarshalByRefObject" />
	/// </summary>
	/// <seealso cref="System.MarshalByRefObject" />
	public sealed class PluginConfiguration : MarshalByRefObject
	{

		public PluginConfiguration()
		{
			// Not currently supported due to Aspera API 
			this.UseAppDomains = false;
			this.LegacyPluginDirectory = string.Empty;
			this.SdkPluginDirectory = string.Empty;

		}
		/// <summary>
		/// Determines whether or not AppDomains are used 
		/// Note: This is currently unsupported as there is an underlying issue with Aspera & App Domains
		/// </summary>
		/// <value>
		/// The full directory path.
		/// </value>
		public bool UseAppDomains
		{
			get;
			set;
		}
		/// <summary>
		/// Gets or sets the full path to the directory where the legacy plugin assemblies and binaries are located.
		/// </summary>
		/// <value>
		/// The full directory path.
		/// </value>
		public string LegacyPluginDirectory
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the full path to the directory where the SDK plugin assemblies and binaries are located.
		/// </summary>
		/// <value>
		/// The full directory path.
		/// </value>
		public string SdkPluginDirectory
		{
			get;
			set;
		}
	}
}