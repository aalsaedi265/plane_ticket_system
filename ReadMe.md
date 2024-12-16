
### used dotnet new webapi
for creating project

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