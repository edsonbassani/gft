import { DishType, getDefaultDishType } from './dishType.interface';
import { Period, getDefaultPeriod } from './period.interface';
export interface Dish {
  id: number;
  name: string;
  dishTypeId: number;
  periodId: number;
  dishType: DishType;
  period: Period;
}

export function getDefaultDish(): Dish {
  return {
    id: 0,
    name: '',
    dishTypeId: 0,
    periodId: 0,
    dishType: getDefaultDishType(),
    period: getDefaultPeriod()
  };
}