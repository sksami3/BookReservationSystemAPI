# Book Reservation System (BRS) API

Welcome to the Book Reservation System API! This API allows you to manage a simple book reservation system, providing endpoints for CRUD operations on books, reserving and releasing book reservations, and retrieving lists of reserved and available books.

## Technologies Used

- **.NET 6**
- **Database**: SQLite is used as the database, with a code-first approach and automatic migrations.

## Getting Started

To run the API locally, follow these steps:

### Prerequisites

- Install .NET 6 on your machine.
- Install Docker if you prefer to run the API in a container.

### Running with Docker

If you prefer to run the API in a Docker container, use the following commands:

1. Navigate to the root directory of the project in the terminal (where Dockerfile is located).
2. Build and run the Docker command:
   - `docker build -t local-dev .`
   - `docker run -p 8080:80 -it --rm local-dev`
3. Open your browser and navigate to [http://localhost:8080/swagger/index.html](http://localhost:8080/swagger/index.html) to access the Swagger UI.

## API Endpoints

### Author

- **GET /api/Author/GetAll**: Get a list of all authors.
- **GET /api/Author/Get/{id}**: Get details of a specific author.
- **POST /api/Author/Add**: Create a new author.
- **PUT /api/Author/Update**: Update details of a specific author.
- **DELETE /api/Author/Delete/{id}**: Delete a specific author.

### Books

- **GET /api/Book/GetAll**: Get a list of all books.
- **GET /api/Book/Get/{id}**: Get details of a specific book.
- **POST /api/Book/Add**: Create a new book.
- **PUT /api/Book/Update**: Update details of a specific book.
- **DELETE /api/Book/Delete/{id}**: Delete a specific book.

### Book Reservations

- **POST /api/Book/Reserve**: Reserve a book. Parameters: id (book ID), comment (reservation comment).
- **POST /api/Book/UnreserveBook**: Release the reservation of a book. Parameters: id (book ID).

### History

- **GET /api/ReservationHistory/Get/{bookId}**: Get the history for a specific book.

## Note

No authentication is needed for accessing the API. Feel free to explore and interact with the API using the Swagger UI. If you have any questions or encounter issues, please refer to the provided Docker command or contact the API developer (sksami4456@gmail.com). Enjoy using the Book Reservation System API!
