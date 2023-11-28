import { AdminModule } from './module/admin/admin.module';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LayoutComponent } from './layout/layout.component';
import { LoginComponent } from './auth/login/login.component';
import { RegisterComponent } from './auth/register/register.component';
import { AuthGuard } from './helper/auth.guard';
import { PasswordDownloadComponent } from './auth/password-download/password-download.component';

const routes: Routes = [
  {
    path: '',
    redirectTo: '/login',
    pathMatch: 'full',
  },
  { path: 'login', component: LoginComponent },
  { path: 'rigister', component: RegisterComponent },
  { path: 'downloadPassword', component: PasswordDownloadComponent },
  {
    path: 'dashboard',
    component: LayoutComponent,
    canActivate: [AuthGuard],
    children: [
      {
        path: 'user',
        loadChildren: () =>
          import('./module/user/user.module').then((m) => m.UserModule),
        canActivate: [AuthGuard],
      },
      {
        path: 'admin',
        loadChildren: () =>
          import('./module/admin/admin.module').then((m) => m.AdminModule),
        canActivate: [AuthGuard],
      },
      {
        path: 'superAdmin',
        loadChildren: () =>
          import('./module/super-admin/super-admin.module').then(
            (m) => m.SuperAdminModule
          ),
        canActivate: [AuthGuard],
      },
      {
        path: 'agent',
        loadChildren: () =>
          import('./module/agent/agent.module').then((m) => m.AgentModule),
        canActivate: [AuthGuard],
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { useHash: true })],
  exports: [RouterModule],
})
export class AppRoutingModule {}
