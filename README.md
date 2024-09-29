# Hotel Reservation System

## Table of Contents

- [Overview](#overview)
- [Architecture](#architecture)
- [Modules](#modules)
- [Features](#features)
- [Technologies](#technologies)
- [Setup and Installation](#setup-and-installation)
- [Running the Application](#running-the-application)

## Overview

The Hotel Reservation System is built using ASP.NET Core, designed to handle hotel bookings, guest management, and room availability. It provides features similar to platforms like Booking.com, with a focus on efficient room management, guest check-ins, and user collaboration within hotel staff.

## Architecture

The system follows a layered architecture to maintain separation of concerns and ensure scalability and flexibility:
- **Mediator Layer**: It facilitates clean, decoupled communication between the controller and service layers, ensuring that business validation are enforced.
- **Service Layer**: Embedded within the mediator layer, this layer centralizes all the business logic, such as handling reservation requests, managing room availability, or validating guest data. It processes the application's core functionality and interacts with the repository layer for data access.
- **Repository Layer**: Manages all interactions with the database using Entity Framework Core. It abstracts data access logic from the service and controller layers, making the system more modular and testable.
- **Controller Layer**: Responsible for handling incoming HTTP requests from the client, validating them, and passing them on to the mediator/service layer.

## Modules

- **Bookings**: Create, update, and manage hotel reservations.
- **Guests**: Handle guest check-ins, check-outs, and profile management.
- **Rooms**: Manage room availability, types, and assignments.
- **User Management**: Role-based access control for hotel staff.

## Features

- **User Authentication and Authorization**: Role-based access for hotel staff members (staff, customer).
- **Room Booking Management**: Handles room availability, types, and statuses.
- **Guest Management**: Allows tracking of guest check-ins, histories, and personal details.
- **Reservation Cancellations**: Allows users to cancel or modify reservations.
- **Confirmation Email System**: Sends booking confirmations and cancellation emails to guests.
- **Role-based Permissions**: Different levels of staff access based on user roles.
- **Real-time Notifications**: Notify staff of new bookings, cancellations, or room status changes.
- **Booking Status Tracking**: Track reservations through various stages like pending, confirmed, or completed.
- **SOLID Principles**: Ensures the system is robust and maintainable with scalable architecture.

## Technologies
- **ASP.NET Core**: The main framework for building the Web API.
- **Entity Framework Core**: Manages database operations and migrations.
- **AutoFac**: Handles dependency injection for services.
- **AutoMapper**: Maps entities and DTOs efficiently.
- **SQL Server**: Manages data persistence.
- **Swagger**: Generates API documentation automatically for testing and integration.
- **Fluent Validation**: Validates inputs and business rules with clear error messaging.

## Setup and Installation
1. Clone the repository:
   ```bash
   git clone https://github.com/tarekredasaad/HotelReservation.git
   cd HotelReservation
2. Restore the .NET dependencies:
    ```bash
    dotnet restore
3. Configure the database connection string in appsettings.json:
    ```bash
    {
      "ConnectionStrings": {
      "DefaultConnection": "Server=.;Database=HotelReservation;Trusted_Connection=True;TrustServerCertificate=True;Encrypt=false"
      }
    }
    
## Database Migration
- Run the following command to apply the latest database migrations:
    ```bash
    dotnet ef database update

## Running the Application
- To run the application locally:
    ```bash
    dotnet run
