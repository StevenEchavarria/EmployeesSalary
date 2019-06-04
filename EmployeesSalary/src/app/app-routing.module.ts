import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { EmployeeComponent } from './view/employee/employee.component';

const routes: Routes = [];

export const appRoutes: Routes = [
  { path: "home", component: EmployeeComponent },
  { path: "**", redirectTo: "home", pathMatch: "full" }
];

@NgModule({
  imports: [RouterModule.forRoot(appRoutes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
