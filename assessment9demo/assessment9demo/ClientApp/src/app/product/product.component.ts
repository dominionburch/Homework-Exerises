import { Component, OnInit } from '@angular/core';
import { ProductService, ProductInfo } from '../product.service';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {

  constructor(private myProductService: ProductService) { }


  public theProducts: ProductInfo[] = [];


  ngOnInit(): void {
    this.theProducts = this.myProductService.getAllProducts();
  }

}
