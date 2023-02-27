import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map, Observable } from 'rxjs';
import { CompanyDetails } from '../models/companyDetails';
import { Company } from '../models/company';

@Injectable({
  providedIn: 'root',
})
export class CompanyHttpService {
  private apiBaseUri: string = 'http://localhost:5059';
  private userId: string = '98623913-e4a9-432c-bd54-19c11af3bcbf';

  constructor(private http: HttpClient) {}

  getCompany(businessId: string): Observable<Company> {
    return this.http.get(`${this.apiBaseUri}/companies/${businessId}`).pipe(
      map((response) => {
        return response as Company;
      })
    );
  }

  getCompanies(): Observable<CompanyDetails[]> {
    return this.http.get(`${this.apiBaseUri}/companies`).pipe(
      map((response) => {
        return response as CompanyDetails[];
      })
    );
  }

  save(company: Company): Observable<any> {
    return this.http.post(
      `${this.apiBaseUri}/users/${this.userId}/companies`,
      company
    );
  }

  delete(businessId: string): Observable<any> {
    return this.http.delete(`${this.apiBaseUri}/companies/${businessId}`);
  }
}
