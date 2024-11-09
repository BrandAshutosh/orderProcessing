# Order Processing API

The Order Processing API is a backend service built with .NET 8 to manage orders, customers, and products in an e-commerce system. It provides endpoints for handling customer data, managing inventory, and processing orders. The API uses MySQL as the database, with Entity Framework Core as the ORM, and includes logging, testing, and API documentation via Swagger.

## Table of Contents

- [Features](#features)
- [Technologies Used](#technologies-used)
- [Prerequisites](#prerequisites)
- [Getting Started](#getting-started)
- [Database Setup](#database-setup)
- [Running the Application](#running-the-application)
- [API Documentation](#api-documentation)
- [Testing the Application](#testing-the-application)
- [Project Structure](#project-structure)
- [Troubleshooting](#troubleshooting)
- [Contribution](#contribution)
- [License](#license)

## Features

- **Customer Management**: CRUD operations for customers.
- **Product Management**: Manage the catalog of products.
- **Order Management**: Place and retrieve orders with multiple items.
- **API Documentation**: Interactive documentation with Swagger.
- **Logging**: Configured with Serilog for tracking API calls and errors.

## Technologies Used

- **.NET 8**: Framework for building the API.
- **Entity Framework Core**: ORM to connect to MySQL.
- **MySQL**: Database to store customer, order, and product data.
- **Swagger**: For API documentation.
- **Serilog**: Logging framework.
- **xUnit & Moq**: For unit testing services.

## Prerequisites

Ensure you have installed:

- **.NET SDK** (version 8.0 or higher)
- **MySQL Server** (local or remote)
- **Git** (for version control)

## Getting Started

1. **Clone the Repository**

   ```bash
   git clone https://github.com/BrandAshutosh/orderProcessing.git
   cd orderProcessing