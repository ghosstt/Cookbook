import { Component, OnInit, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef  } from '@angular/material';
import { IngredientService } from 'src/app/_services/ingredient.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Ingredient } from 'src/app/_models/ingredient';

@Component({
  selector: 'app-ingredient-edit',
  templateUrl: './ingredient-edit.component.html',
  styleUrls: ['./ingredient-edit.component.css']
})

export class IngredientEditComponent implements OnInit {
  editIngredientForm: FormGroup;

  constructor(
    public dialogRef: MatDialogRef<IngredientEditComponent>,
    @Inject(MAT_DIALOG_DATA) public data: { userId: number, ingredient: Ingredient },
    private ingredientService: IngredientService,
    private formBuilder: FormBuilder) {
  }

  ngOnInit() {
    this.dialogRef.beforeClosed().subscribe(() => {
      this.edit();
    });

    this.editIngredientForm = this.formBuilder.group({
      ingredientName: [this.data.ingredient.name, Validators.required],
      ingredientDescription: [this.data.ingredient.description]
    });
  }

  edit() {
    this.data.ingredient.name = this.editIngredientForm.get('ingredientName').value;
    this.data.ingredient.description = this.editIngredientForm.get('ingredientDescription').value;

    if (this.data.ingredient.name === undefined || this.data.ingredient.name === null || this.data.ingredient.name.trim() === '') {
      return;
    }

    this.ingredientService.updateIngredient(this.data.ingredient).subscribe(response => {
      console.log(response, 'Edit Ingredient');
    });
  }
}
