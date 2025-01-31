
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


#### dotnet
Entity Framework Core tools. These tools are necessary for managing migrations and database updates in your .NET project

dotnet tool install --global dotnet-ef

dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.SqlServer



## next step
proceed with implementing the data models and database context that correspond to these modules? This will establish the foundation for the SQL Server integration that will later be containerized with Docker.

### python
py -m venv name_of_environment
.\name_of_environment\Scripts\activate  => activate environment
deactivate => deactivate environment

pip freeze > requirements.txt  => create requirements.txt with all installed packages

django-admin startproject core .  creates manage.py to connect to the c#

python manage.py runserver => start project & show console output great for checking errors

python manage.py migrate => apply database changes run this before runserver

python manage.py collectstatic => collect static files

#### http://localhost:5257/swagger/index.html
this lets you see the backend endpoints using swagger
Allos to trigger the endpoints like post delete put

### jwt
https://generate-secret.vercel.app/16
https://generate-secret.vercel.app/32 => generate secret key for jwt token 32 characters