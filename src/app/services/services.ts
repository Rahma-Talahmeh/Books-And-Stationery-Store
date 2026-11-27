
/*
import { Injectable } from '@angular/core';

export interface Product {
  id: number;
  title: string;
  category: 'Books' | 'Stationery';
  price: number;
  image: string;
  inStock: boolean;
}





// داخل src/app/services/services.ts:
import { Component } from '@angular/core';

@Component({
  selector: 'app-services',
  standalone: true,
  imports: [],
  templateUrl: './services.html',
  styleUrl: './services.css'
})
export class Services {}




@Injectable({
  providedIn: 'root'
})
export class StoreService {
  storeName = 'Quill & Shelf';
  welcomeMessage = 'Curated classic books and timeless writing tools.';
  cartCount = 0;
  lastAddedItem = '';

  products: Product[] = [
    {
      id: 1,
      title: 'The Art of Quiet Reading',
      category: 'Books',
      price: 18.5,
      image: 'https://images.unsplash.com/photo-1544947950-fa07a98d237f?auto=format&fit=crop&w=600&q=80',
      inStock: true
    },
    {
      id: 2,
      title: 'Brass Fountain Pen Set',
      category: 'Stationery',
      price: 29.0,
      image: 'https://images.unsplash.com/photo-1583485088034-697b5bc54ccd?auto=format&fit=crop&w=600&q=80',
      inStock: true
    },
    {
      id: 3,
      title: 'Linen Hardcover Journal',
      category: 'Stationery',
      price: 14.0,
      image: 'https://images.unsplash.com/photo-1531346878377-a5be20888e57?auto=format&fit=crop&w=600&q=80',
      inStock: true
    },
    {
      id: 4,
      title: 'Classic World Essays',
      category: 'Books',
      price: 22.0,
      image: 'https://images.unsplash.com/photo-1512820790803-83ca734da794?auto=format&fit=crop&w=600&q=80',
      inStock: false
    }
  ];

  addToCart(item: Product): void {
    if (!item.inStock) {
      return;
    }
    this.cartCount++;
    this.lastAddedItem = item.title;
  }
}
  */
 import { Component } from '@angular/core';

@Component({
  selector: 'app-services',
  standalone: true,
  imports: [],
  templateUrl: './services.html',
  styleUrl: './services.css'
})
export class Services {}