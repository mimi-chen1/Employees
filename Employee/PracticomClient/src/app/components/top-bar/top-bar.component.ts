import { Component, OnInit } from '@angular/core';
import { AddEmployeeComponent } from '../add-employee/add-employee.component';
import { MatDialog } from '@angular/material/dialog';
import { EmployeeDataService } from '../../services/employee-data.service';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatIcon, MatIconModule } from '@angular/material/icon';
import { MatFormFieldModule } from '@angular/material/form-field';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router'
@Component({
  selector: 'app-top-bar',
  standalone: true,
  imports: [MatToolbarModule, MatIcon, MatFormFieldModule, MatToolbarModule, RouterModule
    , MatIconModule,
    MatFormFieldModule, CommonModule],
  templateUrl: './top-bar.component.html',
  styleUrl: './top-bar.component.css'
})
export class TopBarComponent {
  listEmployee = this.employeeDataService.employees;
  searchText: string = '';
  constructor(private dialog: MatDialog,
    private readonly employeeDataService: EmployeeDataService,
  ) {
  }
  addEmployee(): void {//פותח את הקומפוננטה של add
    const dialogRef = this.dialog.open(AddEmployeeComponent, {
      // קביעת מיקום לדיאלוג
      panelClass: 'dialog'
    });
    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
    });
  }

}
