import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BeverageInvComponent } from './beverage-inv.component';

describe('BeverageInvComponent', () => {
  let component: BeverageInvComponent;
  let fixture: ComponentFixture<BeverageInvComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [BeverageInvComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(BeverageInvComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
