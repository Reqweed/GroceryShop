# GroceryShop

GroceryShop is a web api that can be used to create an online shop.
The project is based on a three-tier architecture REST API principles on ASP.NET Core WEB Api 7.
It also implements authentication and authorisation were injected through the use of JWT tokens based on ASP.NET Core Identity.
It is possible to deploy the project in Docker.

## About this repository

- [Technologies](#technologies)
- [Installation](#installation)

## Technologies

| Category             | Name             | Version  |
|----------------------|------------------|----------|
| Platform             | .NET             | 7        |
| Programming language | C#               | 11       |
| IDE                  | Rider            | 2023.2.3 |
| Database             | PostgreSQL       | latest   |
| ORM                  | Entity Framework | 7.0.11   |
| Logger               | Serilog          | 8.0.1    |
| Mapper               | AutoMapper       | 13.0.1   |
| API Documentation    | Swagger          | 6.5.0    |
| Containerization     | Docker           | 24.0.6   |

## Installation

Steps to deploy the project in Docker:

1. Clone this repository.

        git clone https://github.com/Reqweed/GroceryShop.git

2. Move to the project folder.

        cd GroceryShop

3. Run docker-compose.

        docker-compose up -d --build

4. Application is available on port 8080 on your machine.

        http://localhost:8080

The Swagger is available at http://localhost:8080/swagger.