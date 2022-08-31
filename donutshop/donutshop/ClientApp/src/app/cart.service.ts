import { Injectable } from '@angular/core';
import { Details, DonutService } from './donut.service';

@Injectable({
  providedIn: 'root'
})
export class CartService {

  constructor() { }

  public items: Details[] = [];

  addToCart(details: Details) {
    this.items.push(details);
  }

  getItems() {
    return this.items;
  }

  clearCart() {
    this.items = [];
    return this.items;
  }

}
