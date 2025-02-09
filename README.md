
## Introduction

This project is designed according to the Clean Architecture approach and consists of three main solution folders: API, Core and Infrastructure.

The API folder contains the API layer that manages communication with clients by processing HTTP requests.

The Core folder consists of Application and Domain layers, which contain business rules and application logic. While the Domain layer contains pure business rules and entities, the Application layer manages the business logic by applying these rules.

The Infrastructure folder contains the Bus, Caching and Persistence layers, which contain details about the infrastructure. While Persistence manages data access; Caching; caching operations; Manages bus, messaging and event-based architecture components.

This structure allows dependencies to progress from outer layers to inner layers, allowing the code to be more modular, maintainable and testable.

## Start

To get the application up and running, the appropriate .NET 8 SDK version must be installed, and a suitable database should be created using migrations.

To get a RabbitMQ instance, you need to create one through CloudAMQP.

## Dependencies

| Name                                 | Category           | Version     |
|--------------------------------------|--------------------|-------------|
| AutoMapper                           | Mapping            | 13.0.1      |
| FluentValidation.AspNetCore          | Validation         | 11.3.0      |
| MassTransit.AspNetCore               | Event Bus          | 7.3.1       |
| MassTransit.RabbitMQ                 | Event Bus          | 8.2.5       |
| Microsoft.EntityFrameworkCore        | ORM                | 8.0.8       |
| Microsoft.EntityFrameworkCore.Design | ORM                | 8.0.8       |
| Microsoft.EntityFrameworkCore.SqlServer | ORM             | 8.0.8       |
| Microsoft.EntityFrameworkCore.Tools  | ORM                | 8.0.8       |
| Swashbuckle.AspNetCore               | API Documentation  | 6.6.2       |