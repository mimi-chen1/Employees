import { Component, Inject } from '@angular/core';
import { AbstractControl, FormArray, FormBuilder, FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { CommonModule, formatDate } from '@angular/common';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { ValidatorFn, ValidationErrors } from "@angular/forms";
import Swal from 'sweetalert2';
import { EmployeeService } from '../../services/employee.service';
import { EmployeePost } from '../../models/employeePost.model';
import { Position } from '../../models/position.model';
import { PositionService } from '../../services/position.service';
import { ValidationService } from '../../services/validation.service';
import { EmployeeDataService } from '../../services/employee-data.service';
@Component({
  selector: 'app-edit-employee',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, MatFormFieldModule, MatIconModule, MatCheckboxModule],
  templateUrl: './edit-employee.component.html',
  styleUrl: './edit-employee.component.css'
})
export class EditEmployeeComponent {
  employeeForm!: FormGroup;
  allPositions: Position[] = [];
  positionGroups: FormGroup[] = [];
  positionsErrors!: ValidationErrors[];
  constructor(
    private _employeeService: EmployeeService,
    public dialogRef: MatDialogRef<EditEmployeeComponent>,
    @Inject(MAT_DIALOG_DATA) public employeeData: any,
    private fb: FormBuilder, private _positionService: PositionService,
    private readonly validationService: ValidationService,
    private readonly employeeDataService: EmployeeDataService
  ) {
    this.initFrom();
    this.getPositions();
    console.log(employeeData)
    console.log(employeeData.firstName)
  }
  initFrom(): void {
    this.employeeForm = this.fb.group({
      firstName: [this.employeeData.firstName, [Validators.required, Validators.minLength(2)]],
      lastName: [this.employeeData.lastName, [Validators.required, Validators.minLength(2)]],
      tz: [this.employeeData.tz, [Validators.required, Validators.pattern('^[0-9]{9}$')]],
      employmentStartDate: [formatDate(this.employeeData.employmentStartDate, 'yyyy-MM-dd', 'en-US'), Validators.required],
      dateOfBirth: [
        formatDate(this.employeeData.dateOfBirth, 'yyyy-MM-dd', 'en-US'),
        [Validators.required, this.validationService.above18Validator(new Date())]
      ],
      gender: [this.employeeData.gender, Validators.required],
      status: [this.employeeData.status],
      positions: this.fb.array([], { validators: this.validationService.validatePositionId() }),
    }, { validator: this.validationService.validateDateStart });
    if (this.employeeData.positions && this.employeeData.positions.length > 0) {

      for (let i = 0; i < this.employeeData.positions.length; i++) {
        this.positions.push(this.createPositionFormGroup(this.employeeData.positions[i]));

      }
      this.positions.updateValueAndValidity();
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
  get positions(): FormArray {
    return this.employeeForm.get('positions') as FormArray;
  }
  createPositionFormGroup(position: any): FormGroup {

    return this.fb.group({
      positionId: [position.positionId, [Validators.required]],
      isAdministrative: [position.isAdministrative || false],
      dateStart: [
        position.dateStart ? formatDate(position.dateStart, 'yyyy-MM-dd', 'en-US') : '',
        [Validators.required]
      ]
    });
  }
  onPositionsErrorsChange(errors: ValidationErrors[]) {
    this.positionsErrors = errors;
  }
  addPosition(): void {
    this.positions.push(this.createPositionFormGroup({ positionId: "", isAdministrative: false, dateStart: new Date() }));
  }

  removePosition(index: number): void {
    this.positions.removeAt(index);
  }
  onSubmit(): void {
    Swal.fire({
      title: 'Are you sure?',
      text: 'Do you want to save the changes?',
      icon: 'question',
      showCancelButton: true,
      confirmButtonColor: '#FF69B4',
      cancelButtonColor: '#FFFFFF',
      background: '#FFFFFF',
      reverseButtons: true
    }).then((result) => {
      if (result.isConfirmed) {

        if (this.employeeForm.valid) {
          const employeeData: EmployeePost = this.employeeForm.value;

          if (this.positions instanceof FormArray) {
            employeeData.positions = this.positions.value.map((position: { positionId: any; isAdministrative: any; dateStart: any; }) => ({
              positionId: position.positionId,
              isAdministrative: position.isAdministrative,
              dateStart: position.dateStart
            }));

            this._employeeService.UpdateEmployee(this.employeeData.id, employeeData).subscribe(
              () => {
                this.employeeDataService.getEmployeeList();
                Swal.fire({
                  title: 'Employee updated successfully!',
                  text: 'The employee has been updated successfully.',
                  icon: 'success',
                  timer: 2000,
                  timerProgressBar: true,
                  background: '#FFFFFF',
                  iconColor: '#FF69B4'
                }).then(() => {
                  this.dialogRef.close(); // Close the dialog after successful update
                });
              },
              (error) => {
                console.error('Error updating employee:', error);
                Swal.fire({
                  title: 'Error!',
                  text: 'An error occurred while saving changes.',
                  icon: 'error',
                  confirmButtonColor: '#FF69B4',
                  background: '#FFFFFF'
                });
              }
            );
          }
        }
      }
    });
  }
}




