import { Component, OnInit } from '@angular/core';
import { CompanyService } from '../../services/company.service';
import { Company } from '../../models/company';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-company-details-page',
  templateUrl: './company-details-page.component.html',
  styleUrls: ['./company-details-page.component.sass'],
})
export class CompanyDetailsPageComponent implements OnInit {
  businessId!: string | null;
  company!: Company;

  constructor(private service: CompanyService, private route: ActivatedRoute) {}

  ngOnInit(): void {
    this.businessId = this.route.snapshot.paramMap.get('id');

    this.service.getCompanyDetails(this.businessId).subscribe((res) => {
      this.hideLoadingIndicator();
      this.company = res;
    });
  }

  hideLoadingIndicator() {
    //TODO: Hide loader
  }
}
