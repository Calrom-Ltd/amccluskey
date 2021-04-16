import { ComponentFixture, TestBed } from '@angular/core/testing';
import { HttpClient } from '@angular/common/http';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { ChangePasswordComponent } from './change-password.component';

describe('ChangePasswordComponent', () => {
  let component: ChangePasswordComponent;
  let fixture: ComponentFixture<ChangePasswordComponent>;
  let httpClient: HttpClient;
  let httpTestingController: HttpTestingController;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ChangePasswordComponent ],
      imports: [ HttpClientTestingModule ]
    })
    .compileComponents();
    httpClient = TestBed.get(HttpClient);
    httpTestingController = TestBed.get(HttpTestingController);
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ChangePasswordComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should render heading', () => {
    const fixture = TestBed.createComponent(ChangePasswordComponent);
    fixture.detectChanges();
    const compiled = fixture.nativeElement;
    expect(compiled.querySelector('h1').textContent).toContain('Change A Password');
  });

  it('should render inputs and button', () => {
    const fixture = TestBed.createComponent(ChangePasswordComponent);
    fixture.detectChanges();
    const compiled = fixture.nativeElement;
    expect(compiled.querySelector('div#Username')).toBeTruthy();
    expect(compiled.querySelector('div#Username > input')).toBeTruthy();
    expect(compiled.querySelector('div#Password')).toBeTruthy();
    expect(compiled.querySelector('div#Password > input')).toBeTruthy();
    expect(compiled.querySelector('div#NewPassword')).toBeTruthy();
    expect(compiled.querySelector('div#NewPassword > input')).toBeTruthy();
    expect(compiled.querySelector('div#NewPasswordConfirmation')).toBeTruthy();
    expect(compiled.querySelector('div#NewPasswordConfirmation > input')).toBeTruthy();
    expect(compiled.querySelector('button#ChangePassword')).toBeTruthy();
  });
});
