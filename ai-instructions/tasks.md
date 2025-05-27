# Aggregated Tasks

## 1. MCP Servers (Initialization)
These servers are a dependency for other tasks, so they should appear near the top of any aggregate task lists.

-  [x] Verify access to the **GitHub** MCP Server
    - **Command:** `run get_me - github (MCP Server)`
    - **Purpose:** Ensures AI has access to git hub data.

  -  [x] Verify access to the **Supabase** MCP Server
    - **Command:** `run list_projects - supabase (MCP Server)`
    - **Purpose:** Confirms access to Supabase data.

  -  [x] Verify access to the **Context7** MCP Server
    - **Command:** `run resolve-library-id - Context7 (MCP Server)`
    - **Purpose:** Confirms connectivity to the Context7 documentation.

---

## 2. Coding Standards
-  [x] Verify you have read and understood the contents of the `coding-standards-dot-net.md` document.

---

## 3. Source Control Setup
- [x] Create a new local Git repository for the project
- [x] Initialize the repository with a suitable `.gitignore` file
- [x] Add the .cursor directory to the `.gitignore` file if it exists
- [x] Create a `README.md` file with the project name and short description
- [x] Create an initial commit with the base project files
- [x] Create a new **private** GitHub repository (unless specified as public in the project description)
- [x] Link the local Git repository to the GitHub repository
- [x] Push the initial commit to GitHub
- [x] Confirm that the repository is accessible via GitHub

---

## 4. Architecture: Blazor Enterprise
*  [x] Create the .NET Solution file 
*  [x] Create the Shared .NET Class Library project
*  [x] Create the Infrastructure .NET Class Library project
*  [x] Create the Domain .NET Class Library project
*  [x] Create the Application .NET Class Library project
*  [x] Create the Web Blazor Web App using the settings listed in the [[app-description.md]] file use the BlazorBestPractices.md file for the file structure

---

## 5. Blazor Best Practices
*  [x] Create the Blazor folder structure in the blazor app
*  [x] Add the Severity class to the shared class library. Make sure to update the namespace for the new file. https://raw.githubusercontent.com/brentestewart/AI-Coding-Resources/refs/heads/main/code/blazor/Severity.cs
*  [x] Add the ServiceFailureException class to the shared class library. Make sure to update the namespace for the new file. https://raw.githubusercontent.com/brentestewart/AI-Coding-Resources/refs/heads/main/code/blazor/ServiceFailureException.cs
*  [x] Add the ServiceFailureSeverity class to the shared/core https://raw.githubusercontent.com/brentestewart/AI-Coding-Resources/refs/heads/main/code/blazor/ServiceFailureSeverity.cs
*  [x] Add the ViewModelComponentBase.cs file to the blazor app https://raw.githubusercontent.com/brentestewart/AI-Coding-Resources/refs/heads/main/code/blazor/ViewModelComponentBase
*  [x] Add the ViewModelBase.cs file to the blazor app https://raw.githubusercontent.com/brentestewart/AI-Coding-Resources/refs/heads/main/code/blazor/ViewModelBase

---

## 6. Supabase Storage Setup
- [x] Add the Supabase NuGet package to the project/layer that should directly access the data ([https://www.nuget.org/packages/supabase](https://www.nuget.org/packages/supabase))

## 6.5. Supabase Setup (Pre-DB Tasks)
- [x] Get all Supabase settings from the app description file.
- [x] Check to see if the project already exists in Supabase
- [x] If it doesn't exist, then create it. Prompt me for any passwords.

---

## 7. App Implementation Tasks (from app-description.md)

### A. 🗄️ Create DB Tasks
- [x] Create DB for User (fields: Name, Email, etc.)
- [x] Create DB for Group (fields: Name, Description, Members)
- [x] Create DB for Group Membership (join table: user_id, group_id, role, joined_at)
- [x] Create DB for Store (fields: Name, Description, Address, Website, Aisles, GroupId)
- [x] Create DB for Item (fields: Name, Description, Category, GroupId)
- [x] Create DB for ShoppingList (fields: Title, StoreId, GroupId, IsArchived)
- [x] Create DB for StoreItem (fields: StoreId, ItemId, Price, Aisle, Notes)

### B. 🧩 Model/Entity/DTO Tasks
- [x] Create Store model/entity
- [x] Define Store DTOs (Create, Update, Read, List)
- [x] Create Item model/entity
- [x] Define Item DTOs (Create, Update, Read, List)
- [x] Create StoreItem model/entity
- [x] Define StoreItem DTOs (Create, Update, Read, List)
- [x] Create ShoppingList model/entity
- [x] Define ShoppingList DTOs (Create, Update, Read, List)
- [x] Create Group model/entity
- [x] Define Group DTOs (Create, Update, Read, List)
- [x] Create User model/entity
- [x] Define User DTOs (Profile, Registration, etc.)

### C. ��️ Service Tasks
- [x] Implement Store service (CRUD logic)
- [x] Implement Item service (CRUD logic)
- [x] Implement StoreItem service (CRUD logic)
- [x] Implement ShoppingList service (CRUD logic, archive/unarchive)
- [x] Implement Group service (CRUD logic, manage members)
- [x] Implement User service (profile, registration, group membership)

### D. 🌐 API Endpoint Tasks
- [ ] Create API endpoints for Store CRUD
- [ ] Create API endpoints for Item CRUD
- [ ] Create API endpoints for StoreItem CRUD
- [ ] Create API endpoints for ShoppingList CRUD
- [ ] Create API endpoints for Group CRUD and membership
- [ ] Create API endpoints for User profile and group membership

### E. 🖥️ Blazor UI Tasks
- [x] Clean up the Blazor app and make sure to remove existing files that are not needed and move any files that are in the wrong location
- [x] Build Blazor page: Store List
- [x] Build Blazor page: Store Details
- [x] Build Blazor page: Create Store
- [x] Build Blazor page: Edit Store
- [x] Build Blazor page: Delete Store (with confirmation)
- [x] Add Store management to navigation/menu
- [ ] Build Blazor page: Item List
- [ ] Build Blazor page: Item Details
- [ ] Build Blazor page: Create Item
- [ ] Build Blazor page: Edit Item
- [ ] Build Blazor page: Delete Item
- [ ] Add Item management to navigation/menu
- [ ] Build Blazor component: Manage StoreItems within Store context
- [ ] Build Blazor component: Manage StoreItems within ShoppingList context
- [ ] Build Blazor page: Shopping List Overview (per group)
- [ ] Build Blazor page: Shopping List Details (with items)
- [ ] Build Blazor page: Create Shopping List
- [ ] Build Blazor page: Edit Shopping List
- [ ] Build Blazor page: Archive Shopping List
- [ ] Build Blazor page: Unarchive Shopping List
- [ ] Add ShoppingList management to navigation/menu
- [ ] Build Blazor page: Group List
- [ ] Build Blazor page: Group Details (members, lists)
- [ ] Build Blazor page: Create Group
- [ ] Build Blazor page: Edit Group
- [ ] Build Blazor page: Manage Group Members
- [ ] Add Group management to navigation/menu
- [ ] Build Blazor page: User Profile
- [ ] Build Blazor page: User Registration
- [ ] Build Blazor page: User Login (if not handled by external auth)
- [ ] Build Blazor page: Manage Group Memberships

### F. Scaffold Users CRUD pages (list, create, edit, delete) using DTOs
- [x] Scaffold Users CRUD pages (list, create, edit, delete) using DTOs
- [x] Add navigation to Users CRUD in the main menu
- [x] Ensure all user pages use @rendermode InteractiveServer for interactivity
- [x] Implement delete confirmation (using JavaScript confirm dialog)

---

## Other Completed Tasks
- [x] Secure Supabase config with appsettings/user-secrets
- [x] Clean DI setup 

---

## Blazor Web App Migration Tasks
- [ ] Create a new Blazor Web App project (dotnet new blazor)
- [ ] Add existing projects (Application, Domain, Infrastructure, Shared) to the new solution
- [ ] Add project references in the new Blazor Web App
- [ ] Move/copy custom pages and ViewModels to the new app
- [ ] Update namespaces in copied files
- [ ] Register services and ViewModels in Program.cs
- [ ] Add @rendermode InteractiveServer to interactive pages/components
- [ ] Build and test the new app
- [ ] Clean up old web project if desired 