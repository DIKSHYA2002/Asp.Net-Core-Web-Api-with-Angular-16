import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { IEmployee } from './Interfaces/Employee';


@Injectable({
  providedIn: 'root'
})
export class HttpService {
  apiIUrl = "https://localhost:7024";
  http = inject(HttpClient);
  
  constructor() { }

  getEmployeeList()
  {
    return this.http.get<IEmployee[]>(this.apiIUrl + "/api/Employee");
  }


}
