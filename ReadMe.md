
### used dotnet new webapi
for creating project


## current plan now
Set up and configure the SQL Server database locally
Verify the backend's connection to the database and implement any necessary migrations
Develop the Django frontend
Create individual Dockerfiles for each component
Finally, create the Docker Compose configuration to orchestrate all services

### Normally: command pallet .NET: new project

### need package
dotnet add package Microsoft.EntityFrameworkCore.SqlServer - provider for sql server
dotnet add package Microsoft.EntityFrameworkCore.Tools - ef command line tools
dotnet add package Microsoft.EntityFrameworkCore.Design - ef core design time features
dotnet add package Swashbuckle.AspNetCore - swagger


## helpful run commands
dotnet run => start project & show console output
dotnet watch run => restart project at every  code change
dotnet build => build project checks compilation errors
dotnet run --launch-profile "ProfileName" => run project with launch profile


## next step
proceed with implementing the data models and database context that correspond to these modules? This will establish the foundation for the SQL Server integration that will later be containerized with Docker.