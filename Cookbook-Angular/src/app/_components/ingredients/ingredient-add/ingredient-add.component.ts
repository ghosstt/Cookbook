import { Component, OnInit, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef  } from '@angular/material';
import { IngredientService } from 'src/app/_services/ingredient.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Ingredient } from 'src/app/_models/ingredient';

@Component({
  selector: 'app-ingredient-add',
  templateUrl: './ingredient-add.component.html',
  styleUrls: ['./ingredient-add.component.css']
})

export class IngredientAddComponent implements OnInit {
  addIngredientForm: FormGroup;

  constructor(
    public dialogRef: MatDialogRef<IngredientAddComponent>,
    @Inject(MAT_DIALOG_DATA) public data: { userId: number },
    private ingredientService: IngredientService,
    private formBuilder: FormBuilder) {
  }

  ngOnInit() {
    this.dialogRef.beforeClosed().subscribe(() => {
      this.add();
    });

    this.addIngredientForm = this.formBuilder.group({
      ingredientName: ['', Validators.required],
      ingredientDescription: ['']
    });
  }

  add() {
    const formData: Ingredient = {
      ingredientId: 0,
      userId: this.data.userId,
      name: this.addIngredientForm.get('ingredientName').value,
      description: this.addIngredientForm.get('ingredientDescription').value,
      imgSrc: null
    };

    if (formData.name === undefined || formData.name === null || formData.name.trim() === '') {
      return;
    }

    this.ingredientService.addIngredient(formData).subscribe(response => {
      console.log(response, 'Add Ingredient');
    });
  }
}
