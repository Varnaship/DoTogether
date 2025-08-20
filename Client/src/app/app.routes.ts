import { Routes } from '@angular/router';
import { TaskList } from './tasks/task-list/task-list';
import { TaskDetails } from './tasks/task-details/task-details';
import { TaskCreate } from './tasks/task-create/task-create';
import { TaskEdit } from './tasks/task-edit/task-edit';
import { Login } from './auth/login/login';
import { Register } from './auth/register/register';
import { NotFound } from './not-found/not-found';
import { AuthGuard } from './auth/auth.guard';
import { GuestGuard } from './guest.guard';
import { ProjectList } from './projects/project-list/project-list';
import { ProjectDetails } from './projects/project-details/project-details';
import { ProjectCreate } from './projects/project-create/project-create';
import { ProjectEdit } from './projects/project-edit/project-edit';
import { ProjectMembers } from './projects/project-members/project-members';

export const routes: Routes = [
  { path: '', redirectTo: '/projects', pathMatch: 'full' },
  { path: 'projects', component: ProjectList },
  { path: 'projects/create', component: ProjectCreate, canActivate: [AuthGuard] },
  { path: 'projects/:id', component: ProjectDetails },
  { path: 'projects/edit/:id', component: ProjectEdit, canActivate: [AuthGuard] },
  { path: 'projects/:id/members', component: ProjectMembers, canActivate: [AuthGuard] },
  { path: 'tasks', component: TaskList, canActivate: [AuthGuard] },
  { path: 'tasks/:id', component: TaskDetails, canActivate: [AuthGuard] },
  { path: 'tasks/create', component: TaskCreate, canActivate: [AuthGuard] },
  { path: 'tasks/edit/:id', component: TaskEdit, canActivate: [AuthGuard] },
  { path: 'login', component: Login, canActivate: [GuestGuard] },
  { path: 'register', component: Register, canActivate: [GuestGuard] },
  { path: '**', component: NotFound }
]; 