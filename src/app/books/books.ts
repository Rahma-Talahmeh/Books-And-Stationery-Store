import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Store, Product } from '../store';

@Component({
  selector: 'app-books',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './books.html',
  styleUrl: './books.css'
})
export class Books {
  searchQuery = '';
  selectedCategory: 'All' | 'Books' | 'Stationery' = 'All';

  constructor(public store: Store) {}

  get filteredProducts(): Product[] {
    return this.store.products.filter((item: Product) => {
      const matchCategory =
        this.selectedCategory === 'All' || item.category === this.selectedCategory;
      const matchSearch = item.title
        .toLowerCase()
        .includes(this.searchQuery.trim().toLowerCase());
      return matchCategory && matchSearch;
    });
  }

  setCategory(category: 'All' | 'Books' | 'Stationery'): void {
    this.selectedCategory = category;
  }
}