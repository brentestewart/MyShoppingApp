This guide outlines best practices for working with Blazor, with a focus on maintainability, performance, and AI-assisted development. It applies to both Blazor Server and Blazor WebAssembly unless otherwise noted.

## 📝 Instructions

This document describes best practices and implementation strategies for creating Blazor applications. For consistency and maintainability, all projects should:

- Follow the design and structure outlined in this guide.    
- Use the [AI-Coding-Resources]([AI-Coding-Resources](https://github.com/brentestewart/AI-Coding-Resources)) repository for shared base viewmodels and components.
- Apply the coding and architecture practices described here.

## 📁 Folder Structure

A feature-based folder structure is recommended for scalability and clarity. Organize your code by domain features rather than technical type. Here is an example folder structure to use when adding files.

```
/Features
  /Orders
    OrderList.razor
    OrderDetails.razor
    OrderViewModel.cs
  /Users
    UserList.razor
    UserForm.razor
    UserViewModel.cs

/Shared
  Layout.razor
  NavMenu.razor
  MainLayout.razor
  /Components
    LoadingSpinner.razor
    ModalDialog.razor

/Core
  /ViewModels
	ViewModelComponentBase.cs
    ViewModelBase.cs

/App
  App.razor
  Program.cs

/wwwroot
  css/
  js/
```

### ✅ Guidelines

- Co-locate `.razor`, `.razor.cs`, and `.razor.css` files to keep components together.
- Name components with a `FeatureAction` format (e.g., `OrderEdit.razor`).
- Shared components and utilities should live in `/Shared` or `/Core` as appropriate.
- Avoid overly deep hierarchies—keep nesting shallow and purposeful.
- Keep test files in parallel folder trees, such as `/Tests/Features/Orders/OrderListTests.cs`.
## ✅ Tasks
*  [ ] Create the Blazor folder structure in the blazor app
*  [ ] Add the ServiceFailureSeverity class to the shared/core https://raw.githubusercontent.com/brentestewart/AI-Coding-Resources/refs/heads/main/code/blazor/ServiceFailureSeverity.cs
*  [ ] Add the ViewModelComponentBase.cs file to the blazor app https://raw.githubusercontent.com/brentestewart/AI-Coding-Resources/refs/heads/main/code/blazor/ViewModelComponentBase
*  [ ] Add the ViewModelBase.cs file to the blazor app https://raw.githubusercontent.com/brentestewart/AI-Coding-Resources/refs/heads/main/code/blazor/ViewModelBase

## 🧱 Component Design

- ✅ Favor **small, focused components** that encapsulate one UI concept or behavior
- ✅ Use `@code` blocks not partial class files
- ✅ Use `RenderFragment` for reusable layout and templated components
- ✅ Use `EventCallback<T>` instead of `Action` or custom delegates for events
- ❌ Avoid deeply nested component hierarchies — flatten where possible

## 📦 Code Organization

- ✅ Organize components by feature, not layer (e.g., `Features/Todos/TodoList.razor`)
- ✅ Co-locate `.razor`, `.razor.cs`, and `.razor.css` files
- ✅ Use `@page` only in top-level routing components

## 🧠 Parameters and State

- ✅ Use `[Parameter]` for parent-to-child communication
- ✅ Use cascading parameters sparingly and intentionally
- ✅ Avoid business logic in components — delegate to services
- ✅ Keep UI state in components; app state in services or state containers

## ⚙️ Dependency Injection

- ✅ Inject services using `@inject`
- ❌ Avoid injecting services directly into child components unless needed

## 🧪 Testing

- ✅ Extract logic into services or functions for unit testing
- ✅ Use `bUnit` for component tests
- ✅ Test inputs, outputs, and visual changes through markup

## ⚡ Performance

- ✅ Use `OnParametersSetAsync` instead of `OnInitializedAsync` when parameters may change
- ✅ Mark event handlers as `async` even if not currently `await`ing
- ✅ Avoid `StateHasChanged()` unless absolutely necessary
- ✅ Use `ShouldRender()` override for rendering optimizations
- ✅ Use `@key` when rendering lists to prevent unwanted DOM changes

## 🌐 Blazor Server Specific

- ✅ Minimize use of large models in SignalR updates
- ✅ Use `CircuitHandler` to monitor connection state
- ✅ Handle disconnected/reconnected scenarios gracefully

## 🔋 Blazor WebAssembly Specific

- ✅ Keep assemblies small and use lazy loading for large features
- ✅ Avoid synchronous JS interop
- ✅ Use compression and AOT where applicable

## 🤖 AI-Friendly Patterns

- ✅ Favor clear structure over cleverness — AI tools benefit from consistency
- ✅ Avoid ambiguous or overly abstract component designs
- ✅ Comment components with purpose and usage, not just mechanics

## 📎 Resources

- [Official Blazor Docs](https://learn.microsoft.com/en-us/aspnet/core/blazor/)
