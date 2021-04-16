import { ComponentFixture, TestBed } from '@angular/core/testing';
import { MessageDetailComponent } from './message-detail.component';
import { RouterTestingModule } from '@angular/router/testing';
import { HttpClient } from '@angular/common/http';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';

describe('MessageDetailComponent', () => {
  let component: MessageDetailComponent;
  let fixture: ComponentFixture<MessageDetailComponent>;
  let httpClient: HttpClient;
  let httpTestingController: HttpTestingController;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MessageDetailComponent ],
      imports: [ RouterTestingModule, HttpClientTestingModule ]
    })
    .compileComponents();
    httpClient = TestBed.get(HttpClient);
    httpTestingController = TestBed.get(HttpTestingController);
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MessageDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should render heading', () => {
    const fixture = TestBed.createComponent(MessageDetailComponent);
    fixture.detectChanges();
    const compiled = fixture.nativeElement;
    expect(compiled.querySelector('h1').textContent).toContain('Message Detail');
  });

  it('should render the Message labels', () => {
    const fixture = TestBed.createComponent(MessageDetailComponent);
    fixture.detectChanges();
    const compiled = fixture.nativeElement;
    expect(compiled.querySelector('div.MsgId').textContent).toContain("ID");
    expect(compiled.querySelector('div.MsgDate').textContent).toContain("Date");
    expect(compiled.querySelector('div.MsgUsername').textContent).toContain("Username");
    expect(compiled.querySelector('div.MsgSubject').textContent).toContain("Subject");
    expect(compiled.querySelector('div.MsgBody').textContent).toContain("Body");
  });
});
