import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormArray, FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, ValidationErrors, ValidatorFn, Validators } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatDialogRef } from '@angular/material/dialog';
import Swal from 'sweetalert2';
import { EmployeeService } from '../../services/employee.service';
import { Employee } from '../../models/employee.model';
import { EmployeePositionPost } from '../../models/employeePositionPost.model';
import { Position } from '../../models/position.model';
import { PositionService } from '../../services/position.service';
import { EmployeeDataService } from '../../services/employee-data.service';
import { ValidationService } from '../../services/validation.service';
import { MatCheckboxModule } from '@angular/material/checkbox';
@Component({
  selector: 'app-add-employee',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, MatDatepickerModule, MatFormFieldModule, FormsModule, MatCheckboxModule],
  templateUrl: './add-employee.component.html',
  styleUrl: './add-employee.component.css'
})
export class AddEmployeeComponent implements OnInit {
  employeeForm!: FormGroup;
  positionGroups: FormGroup[] = [];
  showPositionFields = false;
  allPositions: Position[] = [];

  constructor(private fb: FormBuilder, private employeeService: EmployeeService, private _positionService: PositionService, public dialogRef: MatDialogRef<AddEmployeeComponent>, private readonly employeeDataService: EmployeeDataService,
    private validatorsService: ValidationService
  ) {
  }
  ngOnInit(): void {
    this.getPositions();
    this.employeeForm = this.fb.group({
      firstName: ['', [Validators.required, Validators.minLength(2)]],
      lastName: ['', [Validators.required, Validators.minLength(2)]],
      tz: ['', [Validators.required, Validators.pattern(/^[0-9]{9,11}$/)]],
      employmentStartDate: ['', Validators.required],
      positions: this.fb.array([], { validators: this.validatorsService.validatePositionId() }),
      dateOfBirth: ['', [Validators.required, this.validatorsService.above18Validator(new Date())]],
      gender: [true, Validators.required],
    }, { validator: this.validatorsService.validateDateStart });
  }
  isInvalid(): boolean {
    return this.employeeForm.invalid
  }
  get positions(): FormArray {
    return this.employeeForm.get('positions') as FormArray;
  }
  addPosition(): void {
    this.positions.push(this.fb.group({
      positionId: ['', [Validators.required]],
      isAdministrative: [false, []],
      dateStart: ['', [Validators.required]]// הוספת הוולידטור
    }));

  }

  addEmployee(): void {
    if (this.employeeForm.valid) {
      const employeeData: Employee = this.employeeForm.value;
      const positions: EmployeePositionPost[] = this.positionGroups.map(group => group.value);
      employeeData.gender
      //employeeData.positions = positions;
      employeeData.positions = this.positions.value
      employeeData.status = true;
      console.log(employeeData);

      this.employeeService.AddEmployee(this.employeeForm.value)
        .subscribe(() => {
          alert('Employee added successfully');
          this.employeeForm.reset();
          this.positionGroups = [];
          this.showPositionFields = false;
          this.dialogRef.close();
          this.employeeDataService.getEmployeeList();
          // Show SweetAlert
          Swal.fire({
            title: 'העובד נוסף בהצלחה!',
            icon: 'success',
            confirmButtonText: 'אישור'
          }).then((result) => {
            if (result.isConfirmed) {
            }
          });
        }, error => {
          console.error('Failed to add employee', error);

          Swal.fire({
            title: 'שגיאה',
            text: 'שגיאה בהוספת עובד. אנא נסה שנית.',
            icon: 'error',
            confirmButtonText: 'אישור'
          });
        });
    }
  }

  getPositions(): void {
    this._positionService.getAllPositions()
      .subscribe(
        (data: any) => { // שינוי בסוג הנתונים מ-Position[] ל-any
          console.log(data);
          this.allPositions = data; // הכנסת הנתונים שהתקבלו מהקריאה לשירות למשתנה allPositions
          console.log(this.allPositions);
        },
        (error: any) => {
          console.log(error); // טיפול בשגיאות
        }
      );
  }

}



