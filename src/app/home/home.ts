import { Component } from '@angular/core';
import { RouterLink } from '@angular/router';
import { Store } from '../store';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [RouterLink],
  template: `
    <section class="home-hero">
      <h1>{{ store.storeName }}</h1>
      <p>{{ store.welcomeMessage }}</p>
      <a routerLink="/books" class="hero-btn">Explore Catalog</a>
    </section>
  `,
  styles: [`
    .home-hero {
      text-align: center;
      padding: 60px 24px;
      background-color: #faf6f0;
      color: #2b1d16;
      min-height: 55vh;
    }
    .hero-btn {
      display: inline-block;
      margin-top: 16px;
      background-color: #b4652d;
      color: #fff;
      padding: 10px 22px;
      border-radius: 6px;
      text-decoration: none;
    }
  `]
})
export class Home {
  constructor(public store: Store) {}
}