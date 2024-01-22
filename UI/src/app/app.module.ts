import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './core/components/navbar/navbar.component';
import { CityListComponent } from './features/city/city-list/city-list.component';
import { AddCityComponent } from './features/city/add-city/add-city.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { PointOfInterestListComponent } from './features/point-of-interest/point-of-interest-list/point-of-interest-list.component';
import { AddPointofinterestComponent } from './features/point-of-interest/add-pointofinterest/add-pointofinterest.component';
import { EditCityComponent } from './features/city/edit-city/edit-city.component';
import { EditPointofinterestComponent } from './features/point-of-interest/edit-pointofinterest/edit-pointofinterest.component';
import { HomeComponent } from './features/home/home/home.component';
import { LoginComponent } from './features/login/login.component';
import { SignupComponent } from './features/signup/signup.component';
import { FooterComponent } from './core/components/footer/footer.component';
import { SearchComponent } from './features/search/search.component';



@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    CityListComponent,
    AddCityComponent,
    PointOfInterestListComponent,
    AddPointofinterestComponent,
    EditCityComponent,
    EditPointofinterestComponent,
    HomeComponent,
    LoginComponent,
    SignupComponent,
    FooterComponent,
    SearchComponent,
 
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule,
    
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
