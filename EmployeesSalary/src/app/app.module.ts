import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { ButtonsModule } from "ngx-bootstrap";
import { TableModule } from "primeng/table";
import { InputTextModule } from "primeng/inputtext";
import { RouterModule } from '@angular/router';
import { appRoutes } from './routes';

import { AppComponent } from './app.component';
import { EmployeeComponent } from './view/employee/employee.component';
import { EmployeeService } from './infraestructure/employee/employee.service';
import { EmployeeUseCaseService } from './domain/usecase/employee/employee.service';
import { EmployeeGatewayAbstract } from './domain/models/gateway/employee-gateway.abstract';
import { AlertifyService } from './infraestructure/common/alertify.service';



@NgModule({
  declarations: [
    AppComponent,
    EmployeeComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    TableModule,
    InputTextModule,
    ButtonsModule.forRoot(),
    RouterModule.forRoot(appRoutes),
  ],
  providers: [
    {
      provide: EmployeeGatewayAbstract,
      useClass: EmployeeService
    },
    EmployeeService,
    EmployeeUseCaseService,
    AlertifyService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
