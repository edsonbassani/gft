export interface DishType {
    id: number;
    name: string;
  }

export function getDefaultDishType(): DishType {
  return {
    id: 0,
    name: '',
  };
}