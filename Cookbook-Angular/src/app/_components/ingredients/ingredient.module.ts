import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { IngredientCardComponent } from './ingredient-card/ingredient-card.component';
import { IngredientListComponent } from './ingredient-list/ingredient-list.component';
import { IngredientAddComponent } from './ingredient-add/ingredient-add.component';
import { MatDialogModule } from '@angular/material';
import { MaterialModule } from 'src/app/_shared/material.module';
import { ReactiveFormsModule } from '@angular/forms';
import { IngredientEditComponent } from './ingredient-edit/ingredient-edit.component';

@NgModule({
  imports: [
    CommonModule,
    MatDialogModule,
    MaterialModule,
    ReactiveFormsModule
  ],
  exports: [
    IngredientCardComponent,
    IngredientListComponent,
    IngredientAddComponent,
    IngredientEditComponent
  ],
  declarations: [
    IngredientCardComponent,
    IngredientListComponent,
    IngredientAddComponent,
    IngredientEditComponent
  ],
  entryComponents: [
    IngredientAddComponent,
    IngredientEditComponent
  ]
})
export class IngredientModule { }
