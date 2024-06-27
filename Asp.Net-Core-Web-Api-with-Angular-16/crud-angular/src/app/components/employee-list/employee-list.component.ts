import { Component, inject } from '@angular/core';
import { IEmployee } from '../../Interfaces/Employee';
import { HttpService } from '../../http.service';
import {MatTableModule} from '@angular/material/table';
import {MatProgressSpinnerModule} from '@angular/material/progress-spinner';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';
@Component({
  selector: 'app-employee-list',
  standalone: true,
  imports: [CommonModule,MatTableModule ,MatProgressSpinnerModule ,RouterLink],
  templateUrl: './employee-list.component.html',
  styleUrl: './employee-list.component.css'
})
export class EmployeeListComponent {
  loading = true;
  displayedColumns: string[] = ['Id', 'Name', 'Email', 'Age' , 'Salary'];
  employeeList: IEmployee[] = [];

  constructor(private httpService: HttpService)
  {

  } 
  ngOnInit() {
    this.getEmployeeFromServer();
  }
  getEmployeeFromServer() {
    this.httpService.getEmployeeList().subscribe((result: any) => {
      this.loading=true;
      this.employeeList = result;
      this.loading=false;
      //console.log(this.employeeList);
    });
  }
}
