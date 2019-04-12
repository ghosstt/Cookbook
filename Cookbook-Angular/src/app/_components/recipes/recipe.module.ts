import { NgModule } from '@angular/core';
import { RecipeCardComponent } from './recipe-card/recipe-card.component';
import { RecipeListComponent } from './recipe-list/recipe-list.component';
import { CommonModule } from '@angular/common';
import { RecipeAddComponent } from './recipe-add/recipe-add.component';
import { MaterialModule } from 'src/app/_shared/material.module';
import { MatDialogModule } from '@angular/material';
import { ReactiveFormsModule } from '@angular/forms';
import { IngredientModule } from '../ingredients/ingredient.module';
import { RecipeEditComponent } from './recipe-edit/recipe-edit.component';

@NgModule({
  imports: [
    CommonModule,
    MatDialogModule,
    MaterialModule,
    ReactiveFormsModule,
    IngredientModule
  ],
  exports: [
    RecipeCardComponent,
    RecipeListComponent,
    RecipeAddComponent,
    RecipeEditComponent
  ],
  declarations: [
    RecipeCardComponent,
    RecipeListComponent,
    RecipeAddComponent,
    RecipeEditComponent
  ],
  entryComponents: [
    RecipeAddComponent,
    RecipeEditComponent
  ]
})
export class RecipeModule { }
