import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { environment } from "@env/environment";
import { Dish } from '@app/shared/models/dish.interface';
import { Observable, retry, catchError } from 'rxjs';
import { logAndThrowHttpError } from "@app/shared/utilities/http-utilities";
import { DishType } from '@app/shared/models/dishType.interface';
import { Period } from '@app/shared/models/period.interface';

@Injectable({
  providedIn: 'root'
})
export class HomeService {

  private readonly apiUrl = `${environment.roaApiUrl}`;

  constructor(private http: HttpClient) { }

  listDishes(): Observable<Dish[]> {
    return this.http
      .get<Dish[]>(`${this.apiUrl}/dishes/getallwithrelated`)
      .pipe(
        retry(2),
        catchError(logAndThrowHttpError<Dish[]>('getDishes')),
      );
  }

  listDishTypes(): Observable<DishType[]> {
    return this.http
      .get<DishType[]>(`${this.apiUrl}/dishtypes/getall`)
      .pipe(
        retry(2),
        catchError(logAndThrowHttpError<DishType[]>('listDishTypes')),
      );
  }

  getDishType(dishTypeId: number): Observable<DishType> {
    return this.http
      .get<DishType>(`${this.apiUrl}/dishtypes/getsingle/1`)
      .pipe(
        retry(2),
        catchError(logAndThrowHttpError<DishType>('getDishType')),
      );
  }

  listPeriods(): Observable<Period[]> {
    return this.http
      .get<Period[]>(`${this.apiUrl}/periods/getall`)
      .pipe(
        retry(2),
        catchError(logAndThrowHttpError<Period[]>('listPeriods')),
      );
  }
  
}


