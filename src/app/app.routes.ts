import { Routes } from '@angular/router';
import { Home } from './home/home';
import { Books } from './books/books';
import { Services } from './services/services';
import { Contactus } from './contactus/contactus';

export const routes: Routes = [
  { path: '', redirectTo: 'home', pathMatch: 'full' },
  { path: 'home', component: Home },
  { path: 'books', component: Books },
  { path: 'services', component: Services },
  { path: 'contact', component: Contactus }
];