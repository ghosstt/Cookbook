import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Ingredient } from '../_models/ingredient';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root'
})
export class IngredientService {
  baseUrl = environment.apiUrl.concat('ingredient');

  constructor(private http: HttpClient) { }

  getIngredient(userId: number, ingredientId: number): Observable<Ingredient> {
    const params = new HttpParams()
      .set('userId', userId.toString())
      .set('ingredientId', ingredientId.toString());

    return this.http.get<Ingredient>(this.baseUrl + '/get', { params });
  }

  getIngredients(userId: number): Observable<Ingredient[]> {
    const params = new HttpParams().set('userId', userId.toString());
    return this.http.get<Ingredient[]>(this.baseUrl + '/list', { params });
  }

  addIngredient(ingredient: Ingredient): Observable<number> {
    return this.http.post<number>(this.baseUrl + '/add', ingredient);
  }

  updateIngredient(ingredient: Ingredient): Observable<number> {
    return this.http.put<number>(this.baseUrl + '/update', ingredient);
  }
}
