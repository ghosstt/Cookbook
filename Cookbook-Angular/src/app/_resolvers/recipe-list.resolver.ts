import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Recipe } from '../_models/recipe';
import { RecipeService } from '../_services/recipe.service';
import { AlertifyService } from '../_services/alertify.service';
import { AuthService } from '../_services/auth.service';

@Injectable()
export class RecipeListResolver implements Resolve<Recipe[]> {
    constructor(
        private recipeService: RecipeService,
        private alertifyService: AlertifyService,
        private router: Router) {
    }

    resolve(
        route: ActivatedRouteSnapshot,
        state: RouterStateSnapshot): Observable<Recipe[]> {
        return this.recipeService.getRecipes().pipe(
            catchError(error => {
                this.alertifyService.error('Problem retrieving data');
                this.router.navigate(['/home']);
                return of(null);
            })
        );
    }
}
