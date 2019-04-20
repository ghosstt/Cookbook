import { Component, OnInit, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material';
import { IngredientService } from 'src/app/_services/ingredient.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Ingredient } from 'src/app/_models/ingredient';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { CommandResult } from 'src/app/_models/command-result';

@Component({
    selector: 'app-ingredient-edit',
    templateUrl: './ingredient-edit.component.html',
    styleUrls: ['./ingredient-edit.component.css']
})

export class IngredientEditComponent implements OnInit {
    editIngredientForm: FormGroup;
    origValue: Ingredient;

    constructor(
        public dialogRef: MatDialogRef<IngredientEditComponent>,
        @Inject(MAT_DIALOG_DATA) public data: { userId: number, ingredient: Ingredient },
        private ingredientService: IngredientService,
        private alertifyService: AlertifyService,
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

        this.origValue = {
            ingredientId: this.data.ingredient.ingredientId,
            userId: this.data.ingredient.userId,
            name: this.data.ingredient.name,
            description: this.data.ingredient.description,
            imgSrc: this.data.ingredient.imgSrc,
        };
    }


    setData() {
        this.data.ingredient.name = this.editIngredientForm.get('ingredientName').value;
        this.data.ingredient.description = this.editIngredientForm.get('ingredientDescription').value;
    }

    setOrigData() {
        this.data.ingredient.name = this.origValue.name;
        this.data.ingredient.description = this.origValue.description;
    }

    edit() {
        if (this.editIngredientForm.invalid) {
            this.alertifyService.error('Error: Cannot save, ingredient name is empty');
            return;
        }

        this.setData();

        this.ingredientService.updateIngredient(this.data.ingredient).subscribe((result: CommandResult<number>) => {
            console.log(result, 'Success: Edit Ingredient');
        }, error => {
            this.setOrigData();
            console.log(error, 'Error: Edit Ingredient');
            this.alertifyService.error(error);
        });
    }
}
