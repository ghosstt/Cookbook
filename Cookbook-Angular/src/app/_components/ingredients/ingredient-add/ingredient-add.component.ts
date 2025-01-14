import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef } from '@angular/material';
import { IngredientService } from 'src/app/_services/ingredient.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Ingredient } from 'src/app/_models/ingredient';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { CommandResult } from 'src/app/_models/command-result';

@Component({
    selector: 'app-ingredient-add',
    templateUrl: './ingredient-add.component.html',
    styleUrls: ['./ingredient-add.component.css']
})

export class IngredientAddComponent implements OnInit {
    addIngredientForm: FormGroup;

    constructor(
        public dialogRef: MatDialogRef<IngredientAddComponent>,
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
            userId: '00000000-0000-0000-0000-000000000000',
            name: this.addIngredientForm.get('ingredientName').value,
            description: this.addIngredientForm.get('ingredientDescription').value,
            imgSrc: null
        };

        this.ingredientService.addIngredient(ingredient).subscribe((result: CommandResult<number>) => {
            console.log(result, 'Success: Add Ingredient');
        }, error => {
            console.log(error, 'Error: Edit Ingredient');
            this.alertifyService.error(error);
        });
    }
}
