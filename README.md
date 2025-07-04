# Workshop App Demo - Goof (.NET Edition)

This is a deliberately vulnerable ASP.NET Core application designed for security demonstrations. It is a C#/.NET port of the original Node.js Goof app and the Java Goof app.

## Features

- **SAST Vulnerabilities**: A dozen common web application vulnerabilities.
- **SCA Vulnerabilities**: Dependencies with known vulnerabilities.
- **Container Vulnerabilities**: A `Dockerfile` using a known vulnerable base image.
- **IaC Misconfigurations**: Terraform files with common security flaws.

## Screenshot

![Application Screenshot](assets/screenshot.png)

## Getting Started

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download)

### Installation & Running the App

1.  **Clone the repository:**
    ```bash
    git clone https://github.com/JennySnyk/Workshop-App-Demo-Goof-dotNET.git
    ```
2.  **Navigate to the project directory:**
    ```bash
    cd Workshop-App-Demo-Goof-dotNET
    ```
3.  **Run the application:**
    ```bash
    dotnet run
    ```

The application will be available at `http://localhost:5083`.

## Vulnerability Details

Here are some of the vulnerabilities included in this application and how to trigger them:

*   **SQL Injection**
    *   **Route**: `/Vulnerabilities/Sqli`
    *   **How to trigger**: In the input form, enter the payload `' OR '1'='1` and submit. This will return all users from the database.

*   **Command Injection**
    *   **Route**: `/Vulnerabilities/CommandInjection`
    *   **How to trigger**: In the input form, enter an IP address followed by a command, like `8.8.8.8; ls`. The output of the `ls` command will be displayed on the page.

*   **Path Traversal**
    *   **Route**: `/Vulnerabilities/PathTraversal`
    *   **How to trigger**: Add the query parameter `?file=../../appsettings.json` to the URL. The application will read and display the contents of the `appsettings.json` file.

*   **Cross-Site Scripting (XSS)**
    *   **Route**: `/Vulnerabilities/Xss`
    *   **How to trigger**: Add the query parameter `?Query=<script>alert('XSS!')</script>` to the URL. This will execute the script and cause an alert box to appear.

*   **Vulnerable Dependencies (SCA)**
    *   The project includes several dependencies with known vulnerabilities. These can be detected by running a Snyk Open Source scan using the `dotnet` integration.

*For a full list of all vulnerabilities, please inspect the source code in the `/Pages/Vulnerabilities` directory.*

## Disclaimer

**This application is for educational and demonstration purposes only. Do not deploy it in a production environment.**
