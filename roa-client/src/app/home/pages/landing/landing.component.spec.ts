import { ComponentFixture, TestBed } from '@angular/core/testing';
import { HttpClientTestingModule } from '@angular/common/http/testing';

import { LandingComponent } from './landing.component';

describe('LandingComponent', () => {
  let component: LandingComponent;
  let fixture: ComponentFixture<LandingComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [LandingComponent],
      imports: [ HttpClientTestingModule ],
    });
    fixture = TestBed.createComponent(LandingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should show period menu', () => {
    expect(component.showPeriods).toBeTrue();
  });

  it('should hide dishType menu', () => {
    expect(component.showDishTypes).toBeFalse();
  });

  it('should hide Dish menu', () => {
    expect(component.showDishes).toBeFalse();
  });
});
