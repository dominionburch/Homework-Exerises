import { Component, OnInit } from '@angular/core';
import { CartService } from '../cart.service';
import { Details, DonutService } from '../donut.service';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {

  constructor(private cartService: CartService) {
  }

  public items = this.cartService.getItems();

  ngOnInit(): void {
  }

  public removeFromCart(items: Details[], item: Details) {
    
    console.log("hit removeFromCart code " + item.name);
    this.items = this.cartService.getItems();
    for (var i = 0; i < items.length; i++) {
      console.log("hit loop" + i.toString()) + " " + item.id.toString();
      if (items[i].id == item.id)
      {
        items.splice(i, 1);
        window.alert('Your donut has been removed from the cart!' + i.toString());
        console.log("Idx: " + i.toString());
        break;
      }
    }
  }

  public clearCart() {
    this.cartService.clearCart();
  }


}
