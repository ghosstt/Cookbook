import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { BsDropdownModule, TabsModule } from 'ngx-bootstrap';
import { AppRoutingModule } from './app-routing.module';
import { SharedModule } from './_shared/shared.module';
import { RecipeModule } from './_components/recipes/recipe.module';
import { IngredientModule } from './_components/ingredients/ingredient.module';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { JwtModule, JWT_OPTIONS } from '@auth0/angular-jwt';
import { AppComponent } from './app.component';
import { LoginComponent } from './_components/login/login.component';
import { HomeComponent } from './_components/home/home.component';
import { AuthService } from './_services/auth.service';
import { AlertifyService } from './_services/alertify.service';
import { AuthGuard } from './_guards/auth.guard.ts';
import { HttpErrorInterceptor } from './_interceptors/http-error-interceptor';
import { MaterialModule } from './_shared/material.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RegisterComponent } from './_components/register/register.component';

export const tokenGetter = () => localStorage.getItem('token');

@NgModule({
   declarations: [
      AppComponent,
      LoginComponent,
      RegisterComponent,
      HomeComponent
   ],
   imports: [
      BrowserModule,
      AppRoutingModule,
      HttpClientModule,
      ReactiveFormsModule,
      BsDropdownModule.forRoot(),
      JwtModule.forRoot({
         config: {
            tokenGetter,
            whitelistedDomains: ['localhost:5000'],
            blacklistedRoutes: ['localhost:5000/api/auth']
         }
      }),
      SharedModule,
      MaterialModule,
      RecipeModule,
      IngredientModule,
      BrowserAnimationsModule
   ],
   providers: [
      AuthService,
      AlertifyService,
      AuthGuard,
      {
         provide: HTTP_INTERCEPTORS,
         useClass: HttpErrorInterceptor,
         multi: true,
      }
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
