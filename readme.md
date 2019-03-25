The StopWatcher Application is built using ASP.Net Core 2.1 and uses libraries like Bootstrap 4.1.3 and EntityFramework Core 2.  It is an E-commerce Application designed to demonstrate ASP.Net Core fundamental concepts.  The general idea of the StopWatcher is an app that uses trading platform APIs to implement trailing stop loss orders for open positions in users linked trading accounts.

- Clone the application from GitHub.
- Download and Install Visual Studio Community and Configure for the DotNetCore Development workspace.
- Make sure to download the .NET Core 2.1 SDK or runtime libraries
- Double Click the .sln file to open the project
- Hit "Play" to run

The ABCReport controller is configured to communicate with a database with the ABC Manufacturing Database Schema.  The connection string must be set prior to using the report.  From the command line:
`dotnet user-secrets set "ConnectionStrings:ABCconnection" "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ABC_Manufacturing;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"`
