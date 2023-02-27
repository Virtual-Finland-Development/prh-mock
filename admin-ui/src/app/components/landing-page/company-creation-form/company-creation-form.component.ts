import { Component } from '@angular/core';
import { CompanyService } from '../../../services/company.service';
import { Company } from '../../../models/company';

@Component({
  selector: 'app-company-creation-form',
  templateUrl: './company-creation-form.component.html',
  styleUrls: ['./company-creation-form.component.sass'],
})
export class CompanyCreationFormComponent {
  company!: Company;

  constructor(private companyService: CompanyService) {
    this.company = new Company('', '');
  }

  saveCompany(company: Company, e: MouseEvent): void {
    e.preventDefault();

    this.companyService.save(company);
    this.company = new Company('', '');
  }
}
