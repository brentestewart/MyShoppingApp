# MCP Servers

This document defines which MCP (Model Context Protocol) servers the AI should be able to interact with in order to support development activities. These servers provide additional context, data, or functionality that the AI can use to enhance the app generation experience.

## Tasks
These servers are a dependency for other tasks, so they should appear near the top of any aggregate task lists.

-  [ ] Verify access to the **GitHub** MCP Server
    - **Command:** `run get_me - github (MCP Server)`
    - **Purpose:** Ensures AI has access to git hub data.

  -  [ ] Verify access to the **Supabase** MCP Server
    - **Command:** `run list_projects - supabase (MCP Server)`
    - **Purpose:** Confirms access to Supabase data.

  -  [ ] Verify access to the **Context7** MCP Server
    - **Command:** `run resolve-library-id - Context7 (MCP Server)`
    - **Purpose:** Confirms connectivity to the Context7 documentation.

## Notes

- These verification steps should be completed as part of the AI initialization process.
- If a command fails, the AI should stop and report the failure to the user.
