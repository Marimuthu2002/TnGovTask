import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PasswordDownloadComponent } from './password-download.component';

describe('PasswordDownloadComponent', () => {
  let component: PasswordDownloadComponent;
  let fixture: ComponentFixture<PasswordDownloadComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PasswordDownloadComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PasswordDownloadComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
