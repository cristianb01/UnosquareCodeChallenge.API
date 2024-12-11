UnosquareCodeChallenge (Cristian Bedoya Vargas)

1. Go to the root of the solution, open the file appsettings.json and update the "ConnectionString" value to your corresponding database connection string.

2. Please go to the root of the solution and run the following command:
   dotnet ef database update  --startup-project .\UnosquareCodeChallenge.Api\  --project .\UnosquareCodeChallege.Persistence\

2. Go to the project named "UnosquareCodeChallenge.Api" and run the following command:
   dotnet run
   The .Net application should now be running and connected to the database you specified.
