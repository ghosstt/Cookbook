import { Component, OnInit, Input, ChangeDetectorRef } from '@angular/core';
import { Recipe } from 'src/app/_models/recipe';
import { MatDialog } from '@angular/material';
import { RecipeService } from 'src/app/_services/recipe.service';
import { RecipeEditComponent } from '../recipe-edit/recipe-edit.component';
import { IngredientService } from 'src/app/_services/ingredient.service';
import { RecipeIngredients } from 'src/app/_models/recipe-ingredients';
import { forkJoin } from 'rxjs';
import { Ingredient } from 'src/app/_models/ingredient';

@Component({
    selector: 'app-recipe-card',
    templateUrl: './recipe-card.component.html',
    styleUrls: ['./recipe-card.component.css']
})
export class RecipeCardComponent implements OnInit {
    @Input()
    recipe: Recipe;

    constructor(
        public dialog: MatDialog,
        private recipeService: RecipeService,
        private ingredientService: IngredientService,
        private cdRef: ChangeDetectorRef) { }

    ngOnInit() {
    }

    getImgSrc(filename: string): string {
        if (filename === null) {
            return null;
        }

        return `../../../../assets/images/ingredients/${filename}`;
    }

    openUpdateRecipeDialog() {
        forkJoin(
            this.ingredientService.getIngredients(),
            this.recipeService.getRecipeIngredientIds(this.recipe.recipeId))
            .subscribe(([ingredientsList, recipeIngredientIds]) => {
                this.recipe.ingredientIds = recipeIngredientIds;
                const data = { recipe: this.recipe, ingredients: ingredientsList };
                const dialogRef = this.dialog.open(RecipeEditComponent, {
                    disableClose: false,
                    data,
                    width: '400px'
                });

                dialogRef.afterClosed().subscribe(() => {
                    this.cdRef.detectChanges();
                });
            });
    }
}
