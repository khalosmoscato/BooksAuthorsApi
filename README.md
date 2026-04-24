# Books and Authors API

A RESTful Web API built with **ASP.NET Core 10** demonstrating the **Model-View-Controller (MVC)** architectural pattern. 

## 🏗️ Architecture
This project follows a 4-tier layered architecture to ensure a clean **Separation of Concerns**:

* **Controllers**: Handle HTTP requests and responses.
* **Services**: Manage business logic, data transformation, and validation.
* **Models (Data Layer)**: Manage data persistence and retrieval from JSON resources.
* **Resources**: Static JSON files acting as the mock data store.

## 🛠️ Tech Stack
* **.NET 10.0**
* **ASP.NET Core Web API**
* **C#**
* **System.Text.Json** for data serialisation

## 🚀 Getting Started

### Prerequisites
* Visual Studio 2026
* .NET 10 SDK
* PowerShell 7+

### Installation & Run
1. Clone the repository:
   ```powershell
   git clone [https://github.com/khalosmoscato/BooksAuthorsApi.git](https://github.com/khalosmoscato/BooksAuthorsApi.git)
   ```
2. Navigate to the project directory:
   ```powershell
   cd cs-mvc-books-authors
   ```
3. Restore dependencies and run the application:
   ```powershell
   dotnet restore
   dotnet run --project BooksAuthorsApi.Api
   ```

## 🛤️ Endpoints (In Progress)

## ✅ Testing
To ensure reliability, endpoints are tested directly within **Visual Studio 2026** using the **Endpoints Explorer** and `.http` files. This allows for rapid verification of HTTP status codes and JSON response bodies.

![API Testing in Visual Studio](./docs/api-testing-vs.png)

### Authors
- `GET /api/authors` - Retrieve all authors with basic details.
- `GET /api/authors/{id}` - Retrieve a specific author by their unique ID.
- `POST /api/authors` - Add a new author to the system.
- `DELETE /api/authors/{id}` - Remove an author from the records.

### Books
- `GET /api/books` - Retrieve all books including associated author details.
- `GET /api/books/{id}` - Retrieve a specific book by its ID.
- `POST /api/books` - Add a new book (includes validation of AuthorId).
- `DELETE /api/books/{id}` - Remove a book from the records.
- `GET /api/books/author/{authorId}` - Retrieve all books written by a specific author.

## 🏛️ Project Structure
The solution is organised into distinct layers to demonstrate MVC principles:
- **Controllers**: Entry points for HTTP traffic.
- **Services**: Domain-specific logic and data orchestration.
- **Models**: Data definitions and repository-style JSON access.
- **Resources**: Persistent storage using JSON files.

## 📄 License
This project is for educational purposes as part of the software engineering bootcamp curriculum.