import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material';
import { IngredientAddComponent } from '../ingredients/ingredient-add/ingredient-add.component';
import { RecipeAddComponent } from '../recipes/recipe-add/recipe-add.component';
import { IngredientService } from 'src/app/_services/ingredient.service';
import { AuthService } from 'src/app/_services/auth.service';
import { Ingredient } from 'src/app/_models/ingredient';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  constructor(
    public dialog: MatDialog,
    private ingredientService: IngredientService,
    private authService: AuthService) {
  }

  ngOnInit() {
  }

  openCreateRecipeDialog() {
    this.ingredientService.getIngredients(this.authService.userId).subscribe((ingredients: Ingredient[]) => {
      const dialogRef = this.dialog.open(RecipeAddComponent, {
        disableClose: false,
        data: { userId: this.authService.userId, ingredients },
        width: '400px'
      });
    });
  }

  openAddIngredientDialog() {
    const dialogRef = this.dialog.open(IngredientAddComponent, {
      disableClose: false,
      data: { userId: this.authService.userId },
      width: '400px'
    });
  }
}
