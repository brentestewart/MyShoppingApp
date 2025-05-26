These conventions are based on [Microsoft's official C# coding style](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions) with added project-specific preferences to promote clarity, testability, and AI compatibility.

# Tasks

-  [ ] Verify you have read and understood the contents of the `coding-standards-dot-net.md` document.

---

## ✨ Naming Conventions

|Element|Convention|Example|
|---|---|---|
|Class, Struct|PascalCase|`UserService`|
|Interface|PascalCase + I|`IUserService`|
|Method|PascalCase|`GetUserByIdAsync`|
|Variable|camelCase|`userCount`|
|Private Field|`_camelCase`|`_logger`|
|Constant|PascalCase|`MaxItems`|
|Enum Member|PascalCase|`UserStatus.Active`|
- Avoid Hungarian notation (e.g., `strName`)
- Use meaningful, descriptive names

## 📁 File and Folder Structure

- One top-level class per file
- Match file name to the primary class
- Organize by feature/module, not by layer

## 🧼 Layout and Formatting

- Use `file-scoped namespaces`
- Use braces `{}` even for single-line `if/else`
- Use blank lines between logical code blocks
- Prefer expression-bodied members for simple properties or methods only when they improve readability

## 🧠 Readability Over Cleverness

- Keep methods small and focused (1 responsibility)
- Favor early returns over nested `if` statements
- Use descriptive method and variable names

## 🤖 AI-Specific Practices

- Prefer **explicit types** over `var` unless the type is obvious
    
    ```
    var user = new User();       // ✅ Obvious
    var result = service.Get();  // ❌ Not obvious — use explicit type
    ```
    
- Summarize complex logic with comments
- Prefer code clarity over brevity when AI is generating examples
- Avoid ambiguous patterns when pasting prompts

## 🧪 Testable and Safe Code

- Use **nullable reference types** and enable nullability context
- Use `ArgumentNullException.ThrowIfNull()` for constructor or method arguments
- Favor dependency injection over static helpers
- Keep business logic in services, not controllers or components

## ⚙️ Async & Await

- Prefer `async/await` end-to-end
- Avoid blocking calls (`.Result`, `.Wait()`)

## 🛠 Tooling

- Adhere to `.editorconfig` or `dotnet format` rules
- Enable and respond to warnings (`TreatWarningsAsErrors = true`)
- Use analyzers (e.g., `Microsoft.CodeAnalysis.NetAnalyzers`)

## 📝 Comments and Documentation

- Use XML comments for public APIs, libraries, and shared code
- Document non-obvious decisions or business rules
- Avoid redundant comments:
    
    ```
    // Good
    // Return 404 if the user doesn't exist
    if (user is null) return NotFound();
    
    // Bad
    // Declare variable
    var x = 10;
    ```
    

## 🚫 Anti-Patterns to Avoid

- Don’t use magic strings — define constants or enums
- Don’t expose internal implementation through public APIs
- Don’t use regions (`#region`)

## 🔗 References

- [Microsoft C# Coding Conventions](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions)
- [Framework Design Guidelines](https://learn.microsoft.com/en-us/dotnet/standard/design-guidelines/)