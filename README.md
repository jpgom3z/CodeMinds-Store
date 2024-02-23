Store Project

Welcome to the Store Project repository! This project is a comprehensive solution for managing a store, including a database powered by MSSQL, a robust API built with .NET Core 7, a dynamic Store Admin interface developed with Angular and TypeScript, and an intuitive Storefront also built with Angular and TypeScript.
Technologies Used

    Database (DB): MSSQL
    API: .NET Core 7
    Store Admin: Angular, TypeScript
    Storefront: Angular, TypeScript

Features

    Database (DB):
        Efficiently manages and organizes store data using MSSQL.
        Provides a solid foundation for the API to interact with.

    API:
        Developed using the latest .NET Core 7, ensuring performance and security.
        Offers a range of endpoints to interact with the store data.
        Follows RESTful principles for a clean and intuitive API design.

    Store Admin:
        Angular-based administrative interface.
        Allows store administrators to manage products, categories, and other store-related data.
        Secure authentication and authorization mechanisms.

    Storefront:
        Angular-based user interface for customers.
        Provides a seamless shopping experience with intuitive navigation.
        Integration with the API for real-time product updates and inventory management.

Getting Started

To get started with the Store Project, follow these steps:

    Clone the Repository:

    bash

git clone https://github.com/your-username/store-project.git

Database Setup:

    Set up a MSSQL database and update the connection string in the API configuration.

API Setup:

    Navigate to the API directory and run:

    bash

    dotnet restore
    dotnet build
    dotnet run

Store Admin Setup:

    Navigate to the Store Admin directory and run:

    bash

    npm install
    ng serve

Storefront Setup:

    Navigate to the Storefront directory and run:

    bash

npm install
ng serve
