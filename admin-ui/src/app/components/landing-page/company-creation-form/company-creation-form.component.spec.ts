import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CompanyCreationFormComponent } from './company-creation-form.component';

describe('CompanyCreationFormComponent', () => {
  let component: CompanyCreationFormComponent;
  let fixture: ComponentFixture<CompanyCreationFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CompanyCreationFormComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(CompanyCreationFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
