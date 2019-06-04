import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { EmployeeGatewayAbstract } from 'src/app/domain/models/gateway/employee-gateway.abstract';
import { Employee } from 'src/app/domain/models/entity/Employee';
import { environment } from 'src/environments/environment';

@Injectable()
export class EmployeeService extends EmployeeGatewayAbstract {

  baseUrl = 'http://localhost:5000/api/';

  constructor(private http: HttpClient) {
    super();
  }

  getAllEmployees(): Observable<Employee[]> {
    return this.http.get<Employee[]>(`${this.baseUrl}employees/getAllEmployees`);
  }

  getEmployeeById(employeeId: number): Observable<Employee> {
    return this.http.get<Employee>(`${this.baseUrl}employees/getEmployeeById/${employeeId}`);
  }
}
