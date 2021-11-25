import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, Observer } from 'rxjs';
import { IempList } from '../interfaces/iemp-get-res';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class EmpService {

  constructor(private httpClient: HttpClient) { }

  private apiUrl = 'https://localhost:44382/api/employee';

  public getEmp(): Observable<IempList> {
    return this.httpClient.get(this.apiUrl)
      .pipe(map((res: IempList) => res));
  }

  public deletEmp(id): Observable<any> {
    return this.httpClient.delete(this.apiUrl + id)
      .pipe(map((res: any) => res));
  }

  public createEmp(formData): Observable<any> {
    return this.httpClient.post(this.apiUrl + '/create', formData.data)
      .pipe(map((res: any) => res));
  }

  public editEmp(formData): Observable<any> {
    return this.httpClient.post(this.apiUrl + '/update', formData.empData)
      .pipe(map((res: any) => res));
  }
}
