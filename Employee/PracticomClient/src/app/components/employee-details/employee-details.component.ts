import { Component, Input } from '@angular/core';
import { Employee } from '../../models/employee.model';
import { MatDialog } from '@angular/material/dialog';
import { EditEmployeeComponent } from '../edit-employee/edit-employee.component';
import { MatIconModule } from '@angular/material/icon';
import { EmployeeService } from '../../services/employee.service';
import { CommonModule } from '@angular/common';
import Swal from 'sweetalert2';
import { EmployeeDataService } from '../../services/employee-data.service';
@Component({
  selector:  'tr[app-employee-details]',
  standalone: true,
  imports: [CommonModule, MatIconModule],
  templateUrl: './employee-details.component.html',
  styleUrl: './employee-details.component.css'
})
export class EmployeeDetailsComponent {
  @Input() employee!: Employee;
  constructor(private _employeeService: EmployeeService, private dialog: MatDialog, private readonly employeeDataService:EmployeeDataService) {
  }
  editEmployee(employee: Employee): void {
    console.log('Employee data:', employee); 
    const dialogRef = this.dialog.open(EditEmployeeComponent, {
       data: employee
    });
    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
    });
  }
 deleteEmployee(id: number): void {
    console.log('Deleting employee with ID:', id);
    Swal.fire({
      title: "Are you sure?",
      text: "You won't be able to revert this!",
      icon: "warning",
      showCancelButton: true,
      confirmButtonColor: "#3085d6",
      cancelButtonColor: "#d33",
      confirmButtonText: "Yes, delete it!"
    }).then((result) => {
      if (result.isConfirmed) {
        this._employeeService.DeleteEmployee(id).subscribe(
          () => {
           this. employeeDataService.getEmployeeList();
            console.log('Employee status changed to false');
            Swal.fire({
              title: "Deleted!",
              text: "Employee status changed to false",
              icon: "success"
            });
          },
          (error) => {
            console.error('Error deleting employee:', error);
            alert('Error deleting employee. Please try again.');
          }
        );
      }
    });
  }
}