# 🧭 Instructions for AI Setup

This file defines the expected setup and behavior for the AI assistant when initializing a new project. The instructions guide the AI on how to begin its support and what documents to reference.

The current application being built is described in [[app-description]].

All actionable steps must be derived from the aggregated `tasks.md` file, which is constructed by pulling `## Tasks` sections from the relevant guide documents.

---

## 📚 Guide Documents

These documents contain the standards, best practices, and architecture details relevant to the project:

- [coding-standards-dot-net.md](coding-standards-dot-net.md)
- [source-control.md](source-control.md)
- [architecture-blazor-enterprise.md](architecture-blazor-enterprise.md)
- [blazor-best-practices.md](blazor-best-practices.md)
- [supabse.md](supabase.md)
- [storage-supabase.md](storage-supabase.md)
- [app-description.md](app-description.md)
- [mcp-servers.md](mcp-servers.md)

---

## ✅ Initial Setup Steps

On first exposure to this repository, the AI should perform the following steps:

1. Verify that you have access to all the documents listed in this file. Do not proceed if you cannot read any of the listed files. Notify the user with which files are missing and stop all processing.

2. **Aggregate Tasks:**  
   - Collect all `## Tasks` sections from the guide documents listed above.
   - Organize all the tasks to be listed grouped in the order that the tasks must be ran in.
   - Combine them into a single `tasks.md` file.
   - Make sure the logical groups of tasks are numbered for easier reference.
   - Write that file to the same directory as the instructions.
   - Show the `tasks.md` file for user review.

3. **Pause for Review:**  
   - After generating `tasks.md`, **do not proceed with any scaffolding, coding, or automation**.
   - Wait for explicit user approval before continuing with implementation steps.

---

## 🧠 AI Execution Rules

- All AI-driven actions must come from the approved `tasks.md` file.
- Do not infer or execute steps that are not explicitly defined or approved by the user.
- When a task is completed, mark it as completed by placing an `x` between the `[ ]` brackets.
