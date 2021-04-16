import { ComponentFixture, TestBed } from '@angular/core/testing';
import { MessageComponent } from './message.component';
import { HttpClient } from '@angular/common/http';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';

describe('MessageComponent', () => {
  let component: MessageComponent;
  let fixture: ComponentFixture<MessageComponent>;
  let httpClient: HttpClient;
  let httpTestingController: HttpTestingController;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MessageComponent ],
      imports: [ HttpClientTestingModule ]
    })
    .compileComponents();
    httpClient = TestBed.get(HttpClient);
    httpTestingController = TestBed.get(HttpTestingController);
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MessageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should render heading', () => {
    const fixture = TestBed.createComponent(MessageComponent);
    fixture.detectChanges();
    const compiled = fixture.nativeElement;
    expect(compiled.querySelector('h1').textContent).toContain('Messaging Summary');
  });

  it('should render the table headings', () => {
    const fixture = TestBed.createComponent(MessageComponent);
    fixture.detectChanges();
    const compiled = fixture.nativeElement;
    expect(compiled.querySelector('table')).toBeTruthy();
    expect(compiled.querySelector('th.MsgId').textContent).toContain("Message Id");
    expect(compiled.querySelector('th.MsgSubject').textContent).toContain("Message Subject");
  });
});
