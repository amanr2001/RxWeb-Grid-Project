import { AbstractControl, ValidationErrors } from '@angular/forms'

export function gte(control: AbstractControl): ValidationErrors | null {

    const v = new Date(control.value);
    const x = v
    const t = new Date();

    if (x>=t) {
      return { 'gte': true, 'requiredValue': 10 }
    }
    return null

}
