import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CityListComponent } from './features/city/city-list/city-list.component';
import { AddCityComponent } from './features/city/add-city/add-city.component';
import { PointOfInterestListComponent } from './features/point-of-interest/point-of-interest-list/point-of-interest-list.component';
import { AddPointofinterestComponent } from './features/point-of-interest/add-pointofinterest/add-pointofinterest.component';
import { EditCityComponent } from './features/city/edit-city/edit-city.component';
import { EditPointofinterestComponent } from './features/point-of-interest/edit-pointofinterest/edit-pointofinterest.component';
import { HomeComponent } from './features/home/home/home.component';
import { LoginComponent } from './features/login/login.component';
import { SignupComponent } from './features/signup/signup.component';
import { SearchComponent } from './features/search/search.component';


const routes: Routes = [
  {
    path: 'lists/cities',
    component: CityListComponent
  },
  {
    path: 'lists/cities/add',
    component: AddCityComponent
  },
  {
    path: 'lists/pointsofinterest',
    component: PointOfInterestListComponent
  },
  {
    path: 'lists/pointofinterest/add',
    component: AddPointofinterestComponent
  },
  {
    path: 'lists/cities/edit/:id',
    component: EditCityComponent
  },
  {
    path: 'lists/pointsofinterest/edit/:pointCityName/:id',
    component: EditPointofinterestComponent
  },
  {
    path: '',
    component: HomeComponent
  },
  {
    path: 'login',
    component: LoginComponent
  },
  {
    path: 'signup',
    component: SignupComponent
  },
  {
    path: 'search/:obj',
    component: SearchComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
