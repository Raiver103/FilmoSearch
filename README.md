<h1 align="center">FilmoSearch</h1>

Scalable, easily supported Web API project made using good practices on ASP.NET 7 with React client and IdentityServer4

![image](https://github.com/Raiver103/FilmoSearch/assets/80199038/9d44b4f9-f449-4e20-8734-f88c8a66ca3c)
 
![image](https://github.com/Raiver103/FilmoSearch/assets/80199038/af6bd2ac-8e83-4a30-b4e6-57f4ce02b7da)

My application demonstrates authentication and CRUD operations with Many-to-Many and One-to-Many relations

# Technical tools 
* ASP NET Core 7 
* MS SQL Server
* EF Core 7
* React app (typescript template)
* IdentityServer4
* XUnit
* Fluent Validation
* Automapper 
* Exception Middleware
* Swagger
* NSwag Studio

# Architecture
* Clean Architecture
* CQRS
* MediatR

# Features
* Versioning

# Models
* Film (Id, Title);
* Actor (Id, FirstName, LastName);
* Review (Id, Title, Description, Stars);
* ActorFilm (ActorId, Actor, FilmId, Film); 

# Relationships
* Several actors can play a role in one film;
* An actor can play roles in several films;
* Multiple reviews can be placed for one film;

# Prerequisites
* Install Visual Studio
    * During installation, ensure that the following are selected:
        * ASP.NET and web development.
        * Node.js development.
        * .NET desktop development.
* Install .NET 7 SDK
* Install IIS Server

# Running the solution
* FilmoSearch.sln -> run FilmoSearch.WebApi and FilmoSearch.Identity - backend
* filmosearch.frontend -> npm start - frontend
