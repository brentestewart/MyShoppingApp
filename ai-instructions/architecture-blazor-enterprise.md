This document outlines the architectural approach for enterprise-grade Blazor applications. It emphasizes strong separation of concerns using a layered architecture pattern to ensure scalability, maintainability, and testability.

---

## 📝 Instructions

Use this guide to structure your Blazor app following clean architecture principles. This is suited for full-scale production systems and assumes the use of multiple projects for clear boundaries between concerns. Future clients (e.g., mobile, desktop) should be able to reuse Application and Domain layers without modification.

When starting a new project, the AI assistant will extract all `## ✅ Tasks` sections into a consolidated task list.

---

## ✅ Tasks
*  [ ] Create the .NET Solution file 
*  [ ] Create the Shared .NET Class Library project
*  [ ] Create the Infrastructure .NET Class Library project
*  [ ] Create the Domain .NET Class Library project
*  [ ] Create the Application .NET Class Library project
*  [ ] Create the Web Blazor Web App using the settings listed in the [[app-description.md]] file use the BlazorBestPractices.md file for the file structure

---

## 🔍 Layered Architecture Overview

```
Web (Blazor UI)
   ↓
Application (Use Cases, Service Interfaces)
   ↓
Domain (Entities, Value Objects, Domain Services)
   ↓
Infrastructure (EF Core, APIs, File I/O, etc.)
```

Each layer only depends on the layer directly below it or abstractions.

---

## 🎯 Layer Responsibilities

### **Web (Presentation Layer)**

- Blazor components, pages, and layout    
- Handles user interaction and display logic
- Uses ViewModels to bind to UI
- Delegates commands to the Application layer

### **Application Layer**

- Contains use case logic and application services
- Stateless and orchestrates business operations
- Defines interfaces (e.g., repositories, API access) that are implemented in Infrastructure
- Uses DTOs to move data between layers

### **Domain Layer**

- Contains core business rules and entities
- Defines domain services, aggregates, and value objects
- Pure C# classes with no dependencies on other layers

### **Infrastructure Layer**

- Implements application layer interfaces
- Provides data persistence (e.g., EF Core), external API calls, logging, etc.
- Uses dependency injection to register concrete implementations

---

## 🧱 Recommended Project Structure

```
/MyApp
  /Web             ← Blazor UI components
  /Application     ← Use cases, interfaces, DTOs
  /Domain          ← Core business logic
  /Infrastructure  ← Data access, external services
  /Shared          ← Common enums, constants, utilities
```

---

## 🧰 Technologies per Layer

|Layer|Technologies & Patterns|
|---|---|
|Web|Blazor, bUnit, ViewModels, Razor Components|
|Application|MediatR, FluentValidation, AutoMapper|
|Domain|Pure C# classes, domain-driven design (DDD)|
|Infrastructure|EF Core, Refit, HttpClient, Serilog, Polly|

---

## 🔒 Dependency Flow Rules

- `Web` → `Application`, `Shared`
- `Application` → `Domain`, `Shared`
- `Infrastructure` → `Application`, `Domain`, `Shared`
- `Domain` → `Shared`

Use interfaces to decouple Application and Infrastructure.

---

## 🧭 Summary

This architecture enables a clean, modular design that supports unit testing, easy maintenance, and flexibility to expand with new clients like mobile apps. Stick to the layering principles and dependency rules to avoid coupling and maintain the long-term health of your application.