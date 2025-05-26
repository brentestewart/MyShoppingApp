## 🗄️ Storage Strategy — Supabase

This document outlines best practices, tasks, and structure for using **Supabase** as the backend storage solution in .NET-based applications. It guides the AI in setting up the `Infrastructure` project with Supabase integration, using the MCP server where applicable.

---

## 📝 Instructions

This setup document is used to provision, initialize, and integrate Supabase storage within a .NET project. The `✅ Tasks` section is designed to be parsed by the AI to scaffold the required configuration, setup, and service layer.

- The MCP server can be queried for environment-specific values such as `SUPABASE_URL`, `SUPABASE_ANON_KEY`, etc.
- Use the SDK interacting with Supabase.

---

## ✅ Tasks

- [ ] Add the Supabase NuGet package to the project/layer that should directly access the data ([https://www.nuget.org/packages/supabase](https://www.nuget.org/packages/supabase))


### 🔧 Supabase Setup

### 🧱 Infrastructure Project Configuration

### 🧪 Sample Integration Tasks

---

## 🗂 Recommended Folder Structure

```
/Infrastructure
  /Supabase
    SupabaseClientProvider.cs
    SupabaseStorageService.cs
    SupabaseExtensions.cs
```

---

## 🔒 Environment Variables (via MCP Server)

Use the MCP server for managing and retrieving environment-specific variables such as:
- `SUPABASE_URL`
- `SUPABASE_ANON_KEY`
- `SUPABASE_SERVICE_ROLE_KEY` (if needed for admin ops)

These values should be fetched during app initialization and injected into Supabase client constructors securely.

---

## 💡 Best Practices

- Encapsulate Supabase logic within service classes to avoid SDK leakage into the Application layer
- Separate concerns between `Storage`, `Auth`, and `Realtime` operations if applicable
- Use DTOs and domain models to transform data between layers
- Validate and sanitize data inputs/outputs rigorously
- Use async/await for all Supabase calls to avoid deadlocks

---

## 🧭 Summary

Supabase provides a scalable, hosted Postgres-based backend with RESTful and real-time capabilities. Integrating it through the Infrastructure layer ensures clean architecture and testable, modular design. Leverage the MCP server for secure configuration management and automate key setup tasks where possible.