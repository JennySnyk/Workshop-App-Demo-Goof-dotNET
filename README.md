# Workshop App Demo - Goof (.NET Edition)

This is a deliberately vulnerable ASP.NET Core application designed for security demonstrations. It is a C#/.NET port of the original Node.js Goof app and the Java Goof app.

## Vulnerabilities Included

- **SAST Vulnerabilities**: A dozen common web application vulnerabilities.
- **SCA Vulnerabilities**: Dependencies with known vulnerabilities.
- **Container Vulnerabilities**: A `Dockerfile` using a known vulnerable base image.
- **IaC Misconfigurations**: Terraform files with common security flaws.

## Getting Started

### Prerequisites

- .NET SDK

### Running the Application

1. Clone the repository.
2. Run `dotnet run` in the project directory.
3. Open your browser to `http://localhost:5083` (or the port specified in the output).

## Screenshot

![Application Screenshot](screenshot.png)
