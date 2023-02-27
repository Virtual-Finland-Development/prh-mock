import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LandingPageComponent } from './components/landing-page/landing-page.component';
import { CompanyDetailsPageComponent } from './components/company-details-page/company-details-page.component';

const routes: Routes = [
  { path: '', component: LandingPageComponent },
  { path: 'company/:id', component: CompanyDetailsPageComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
