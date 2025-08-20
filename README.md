
# DoTogether

DoTogether is a collaborative project management platform designed to help teams organize workspaces, projects, and tasks efficiently. It combines a modern Angular frontend with a robust ASP.NET Core backend.

## How to Start the App

### 1. Start the Server (Backend)

**Requirements:**
- .NET 8 SDK
- SQL Server (or update the connection string in `appsettings.json`)

**Steps:**
1. Open a terminal and navigate to the backend folder:
   ```powershell
   cd Server/DoTogetherServer/DoTogetherDatabase
   ```
2. Restore dependencies:
   ```powershell
   dotnet restore
   ```
3. (Optional) Apply database migrations:
   ```powershell
   dotnet ef database update
   ```
4. Start the server:
   ```powershell
   dotnet run
   ```
5. The API will be available at `http://localhost:5000` (or your configured port).

### 2. Start the Client (Frontend)

**Requirements:**
- Node.js & npm

**Steps:**
1. Open a new terminal and navigate to the client folder:
   ```powershell
   cd Client
   ```
2. Install dependencies:
   ```powershell
   npm install
   ```
3. Start the Angular app in development mode:
   ```powershell
   npm start
   ```
   Or for SSR (Server-Side Rendering):
   ```powershell
   npm run dev:ssr
   ```
4. The frontend will be available at `http://localhost:4200`.

### 3. API Proxy
Angular uses `proxy.conf.json` to route API calls to the backend, so you don't need to change URLs in the frontend code.

## App Functionality & Architecture

### Main Features
- **User Authentication:** Register and log in with JWT-based authentication.
- **Workspaces:** Organize projects under workspaces (currently hardcoded for simplicity).
- **Projects:** Create, view, and manage your own projects.
- **Tasks:** Add tasks to projects, assign, comment, like/dislike, and track progress.
- **Comments & Reactions:** Collaborate by commenting and reacting to tasks.
- **SSR Support:** Angular SSR for improved SEO and performance.

### How It Works
- The backend exposes RESTful API endpoints for users, projects, tasks, comments, etc.
- The frontend communicates with the backend via HttpClient, using JWT for secure requests.
- The app uses Angular routing for navigation and guards for route protection.
- Data models are shared between backend DTOs and frontend TypeScript interfaces for consistency.
- AutoMapper in the backend maps DTOs to database models.
- The workspace ID is currently hardcoded for demo/testing; future versions will allow dynamic workspace management.

### Project Structure
```
Client/        # Angular frontend
Server/        # ASP.NET Core backend
```

#### Client (Angular)
- `src/app/` - Main Angular app code
- `auth/` - Authentication (login, register, service, guard)
- `projects/` - Project list, create, details, members
- `tasks/` - Task list, create, details
- `styles.css` - Global styles
- `app.config.ts` - Angular app configuration
- `app.routes.ts` - Routing setup

#### Server (ASP.NET Core)
- `DoTogetherServer/DoTogetherDatabase/` - Main API project
- `Controllers/` - API endpoints (Users, Projects, Tasks, etc.)
- `DTOs/` - Data Transfer Objects
- `Models/` - Database models
- `Mapping/` - AutoMapper profiles
- `Services/` - Business logic

## The Idea Behind DoTogether

DoTogether is built to help teams and individuals:
- Organize work into workspaces and projects
- Assign and track tasks collaboratively
- Communicate through comments and reactions
- Ensure secure access and data integrity
- Support future extensibility (roles, notifications, chat, integrations)

The architecture is modular, making it easy to add new features and scale for larger teams.

## What Else Can Be Developed?

- **Workspace Management:** Allow users to create and join multiple workspaces.
- **User Roles & Permissions:** Add admin, member, and guest roles for granular access control.
- **Notifications:** Real-time notifications for task updates, comments, and mentions.
- **Chat & Collaboration:** Integrate chat rooms for project discussions.
- **File Attachments:** Allow uploading and sharing files on tasks and comments.
- **Activity Log:** Track all actions for auditing and transparency.
- **Advanced Task Management:** Subtasks, deadlines, priorities, and Kanban boards.
- **Integrations:** Connect with external tools (Slack, email, calendar, etc.).
- **Mobile App:** Build a mobile version for on-the-go access.
- **Better SSR/SEO:** Enhance SSR for public project pages and search engine visibility.

## Notes
- Visual Studio `.vs/` folder is excluded from git.
- Line ending warnings for `package.json` are normal on Windows.
- For SSR/localStorage issues, see `auth.guard.ts` and SSR-safe code.

## Contributing
Pull requests are welcome. For major changes, please open an issue first.

## License
MIT
