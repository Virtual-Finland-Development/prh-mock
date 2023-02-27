import { Component } from '@angular/core';
import { CompanyDetails } from '../../../models/companyDetails';
import { CompanyService } from '../../../services/company.service';
import { faHome, faTrash } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-company-list',
  templateUrl: './company-list.component.html',
  styleUrls: ['./company-list.component.sass'],
})
export class CompanyListComponent {
  companies!: CompanyDetails[];
  faHome = faHome;
  faTrash = faTrash;

  constructor(private companyService: CompanyService) {
    // Subscribe to company list observable
    companyService.getCompanyList().subscribe((res) => {
      this.companies = res;
    });
    // Have company service fetch companies from API
    companyService.getCompanies();
  }

  deleteCompany(key: string) {
    this.companyService.deleteCompany(key);
  }
}
