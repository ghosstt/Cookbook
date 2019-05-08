import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { map } from 'rxjs/operators';
import { Recipe } from '../_models/recipe';
import { RecipeIngredients } from '../_models/recipe-ingredients';
import { CommandResult } from '../_models/command-result';

@Injectable({
    providedIn: 'root'
})
export class RecipeService {
    baseUrl = environment.apiUrl.concat('recipe');

    constructor(private http: HttpClient) { }

    getRecipe(recipeId: number): Observable<Recipe> {
        const params = new HttpParams().set('recipeId', recipeId.toString());
        return this.http.get<Recipe>(this.baseUrl + '/get', { params });
    }

    getRecipes(): Observable<Recipe[]> {
        return this.http.get<Recipe[]>(this.baseUrl + '/list');
    }

    getRecipeIngredientIds(recipeId: number): Observable<number[]> {
        const params = new HttpParams().set('recipeId', recipeId.toString());
        return this.http.get<number[]>(this.baseUrl + '/ingredients/ids', { params });
    }

    addRecipe(recipe: Recipe): Observable<CommandResult<number>> {
        return this.http.post<CommandResult<number>>(this.baseUrl + '/add', recipe);
    }

    updateRecipe(recipe: Recipe): Observable<CommandResult<number>> {
        return this.http.put<CommandResult<number>>(this.baseUrl + '/update', recipe);
    }
}
