import { Component, OnInit, Input } from '@angular/core';
import { Ingredient } from 'src/app/_models/ingredient';
import { IngredientEditComponent } from '../ingredient-edit/ingredient-edit.component';
import { MatDialog } from '@angular/material';

@Component({
  selector: 'app-ingredient-card',
  templateUrl: './ingredient-card.component.html',
  styleUrls: ['./ingredient-card.component.css']
})
export class IngredientCardComponent implements OnInit {
  @Input()
  ingredient: Ingredient;

  constructor(public dialog: MatDialog) { }

  ngOnInit() {
  }

  getImgSrc(filename: string): string {
    if (filename === null) {
      return null;
    }

    return `../../../../assets/images/ingredients/${ filename }`;
  }

  openUpdateIngredientDialog() {
    const dialogRef = this.dialog.open(IngredientEditComponent, {
      disableClose: false,
      data: {
        userId: this.ingredient.userId,
        ingredient: this.ingredient
      },
      width: '400px'
    });
  }
}
