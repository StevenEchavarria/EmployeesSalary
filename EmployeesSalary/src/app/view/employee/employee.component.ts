import { Component, OnInit, OnDestroy } from "@angular/core";
import { Subscription } from "rxjs";
import { FormGroup, FormBuilder } from "@angular/forms";
import { EmployeeViewModel } from './employee.view-model';
import { EmployeeUseCaseService } from 'src/app/domain/usecase/employee/employee.service';
import { AlertifyService } from 'src/app/infraestructure/common/alertify.service';



@Component({
  selector: "app-employee",
  templateUrl: "./employee.component.html",
  styleUrls: ["./employee.component.scss"]
})
export class EmployeeComponent implements OnInit, OnDestroy {
  public form: FormGroup;
  public columns: any[];
  public employeeViewModel: EmployeeViewModel = this.initViewModel();
  private employeesSubscripcion: Subscription = new Subscription();
  private employeesByIdSubscripcion: Subscription = new Subscription();

  constructor(
    private employeeService: EmployeeUseCaseService,
    private alertify: AlertifyService,
    private fb: FormBuilder
  ) {
    this.createForm();
    this.generateColumns();
  }

  ngOnInit() {

  }

  ngOnDestroy() {
    this.employeesSubscripcion.unsubscribe();
    this.employeesByIdSubscripcion.unsubscribe();
  }

  public searchEmployees() {
    if (this.filterHasValue()) {
      this.getEmployeeById(this.form.controls["employeeId"].value);
    } else {
      this.getAllEmployees();
    }
    this.employeeViewModel.showTableInfo = true;
  }

  public filterHasValue(): boolean {
    return this.form.controls["employeeId"].value != null &&
      this.form.controls["employeeId"].value != ''
  }

  /**
   * Get all employees
   */
  private getAllEmployees() {
    this.employeesSubscripcion = this.employeeService
      .getAllEmployees()
      .subscribe(
        response => {
          if (response) {            
            this.employeeViewModel.employeeResponse = [];
            this.employeeViewModel.employeeResponse = response;
          }
        },
        () => {
          this.alertify.error(this.employeeViewModel.messages.error.errorMessage);
        },
        () => {
          this.employeesSubscripcion.unsubscribe();
        }
      );
  }

  /**
   *Get employee by id
   */
  private getEmployeeById(employeeId: number) {
    this.employeesByIdSubscripcion = this.employeeService
      .getEmployeeById(employeeId)
      .subscribe(
        response => {
          if (response) {            
            this.employeeViewModel.employeeResponse = [];
            if (response.id != 0) {
              this.employeeViewModel.employeeResponse.push(response);
            } else {
              this.employeeViewModel.employeeResponse = [];
            }
          }
        },
        error => {
          this.employeeViewModel.employeeResponse = [];          
        },
        () => {
          this.employeesByIdSubscripcion.unsubscribe();
        }
      );
  }

  /**
   * Create fields for form
   */
  private createForm(): void {
    this.form = this.fb.group({
      employeeId: [null]
    });
  }

  /**
   * Generate columns for table
   */
  private generateColumns(): void {
    this.columns = [
      {
        field: this.employeeViewModel.messages.table.idField,
        header: this.employeeViewModel.messages.table.idHeader
      },
      {
        field: this.employeeViewModel.messages.table.nameField,
        header: this.employeeViewModel.messages.table.nameHeader
      },
      {
        field: this.employeeViewModel.messages.table.contractTypeNameField,
        header: this.employeeViewModel.messages.table.contractTypeNameHeader
      },
      {
        field: this.employeeViewModel.messages.table.hourlySalaryField,
        header: this.employeeViewModel.messages.table.hourlySalaryHeader
      },
      {
        field: this.employeeViewModel.messages.table.monthlySalaryField,
        header: this.employeeViewModel.messages.table.monthlySalaryHeader
      },
      {
        field: this.employeeViewModel.messages.table.calculatedAnualSalaryField,
        header: this.employeeViewModel.messages.table.calculatedAnualSalaryHeader
      }
    ];
  }

  /**
   * Init view model
   * */
  private initViewModel(): EmployeeViewModel {
    return new EmployeeViewModel(null, [], false);
  }
}
