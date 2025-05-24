import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UserTicketPageComponent } from './user-ticket-page.component';

describe('UserTicketPageComponent', () => {
  let component: UserTicketPageComponent;
  let fixture: ComponentFixture<UserTicketPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [UserTicketPageComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(UserTicketPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
