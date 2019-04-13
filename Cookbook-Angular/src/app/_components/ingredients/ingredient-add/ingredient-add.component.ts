import { Component, OnInit, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef  } from '@angular/material';
import { IngredientService } from 'src/app/_services/ingredient.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Ingredient } from 'src/app/_models/ingredient';
import { AlertifyService } from 'src/app/_services/alertify.service';

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
    private alertifyService: AlertifyService,
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
    if (this.addIngredientForm.invalid) {
      this.alertifyService.error('Error: Cannot save, ingredient name is empty');
      return;
    }

    const ingredient: Ingredient = {
      ingredientId: 0,
      userId: this.data.userId,
      name: this.addIngredientForm.get('ingredientName').value,
      description: this.addIngredientForm.get('ingredientDescription').value,
      imgSrc: null
    };

    this.ingredientService.addIngredient(ingredient).subscribe(response => {
      console.log(response, 'Success: Add Ingredient');
    }, error => {
      console.log(error, 'Error: Edit Ingredient');
      this.alertifyService.error(error);
    });
  }
}
