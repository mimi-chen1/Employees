import { Injectable } from '@angular/core';
import { AbstractControl, FormArray, FormGroup, ValidationErrors, ValidatorFn } from '@angular/forms';
@Injectable({
  providedIn: 'root'
})
export class ValidationService {
  constructor() {
  }
  validateDateStart(group: FormGroup): ValidationErrors | null {
    const positions = (group.get("positions") as FormArray).controls;
    var index = 0
    for (const position of positions) {

      const employmentStartDate = group.get("employmentStartDate");
      const dateStartPosition = position.get("dateStart");

      if (new Date(dateStartPosition?.value) < new Date(employmentStartDate?.value)) {
        return { [`invalidDateStart`]: true };
      }
    }
    return null;
  }
   
  above18Validator(maxDate: Date): ValidatorFn {
    return (control: AbstractControl): ValidationErrors | null => {
      if (!control.value) {
        console.log('**ERROR**: Date of birth is required');
        return { required: true };
      }
      const dateOfBirth = new Date(control.value);
      console.log('**Date of birth**: ', dateOfBirth);
      const eighteenYearsAgo = new Date(maxDate);
      eighteenYearsAgo.setFullYear(eighteenYearsAgo.getFullYear() - 18);
      console.log('**Eighteen years ago**: ', eighteenYearsAgo);

      if (dateOfBirth <= eighteenYearsAgo) {
        console.log('**Date is valid**: ', dateOfBirth);
        return null;
      } else {
        console.log('**ERROR**: Date is below 18 years old');
        return { below18: true };
      }
    };
  }
  validatePositionId(): ValidatorFn {
    return (positions: AbstractControl): ValidationErrors | null => {
      const formArray = positions as FormArray;
      const numersPositions = formArray.controls.map(p => p.get("positionId")?.value as number);

      for (let i = 0; i < numersPositions.length; i++) {
        for (let x = i + 1; x < numersPositions.length; x++) {
          if (numersPositions[i] == numersPositions[x]) {
            formArray.controls[x].setErrors({ positionAlreadyExists: 'Position already exists in the list' });
            return { positionAlreadyExists: true };
          }
        }
      }
      return null;
    };
  }
  

 
 




}
