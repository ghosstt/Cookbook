import { Component, OnInit, AfterViewInit, Inject, ChangeDetectorRef } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef, MatListOption } from '@angular/material';
import { RecipeService } from 'src/app/_services/recipe.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Recipe } from 'src/app/_models/recipe';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { Ingredient } from 'src/app/_models/ingredient';

@Component({
  selector: 'app-recipe-edit',
  templateUrl: './recipe-edit.component.html',
  styleUrls: ['./recipe-edit.component.css']
})
export class RecipeEditComponent implements OnInit, AfterViewInit {
  editRecipeForm: FormGroup;

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
  }

  ngAfterViewInit() {
    this.cdRef.detectChanges();
  }

  onSelectionChange(event, options: MatListOption[]) {
    // this.editRecipeForm.get('recipeIngredients').setValue(this.data.recipe.ingredientIds);
    this.edit();
  }

  edit() {
    this.data.recipe.name = this.editRecipeForm.get('recipeName').value;
    this.data.recipe.description = this.editRecipeForm.get('recipeDescription').value;
    this.data.recipe.ingredientIds = this.editRecipeForm.get('recipeIngredients').value;

    const hasRecipeName = (this.data.recipe.name !== undefined && this.data.recipe.name !== null && this.data.recipe.name.trim() !== '');
    if (!hasRecipeName) {
      return;
    }

    this.recipeService.updateRecipe(this.data.recipe).subscribe((recipeId: number) => {
      console.log(recipeId, 'updateRecipe');
    }, error => {
      console.log(error);
      this.alertifyService.error(error.error);
    });
  }

  compareFn(o1: number, o2: number) {
    return o1 === o2;
  }
}

