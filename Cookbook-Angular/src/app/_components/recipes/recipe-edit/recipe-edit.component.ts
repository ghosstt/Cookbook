import { Component, OnInit, AfterViewInit, Inject, ChangeDetectorRef } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef, MatListOption } from '@angular/material';
import { RecipeService } from 'src/app/_services/recipe.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Recipe } from 'src/app/_models/recipe';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { Ingredient } from 'src/app/_models/ingredient';
import { CommandResult } from 'src/app/_models/command-result';

@Component({
    selector: 'app-recipe-edit',
    templateUrl: './recipe-edit.component.html',
    styleUrls: ['./recipe-edit.component.css']
})
export class RecipeEditComponent implements OnInit, AfterViewInit {
    editRecipeForm: FormGroup;
    origValue: Recipe;

    constructor(
        public dialogRef: MatDialogRef<RecipeEditComponent>,
        @Inject(MAT_DIALOG_DATA) public data: { recipe: Recipe, ingredients: Ingredient[] },
        private recipeService: RecipeService,
        private alertifyService: AlertifyService,
        private formBuilder: FormBuilder,
        private cdRef: ChangeDetectorRef) {
    }

    ngOnInit() {
        this.dialogRef.beforeClosed().subscribe(() => {
            this.edit();
        });

        this.editRecipeForm = this.formBuilder.group({
            recipeName: [this.data.recipe.name, Validators.required],
            recipeDescription: [this.data.recipe.description],
            recipeIngredients: [this.data.recipe.ingredientIds]
        });

        this.origValue = {
            recipeId: this.data.recipe.recipeId,
            userId: this.data.recipe.userId,
            name: this.data.recipe.name,
            description: this.data.recipe.description,
            ingredientIds: [...this.data.recipe.ingredientIds],
            imgSrc: this.data.recipe.imgSrc,
        };
    }

    ngAfterViewInit() {
        this.cdRef.detectChanges();
    }

    onSelectionChange(event, options: MatListOption[]) {
        this.edit();
    }

    setData() {
        this.data.recipe.name = this.editRecipeForm.get('recipeName').value;
        this.data.recipe.description = this.editRecipeForm.get('recipeDescription').value;
        this.data.recipe.ingredientIds = this.editRecipeForm.get('recipeIngredients').value;
    }

    setOrigData() {
        this.data.recipe.name = this.origValue.name;
        this.data.recipe.description = this.origValue.description;
        this.data.recipe.ingredientIds = [...this.origValue.ingredientIds];
    }

    edit() {
        if (this.editRecipeForm.invalid) {
            this.alertifyService.error('Error: Cannot save, recipe name is empty');
            return;
        }

        this.setData();

        this.recipeService.updateRecipe(this.data.recipe).subscribe((result: CommandResult<number>) => {
            console.log(result, 'Success: Edit Recipe');
        }, error => {
            this.setOrigData();
            console.log(error, 'Error: Edit Recipe');
            this.alertifyService.error(error);
        });
    }

    compareFn(o1: number, o2: number) {
        return o1 === o2;
    }
}

