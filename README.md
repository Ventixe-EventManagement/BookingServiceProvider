# BookingServiceProvider

## Overview

**BookingServiceProvider** is a microservice within the Ventixe event management system.  
Its primary responsibility is to handle creation, retrieval, updating, and deletion of user event bookings.

This service is designed to operate independently and communicates with other services, such as `EventServiceProvider`, via REST APIs.

---

## Features

- Create new bookings for users
- Retrieve a user’s personal bookings
- Update ticket quantities
- Cancel bookings
- Secured with JWT-based authentication
- Integration with Azure Key Vault for secret management
- Designed according to microservice principles

---

## Security

This microservice uses **JWT Bearer authentication**.

- JWT tokens are issued by the `AuthServiceProvider`.
- The service validates tokens using keys and issuer/audience stored in **Azure Key Vault**.

---

## Azure Key Vault Integration

All secrets (e.g., connection strings and JWT settings) are stored in **Azure Key Vault**. 
The Web App uses **system-assigned managed identity** to securely access these secrets at runtime.

> This setup ensures credentials are never exposed in code or configuration files.

---

### Secrets used:
| Secret Name                          | Purpose                         |
|--------------------------------------|----------------------------------|
| `ConnectionStrings--SqlConnection`   | Main SQL database connection     |
| `Jwt--Issuer`                        | JWT token issuer                 |
| `Jwt--Audience`                      | JWT audience                     |
| `Jwt--Secret`                        | JWT signing key                  |

---

## Technologies

- .NET 9
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- Azure Key Vault
- Azure App Services
- RESTful API architecture

---


