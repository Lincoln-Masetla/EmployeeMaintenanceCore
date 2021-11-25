import { Component, Input, Output, EventEmitter } from '@angular/core';
import { Iemp } from 'src/app/interfaces/iemp-get-res';
import { EmpService } from '../../services/emp.service';

@Component({
  selector: 'app-emp-details',
  templateUrl: './emp-details.component.html',
  styleUrls: ['./emp-details.component.css']
})
export class EmpDetailsComponent{
  @Input() public employee: Iemp;
  @Output() private deleteEvent = new EventEmitter<any>();
  @Output() private editEvent = new EventEmitter<any>();
  @Output() private closeEvent = new EventEmitter<any>();
  public isEditFormOpen = false;
  public test: any;

  constructor(private empService: EmpService) { }

  onClickDelete(): void {
    this.deleteEvent.emit();
  }
  editFormSubmit(data): void {
  this.editEvent.emit({ empData: data.data, id: this.employee.employeeId });
  }

  getEmployee(data) {
    this.isEditFormOpen = !this.isEditFormOpen;
  }
  onClickClose(): void {
    this.closeEvent.emit();
  }
}
