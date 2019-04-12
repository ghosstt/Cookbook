import { Component, OnInit, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef, MatListOption } from '@angular/material';
import { RecipeService } from 'src/app/_services/recipe.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Recipe } from 'src/app/_models/recipe';
import { Ingredient } from 'src/app/_models/ingredient';
import { AlertifyService } from 'src/app/_services/alertify.service';

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
    @Inject(MAT_DIALOG_DATA) public data: { userId: number, ingredients: Ingredient[] } ,
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

  getFormData(): Recipe {
    const recipe: Recipe = {
      recipeId: this.savedRecipeId,
      userId: this.data.userId,
      name: this.addRecipeForm.get('recipeName').value,
      description: this.addRecipeForm.get('recipeDescription').value,
      imgSrc: null,
      ingredientIds: this.addRecipeForm.get('recipeIngredients').value
    };

    return recipe;
  }

  add() {
    const recipe = this.getFormData();

    const hasRecipeName = (recipe.name !== undefined && recipe.name !== null && recipe.name.trim() !== '');
    if (!hasRecipeName) {
      return;
    }

    this.recipeService.addRecipe(recipe).subscribe((recipeId: number) => {
      if (recipeId > 0) {
        this.addRecipeForm.get('recipeName').disable();
        this.addRecipeForm.get('recipeDescription').disable();
      }

      this.savedRecipeId = recipeId;
    }, error => {
      console.log(error);
      this.alertifyService.error(error.error);
    });
  }
}
