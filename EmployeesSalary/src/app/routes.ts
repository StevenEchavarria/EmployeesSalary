import { Routes } from "@angular/router";
import { EmployeeComponent } from './view/employee/employee.component';


export const appRoutes: Routes = [
  { path: "home", component: EmployeeComponent },
  { path: "**", redirectTo: "home", pathMatch: "full" }
];
