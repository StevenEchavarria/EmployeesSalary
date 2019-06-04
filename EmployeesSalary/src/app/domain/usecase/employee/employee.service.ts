import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { EmployeeGatewayAbstract } from '../../models/gateway/employee-gateway.abstract';
import { Employee } from '../../models/entity/Employee';

@Injectable()
export class EmployeeUseCaseService {
  constructor(private employeeService: EmployeeGatewayAbstract) { }

  public getAllEmployees(): Observable<Employee[]> {
    return this.employeeService.getAllEmployees().pipe();
  }

  public getEmployeeById(employeeId: number): Observable<Employee> {
    return this.employeeService.getEmployeeById(employeeId).pipe();
  }

}
