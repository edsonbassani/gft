import { Component, OnInit } from '@angular/core';
import { HomeService } from '@app/home/services/home.service';
import { Dish } from '@app/shared/models/dish.interface';
import { DishType } from '@app/shared/models/dishType.interface';
import { Period } from '@app/shared/models/period.interface';
import { Subject, takeUntil } from 'rxjs';

@Component({
  selector: 'roa-landing',
  templateUrl: './landing.component.html',
  styleUrls: ['./landing.component.scss']
})
export class LandingComponent implements OnInit {

  private destroy$ = new Subject();
  dishes = new Array<Dish>();
  dishTypes = new Array<DishType>();
  periods = new Array<Period>();
  showPeriods = false;
  showDishTypes = false;
  showDishes = false;

  selectedPeriodId: number = 0;
  selectedDishTypeId: number = 0;
  selectedDishId: number = 0;

  constructor(private homeService: HomeService) { }

  ngOnInit(): void {
    this.listPeriods();
    this.showPeriods = true;
  }

  ngOnDestroy() {
    this.destroy$.next(null);
    this.destroy$.complete();
  }

  listDishes(dishTypeId: number, periodId: number){
    this.homeService.listDishes().pipe(takeUntil(this.destroy$)).subscribe(res => {
      this.dishes = res.filter(x => x.dishTypeId == dishTypeId && x.periodId == periodId);
    });
  }

  listDishTypes(period: number){
    this.homeService.listDishTypes().pipe(takeUntil(this.destroy$)).subscribe(res => {
      if(period === 1)
        this.dishTypes = res.filter(x => x.id == 1 || x.id == 2 || x.id == 3);
      else if(period === 2)
        this.dishTypes = res.filter(x => x.id == 1 || x.id == 2 || x.id == 3 || x.id == 4);
    });
  }

  listPeriods(){
    this.homeService.listPeriods().pipe(takeUntil(this.destroy$)).subscribe(res => {
      this.periods = res;
    });
  }

  handleState(action: string, currentState:number) {
    this.showPeriods = false;
    if(action === 'Periods'){
      this.showDishTypes = true;
      this.showDishes = false;
      this.selectedPeriodId = currentState;
      this.listDishTypes(this.selectedPeriodId);
    }

    if(action === 'DishTypes'){
      this.showDishTypes = false;
      this.showDishes = true;
      this.selectedDishTypeId = currentState;
      this.listDishes(this.selectedDishTypeId, this.selectedPeriodId);
    }

    if(action === 'Back'){
      this.resetState();
    }
  }

  resetState(){
    this.showPeriods = true;
    this.showDishTypes = false;
    this.showDishes = false;
  
    this.selectedPeriodId = 0;
    this.selectedDishTypeId = 0;
    this.selectedDishId = 0;
  }
}
