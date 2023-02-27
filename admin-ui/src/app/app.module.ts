import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LandingPageComponent } from './components/landing-page/landing-page.component';
import { CompanyListComponent } from './components/landing-page/company-list/company-list.component';
import { UserListComponent } from './components/landing-page/user-list/user-list.component';
import { CompanyCreationFormComponent } from './components/landing-page/company-creation-form/company-creation-form.component';
import { HttpClientModule } from '@angular/common/http';
import { CompanyDetailsPageComponent } from './components/company-details-page/company-details-page.component';
import { FormsModule } from '@angular/forms';
import {
  FaIconLibrary,
  FontAwesomeModule,
} from '@fortawesome/angular-fontawesome';
import { faStar as farStar } from '@fortawesome/free-regular-svg-icons';
import { faStar as fasStar } from '@fortawesome/free-solid-svg-icons';
import { NavigationComponent } from './components/navigation/navigation.component';

@NgModule({
  declarations: [
    AppComponent,
    LandingPageComponent,
    CompanyListComponent,
    UserListComponent,
    CompanyCreationFormComponent,
    CompanyDetailsPageComponent,
    NavigationComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    FontAwesomeModule,
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {
  constructor(library: FaIconLibrary) {
    library.addIcons(fasStar, farStar);
  }
}
