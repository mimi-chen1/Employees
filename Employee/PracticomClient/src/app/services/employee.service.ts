import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Employee } from '../models/employee.model';
import { Observable } from 'rxjs';
import { EmployeePost } from '../models/employeePost.model';
import { EmployeeDataService } from './employee-data.service';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  constructor(private _http: HttpClient) {

  }
  GetEmployeeList() {
    return this._http.get<Employee[]>('http://localhost:7048/api/Employee');
  }
  AddEmployee(employee: EmployeePost): Observable<any> {
    employee.status = true;

    return this._http.post('http://localhost:7048/api/Employee', employee);
  }
  UpdateEmployee(id: number, employee: EmployeePost) {

    return this._http.put('http://localhost:7048/api/Employee/' + id, employee)
  }
  DeleteEmployee(id: number) {
    console.log(id)
    return this._http.delete('http://localhost:7048/api/Employee/' + id)

  }
}
