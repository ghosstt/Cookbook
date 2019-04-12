import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './_components/login/login.component';
import { HomeComponent } from './_components/home/home.component';
import { AuthGuard } from './_guards/auth.guard.ts';
import { PageNotFoundComponent } from './_shared/components/page-not-found/page-not-found.component';
import { RecipeListComponent } from './_components/recipes/recipe-list/recipe-list.component';
import { IngredientListComponent } from './_components/ingredients/ingredient-list/ingredient-list.component';
import { RecipeListResolver } from './_resolvers/recipe-list.resolver';
import { IngredientListResolver } from './_resolvers/ingredient-list.resolver.';
import { RegisterComponent } from './_components/register/register.component';

const routes: Routes = [
  { path: '', redirectTo: 'home', pathMatch: 'full' },
  {
    path: '',
    runGuardsAndResolvers: 'always',
    canActivate: [AuthGuard],
    children: [
      {
          path: 'recipe/list',
          component: RecipeListComponent,
          resolve: { recipes: RecipeListResolver }
      },
      {
        path: 'ingredient/list',
        component: IngredientListComponent,
        resolve: { ingredients: IngredientListResolver }
      }
    ]
  },
  { path: 'home', component: HomeComponent, runGuardsAndResolvers: 'always', canActivate: [AuthGuard] },
  { path: 'login', component: LoginComponent, data: { animations: 'in' } },
  { path: 'register', component: RegisterComponent },
  { path: 'page-not-found', component: PageNotFoundComponent },
  { path: '**', redirectTo: 'page-not-found', pathMatch: 'full' }
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes)
  ],
  exports: [
    RouterModule
  ],
  providers: [
    RecipeListResolver,
    IngredientListResolver
  ]
})
export class AppRoutingModule { }
