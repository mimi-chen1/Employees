import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { Employee } from '../models/employee.model';
import { EmployeeService } from './employee.service';

@Injectable({
  providedIn: 'root'
})
export class EmployeeDataService {

  constructor(private readonly employeeService: EmployeeService) {
    this.getEmployeeList()
  }

  private employeeSource = new BehaviorSubject<Employee[]>([]);
  employees = this.employeeSource.asObservable();
  employeesSourceBase: Employee[] = [];

  getEmployeeList() {
    this.employeeService.GetEmployeeList()
      .subscribe(
        (data: Employee[]) => {
          this.employeeSource.next(data);
          this.employeesSourceBase = data;
        },
        (error: any) => {
          console.log(error); // טיפול בשגיאות
        }
      );
  }

  fikterEmployeeList(search: string | null) {

    // תיבת החיפוש
    if (search === "" || search === null) {
      this.employeeSource.next(this.employeesSourceBase);
      return;
    }

    var result = this.employeesSourceBase.filter(employee => {
      return Object.values(employee).some(value =>
        value.toString().toLowerCase().includes(search.toLowerCase())
      );
    })
    this.employeeSource.next(result);
  }

}
