import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Ingredient } from '../_models/ingredient';
import { AuthService } from './auth.service';
import { CommandResult } from '../_models/command-result';

@Injectable({
    providedIn: 'root'
})
export class IngredientService {
    baseUrl = environment.apiUrl.concat('ingredient');

    constructor(private http: HttpClient) { }

    getIngredient(ingredientId: number): Observable<Ingredient> {
        const params = new HttpParams().set('ingredientId', ingredientId.toString());
        return this.http.get<Ingredient>(this.baseUrl + '/get', { params });
    }

    getIngredients(): Observable<Ingredient[]> {
        return this.http.get<Ingredient[]>(this.baseUrl + '/list');
    }

    addIngredient(ingredient: Ingredient): Observable<CommandResult<number>> {
        return this.http.post<CommandResult<number>>(this.baseUrl + '/add', ingredient);
    }

    updateIngredient(ingredient: Ingredient): Observable<CommandResult<number>> {
        return this.http.put<CommandResult<number>>(this.baseUrl + '/update', ingredient);
    }
}
