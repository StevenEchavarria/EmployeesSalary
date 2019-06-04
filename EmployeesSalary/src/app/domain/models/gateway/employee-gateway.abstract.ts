import { Observable } from 'rxjs';
import { Employee } from '../entity/Employee';

export abstract class EmployeeGatewayAbstract {
  abstract getAllEmployees(): Observable<Employee[]>;
  abstract getEmployeeById(employeeId: number): Observable<Employee>;
}
