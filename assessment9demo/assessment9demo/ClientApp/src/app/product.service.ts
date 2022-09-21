import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor() { }

  private theProducts: ProductInfo[] = [
    { name: "Shampoo", productID: "0", price: 2.00 },
    { name: "Batmobile", productID: "1", price: 500000.00 },
    { name: "Running Shoes", productID: "2", price: 125.00 },
    { name: "Coyote Pee", productID: "3", price: 20.00 },
    { name: "Pencil", productID: "4", price: 1.00 },
    { name: "Graphics Card", productID: "5", price: 150.00 }
  ]


  public getAllProducts(): ProductInfo[] {
    return this.theProducts;
  }
}


export interface ProductInfo {
  name: string;
  productID: string;
  price: number;
}
