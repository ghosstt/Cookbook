import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { AlertifyService } from '../_services/alertify.service';
import { Ingredient } from '../_models/ingredient';
import { IngredientService } from '../_services/ingredient.service';
import { AuthService } from '../_services/auth.service';

@Injectable()
export class IngredientListResolver implements Resolve<Ingredient[]> {
    constructor(
        private ingredientService: IngredientService,
        private alertifyService: AlertifyService,
        private router: Router) {
    }

    resolve(
        route: ActivatedRouteSnapshot,
        state: RouterStateSnapshot): Observable<Ingredient[]> {
        return this.ingredientService.getIngredients().pipe(
            catchError(error => {
                this.alertifyService.error('Problem retrieving data');
                this.router.navigate(['/home']);
                return of(null);
            })
        );
    }
}
