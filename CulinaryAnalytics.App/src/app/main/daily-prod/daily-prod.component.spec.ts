import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DailyProdComponent } from './daily-prod.component';

describe('DailyProdComponent', () => {
  let component: DailyProdComponent;
  let fixture: ComponentFixture<DailyProdComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [DailyProdComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DailyProdComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
