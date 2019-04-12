import { Component, OnInit } from '@angular/core';
import { Ingredient } from 'src/app/_models/ingredient';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-ingredient-list',
  templateUrl: './ingredient-list.component.html',
  styleUrls: ['./ingredient-list.component.css']
})
export class IngredientListComponent implements OnInit {
  ingredients: Ingredient[];

  constructor(private activatedRoute: ActivatedRoute) { }

  ngOnInit() {
    this.activatedRoute.data.subscribe(data => {
      // tslint:disable-next-line: no-string-literal
      this.ingredients = data['ingredients'];
    });
  }
}
