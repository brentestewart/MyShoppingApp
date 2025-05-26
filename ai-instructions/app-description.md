# 🗓 Project Description: Shopping List Application

## 🚀 Purpose

This project is a shopping list application designed to help users efficiently manage their shopping across multiple physical and online stores. It aims to simplify list organization, price comparison, and in-store navigation.

The application supports multiple users and allows for shared access through user-defined groups. For example, a family can create and manage a shared grocery list together.

---
## ⚙️ App Settings

| Setting           | Value            |
|-------------------|------------------|
| **App Name**      | My Shopping App  |
| **Solution Name** | MyShoppingApp    |
| **Git Repo Name** | MyShoppingApp    |
| **Git Repo Visibility** | public      |
| **Blazor App Project Template Settings** | template: Blazor Web App, Interactivity: Server Side Render, No sample pages |

---
## 🌍 Core Functionality

### 🧑‍🤝‍🧑 Users and Groups

- Users can belong to one or more **Groups**.
- Groups represent collections of users such as families, roommates, or friends.
- Shopping lists and stores can be associated with a group to enable sharing and collaboration.

### 🏰 Stores

Each store can represent a physical location or an online retailer. A store includes:

- `Name`: Display name of the store.
- `Description`: Short description of the store.
- `Address` (for physical stores):
    - Street
    - City
    - State/Province
    - ZIP/Postal Code    
    - Country
- `Website` (for online or hybrid stores): Optional URL.
- `Aisles`: Optional ordered list of aisle names or categories, useful for physical store navigation.

### 🍬 Items

Items represent general products that can be added to shopping lists. Items include:

- `Name`: The product name (e.g., "Milk", "USB Cable").
- `Description`: Optional additional details or notes.
- `Category`: General classification (e.g., Dairy, Electronics).

### 🏢 Store Items

Store-specific representation of an item, linked to both an Item and a Store. It includes:

- `ItemId`: Reference to the shared item definition.
- `StoreId`: Reference to the store.
- `Price`: Store-specific price.
- `Aisle`: Optional location or category within the store.
- `Notes`: Optional store-specific information.

### 📆 Shopping Lists

Users can maintain multiple shopping lists, each associated with a store. A list contains:

- `Title`: Name of the shopping list.
- `StoreId`: The store (or website) the list is for.
- `Items`: Collection of `StoreItems` linked to the list.
- `IsArchived`: Whether the list is active or archived.
- `GroupId`: (Optional) Reference to the group that owns the list.

---

## 📝 App Implementation Tasks (by Domain)

## 🗄️ Create DB Tasks
- [ ] Create DB for User (fields: Name, Email, etc.)
- [ ] Create DB for Group (fields: Name, Description, Members)
- [ ] Create DB for Store (fields: Name, Description, Address, Website, Aisles, GroupId)
- [ ] Create DB for Item (fields: Name, Description, Category, GroupId)
- [ ] Create DB for ShoppingList (fields: Title, StoreId, GroupId, IsArchived)
- [ ] Create DB for StoreItem (fields: StoreId, ItemId, Price, Aisle, Notes)

## 🧩 Model/Entity/DTO Tasks
- [ ] Create Store model/entity
- [ ] Define Store DTOs (Create, Update, Read, List)
- [ ] Create Item model/entity
- [ ] Define Item DTOs (Create, Update, Read, List)
- [ ] Create StoreItem model/entity
- [ ] Define StoreItem DTOs (Create, Update, Read, List)
- [ ] Create ShoppingList model/entity
- [ ] Define ShoppingList DTOs (Create, Update, Read, List)
- [ ] Create Group model/entity
- [ ] Define Group DTOs (Create, Update, Read, List)
- [ ] Create User model/entity
- [ ] Define User DTOs (Profile, Registration, etc.)

## 🛠️ Service Tasks
- [ ] Implement Store service (CRUD logic)
- [ ] Implement Item service (CRUD logic)
- [ ] Implement StoreItem service (CRUD logic)
- [ ] Implement ShoppingList service (CRUD logic, archive/unarchive)
- [ ] Implement Group service (CRUD logic, manage members)
- [ ] Implement User service (profile, registration, group membership)

## 🌐 API Endpoint Tasks
- [ ] Create API endpoints for Store CRUD
- [ ] Create API endpoints for Item CRUD
- [ ] Create API endpoints for StoreItem CRUD
- [ ] Create API endpoints for ShoppingList CRUD
- [ ] Create API endpoints for Group CRUD and membership
- [ ] Create API endpoints for User profile and group membership

## 🖥️ Blazor UI Tasks
- [ ] Clean up the Blazor app and make sure to remove existing files that are not needed and move any files that are in the wrong location
- [ ] Build Blazor page: Store List
- [ ] Build Blazor page: Store Details
- [ ] Build Blazor page: Create Store
- [ ] Build Blazor page: Edit Store
- [ ] Build Blazor page: Delete Store (with confirmation)
- [ ] Add Store management to navigation/menu
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

---
*These tasks are specific to implementing the Shopping List App after all foundational and infrastructure tasks are complete. Each domain includes DB schema, models, DTOs, services, API endpoints, and Blazor UI for full CRUD and management.*

