import { messages as employeeMessages } from '../../utils/messages'
import { Employee } from 'src/app/domain/models/entity/Employee';


export class EmployeeViewModel {
  constructor(
    public messages: any,
    public employeeResponse: Employee[],
    public showTableInfo: boolean
  ) {
    this.messages = employeeMessages.employees;
  }
}
