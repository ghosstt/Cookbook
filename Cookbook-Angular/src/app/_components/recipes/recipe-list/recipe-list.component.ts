import { Component, OnInit } from '@angular/core';
import { Recipe } from 'src/app/_models/recipe';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-recipe-list',
  templateUrl: './recipe-list.component.html',
  styleUrls: ['./recipe-list.component.css']
})
export class RecipeListComponent implements OnInit {
  recipes: Recipe[];

  constructor(private activatedRoute: ActivatedRoute) { }

  ngOnInit() {
    this.activatedRoute.data.subscribe(data => {
      // tslint:disable-next-line: no-string-literal
      this.recipes = data['recipes'];
    });
  }
}
