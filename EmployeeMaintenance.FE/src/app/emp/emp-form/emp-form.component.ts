import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
import { NgModel, NgForm, FormControl, FormGroup, FormBuilder, Validators } from '@angular/forms';
import { EmpService } from '../../services/emp.service';

@Component({
  selector: 'app-emp-form',
  templateUrl: './emp-form.component.html',
  styleUrls: ['./emp-form.component.css']
})
export class EmpFormComponent implements OnInit {
  @Input() private empEditData: any;
  @Output() public formSubmitEvent = new EventEmitter<any>();

  public empFormGroup: FormGroup;

  constructor(private formBuilder: FormBuilder) { }

  ngOnInit() {
    this.empFormGroup = this.formBuilder.group({
      birthDate: [''],
      employedDate:[''],
      lastName:[''],
      firstName: [''],
      employeeNum:[''],
      terminatedDate:[''],
    });

    // if editForm then fill the existing values in form
    if (this.empEditData) {
      this.empFormGroup.patchValue({
      birthDate: new Date(this.empEditData.birthDate).toISOString().substring(0, 10),
      employedDate: new Date(this.empEditData.employedDate).toISOString().substring(0, 10),
      lastName: this.empEditData.lastName,
      firstName: this.empEditData.firstName,
      employeeNum: this.empEditData.employeeNum,
      terminatedDate: new Date(this.empEditData.terminatedDate).toISOString().substring(0, 10),
      });
    }
  }

  onFormSubmit(): void {
    this.formSubmitEvent.emit({ data: this.empFormGroup.value });
  }
}
