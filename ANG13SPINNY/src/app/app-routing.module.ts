import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PathnotfoundComponent } from './pathnotfound/pathnotfound.component';

const routes: Routes = [
  {
    path: 'Admin', 
    loadChildren: () => import('./Admin/admin.module').then(m => m.AdminModule)
  },
  {
    path: 'user', 
    loadChildren: () => import('./user/users.module').then(m => m.UsersModule)
  },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
