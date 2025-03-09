# Travel and Accommodation Booking Platform

## 📌 Overview

This project is a **Travel and Accommodation Booking Platform** that allows users to book accommodations and manage their reservations seamlessly. The system follows **Three-Tier Architecture** principles.

## Features

- **User Authentication & Authorization** (JWT-based)
- **Booking System**
- **Advanced Search Functionality**
- **Detailed Hotel Pages**

## Tech Stack

- **Backend:** ASP.NET Core
- **Database:** SQL Server
- **Infrastructure:** Three-Tier Architecture

## API Endpoints

### Authentication

| **Method** | **Endpoint**                 | **Description**                         |
| ---------- | ---------------------------- | --------------------------------------- |
| POST       | /api/authentication/login    | Logs in a user and returns a JWT token. |
| POST       | /api/authentication/register | Registers a new user.                   |

### Booking

| **Method** | **Endpoint**             | **Description**                   |
| ---------- | ------------------------ | --------------------------------- |
| POST       | /api/booking             | Creates a new booking.            |
| GET        | /api/booking             | Retrieves all bookings of a user. |
| DELETE     | /api/booking/{bookingId} | Deletes a specific booking by ID. |

### City

| **Method** | **Endpoint**         | **Description**                      |
| ---------- | -------------------- | ------------------------------------ |
| GET        | /api/cities          | Retrieves a list of all cities.      |
| POST       | /api/cities          | Adds a new city.                     |
| GET        | /api/cities/{id}     | Retrieves a specific city by its ID. |
| PUT        | /api/cities/{id}     | Updates an existing city by ID.      |
| DELETE     | /api/cities/{id}     | Deletes a specific city by ID.       |
| GET        | /api/cities/trending | Retrieves the top trending cities.   |

### Deal

| **Method** | **Endpoint** | **Description**     |
| ---------- | ------------ | ------------------- |
| POST       | /api/deals   | Creates a new deal. |

### Hotel

| **Method** | **Endpoint**                                 | **Description**                                      |
| ---------- | -------------------------------------------- | ---------------------------------------------------- |
| GET        | /api/hotels                                  | Retrieves a list of all hotels.                      |
| POST       | /api/hotels                                  | Adds a new hotel.                                    |
| GET        | /api/hotels/{id}                             | Retrieves a specific hotel by its ID.                |
| PUT        | /api/hotels/{id}                             | Updates an existing hotel by ID.                     |
| DELETE     | /api/hotels/{id}                             | Deletes a specific hotel by ID.                      |
| GET        | /api/hotels/filter                           | Filters hotels based on search criteria.             |
| GET        | /api/hotels/deals                            | Retrieves a list of hotels with active deals.        |
| GET        | /api/hotels/recently-visited-hotels/{userId} | Retrieves a list of recently visited hotels by user. |

### Room

| **Method** | **Endpoint**    | **Description**                      |
| ---------- | --------------- | ------------------------------------ |
| GET        | /api/rooms      | Retrieves a list of all rooms.       |
| POST       | /api/rooms      | Adds a new room.                     |
| GET        | /api/rooms/{id} | Retrieves a specific room by its ID. |
| PUT        | /api/rooms/{id} | Updates an existing room by ID.      |
| DELETE     | /api/rooms/{id} | Deletes a specific room by ID.       |
