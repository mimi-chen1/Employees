import { Component, Input, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatIconModule } from '@angular/material/icon';
import { MatDialogModule } from '@angular/material/dialog';
import { MatDialog } from '@angular/material/dialog';
import { FormBuilder, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import * as XLSX from 'xlsx';
import { saveAs } from 'file-saver';
import { Employee } from '../../models/employee.model';
import { EmployeeService } from '../../services/employee.service';
import { EmployeeDetailsComponent } from '../employee-details/employee-details.component';
import { EmployeeDataService } from '../../services/employee-data.service';
@Component({
  selector: 'app-employee-list',
  standalone: true,
  imports: [ReactiveFormsModule, CommonModule, MatIconModule, MatDialogModule, EmployeeDetailsComponent, FormsModule, MatFormFieldModule, MatInputModule],
  templateUrl: './employee-list.component.html',
  styleUrl: './employee-list.component.css'
})
export class EmployeeListComponent implements OnInit {
  serch = this.fb.control("")
  listEmployee = this.employeeDataService.employees;
  @Input() employee!: Employee;
  searchText: string = '';
  constructor
    (private _employeeService: EmployeeService
      , private dialog: MatDialog,
      private readonly employeeDataService: EmployeeDataService,
      private readonly fb: FormBuilder
    ) {
  }
  ngOnInit(): void {
    this.serch.valueChanges.subscribe(value =>
      this.employeeDataService.fikterEmployeeList(value));
  }
  exportToExcel(): void {//ייצוא לexcel
    this.listEmployee.subscribe(employees => {
      const data: any[] = employees.map((employee: Employee) => {
        return {
          'שם פרטי': employee.firstName,
          'שם משפחה': employee.lastName,
          'תעודת זהות': employee.tz,
          'תאריך לידה': employee.employmentStartDate
        };
      });
      const worksheet: XLSX.WorkSheet = XLSX.utils.json_to_sheet(data);
      const workbook: XLSX.WorkBook = { Sheets: { 'data': worksheet }, SheetNames: ['data'] };
      const excelBuffer: any = XLSX.write(workbook, { bookType: 'xlsx', type: 'array' });
      const blob = new Blob([excelBuffer], { type: 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;charset=UTF-8' });
      saveAs(blob, 'employees.xlsx');
    })
  }
}




