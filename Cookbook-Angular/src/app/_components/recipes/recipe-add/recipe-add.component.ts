import { Component, OnInit, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef, MatListOption } from '@angular/material';
import { RecipeService } from 'src/app/_services/recipe.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Recipe } from 'src/app/_models/recipe';
import { Ingredient } from 'src/app/_models/ingredient';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { CommandResult } from 'src/app/_models/command-result';

@Component({
    selector: 'app-recipe-add',
    templateUrl: './recipe-add.component.html',
    styleUrls: ['./recipe-add.component.css']
})
export class RecipeAddComponent implements OnInit {
    addRecipeForm: FormGroup;
    savedRecipeId = 0;

    constructor(
        public dialogRef: MatDialogRef<RecipeAddComponent>,
        @Inject(MAT_DIALOG_DATA) public data: { ingredients: Ingredient[] },
        private recipeService: RecipeService,
        private alertifyService: AlertifyService,
        private formBuilder: FormBuilder) {
    }

    ngOnInit() {
        this.dialogRef.beforeClosed().subscribe(() => {
            this.add();
        });

        this.addRecipeForm = this.formBuilder.group({
            recipeName: ['', Validators.required],
            recipeDescription: [''],
            recipeIngredients: ['']
        });
    }

    onSelectionChange() {
        this.add();
    }

    add() {
        if (this.addRecipeForm.invalid) {
            this.alertifyService.error('Error: Cannot save, recipe name is empty');
            return;
        }

        const recipe: Recipe = {
            recipeId: this.savedRecipeId,
            userId: '00000000-0000-0000-0000-000000000000',
            name: this.addRecipeForm.get('recipeName').value,
            description: this.addRecipeForm.get('recipeDescription').value,
            imgSrc: null,
            ingredientIds: this.addRecipeForm.get('recipeIngredients').value
        };

        this.recipeService.addRecipe(recipe).subscribe((result: CommandResult<number>) => {
            console.log(result, 'Success: Add Recipe');

            if (result.successful) {
                this.addRecipeForm.get('recipeName').disable();
                this.addRecipeForm.get('recipeDescription').disable();
            }

            this.savedRecipeId = result.data;
        }, error => {
            console.log(error, 'Error: Add Recipe');
            this.alertifyService.error(error);
        });
    }
}

