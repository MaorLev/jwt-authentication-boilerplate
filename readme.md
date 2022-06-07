# Api authentication boilerplate

A .Net 3.1 WebApi boilerplate / template project.

The goal of this project is to be a kickstart to your .Net WebApi, implementing the most common used patterns
and technologies for a restful API in .net, making your work easier and simple.


# Prerequisites
1. Use this template(github) or clone/download to your local workplace.
2. Download the .Net Core 3.1 SDK and Visual Studio.
3. Download the Microsoft SQL Server.

# How to run
Configure the appsettings.json file and adjust it to your settings.

## Run Migration and connect to SQL Server
In PMC (package manager Console) or Dotnet Sdk cli,
You have some commands options to run:

- Run current migration 
1. Update-Database

- Create new
1. Delete a manual migration file

2. Add-Migration "MyFirstInit" 

3. Update-Database -c DomainModelMsSqlServerContext

- or
1. dotnet restore

2. dotnet ef migrations add microsoftSql --context DomainModelMsSqlServerContext

3. dotnet ef database update --context DomainModelMsSqlServerContext


## Authentication
In this project, some routes requires authentication/authorization. For that, you will have to use the ``auth/login`` route to obtain the JWT.
As default, you have two users, Admin and normal user.
1. Student: 
	- email: admin@gmail.com
	- password: 123456
2. Admin:
	- email: shlomi@gmail
	- password: 1234
3. Create your own, create student by using  ``student/PostStudent`` route and pass this model :
    - string mail
    - string firstName
    - string lastName
    - string password
    - string studyStartYear
 
After Login, you can pass the jwt via the Authorization header on a http request.

# This project contains:
- EntityFramework
- FirstCode approach
- .Net Dependency Injection
- Authentication
- Authorization
- Inheritence Entities
- Linq quaries
- DTO (Data Transfer Object)
- Middleware

# About
This boilerplate/template was developed by Maor Levy.

