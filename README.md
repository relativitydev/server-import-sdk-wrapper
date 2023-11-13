# import-api-wrapper
Open Source Community:

While this is an open source project on the Relativity GitHub account, support is only available through the Relativity developer community. You are welcome to use the code and solution as you see fit within the confines of the license it is released under. However, if you are looking for support or modifications to the solution, we suggest reaching out to a Relativity Development Partner.

# usage
The solution consists of five projects: ImportPluginConsole, Relativity.DataExchange.Wrapper.Core, Relativity.DataExchange.Wrapper.Legacy, Relativity.DataExchange.Wrapper.Sdk, Relativity.DataExchange.Wrapper.Shared

Set the necessary properties and run the application. The application will upload an image and a native to the targeted workspace.

# ImportConnectionInfo

Set the properties to your environment in the ImportConnectionInfo object located in Program.CS

These include: 
  Password 
  UserName 
	UseRsaBearerToken 
	WebServiceUrl 
	WorkspaceId 
  
 # Configuring the Legacy Wrapper
 Add the appropriate versioned assemblies from your MSI SDK Import API folder to the Relativity.DataExchange.Wrapper.Legacy references.
