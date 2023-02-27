import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { CompanyHttpService } from './company-http.service';
import { CompanyDetails } from '../models/companyDetails';
import { Company } from '../models/company';

@Injectable({
  providedIn: 'root',
})
export class CompanyService {
  private _companyList: BehaviorSubject<CompanyDetails[]> = new BehaviorSubject<
    CompanyDetails[]
  >([]);
  public readonly companyList: Observable<CompanyDetails[]> =
    this._companyList.asObservable();

  constructor(private companyHttpService: CompanyHttpService) {}

  getCompanyList(): Observable<CompanyDetails[]> {
    return this.companyList;
  }

  updateCompanyList(companies: CompanyDetails[]): void {
    this._companyList.next(companies);
  }

  getCompanies(): void {
    this.companyHttpService.getCompanies().subscribe((res) => {
      this.updateCompanyList(res);
    });
  }

  save(company: Company): void {
    this.companyHttpService.save(company).subscribe(() => {
      this.getCompanies();
    });
  }

  deleteCompany(businessId: string) {
    this.companyHttpService.delete(businessId).subscribe(() => {
      this.getCompanies();
    });
  }

  getCompanyDetails(businessId: string | null): Observable<any> {
    return this.companyHttpService.getCompany(businessId!);
  }
}
