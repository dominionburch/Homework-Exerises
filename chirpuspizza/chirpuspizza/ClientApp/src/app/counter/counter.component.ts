import { Component } from '@angular/core';

@Component({
  selector: 'app-counter-component',
  templateUrl: './counter.component.html'
})
export class CounterComponent {
  public currentCount = 0;

  public Item: MenuItem[] = [
    { ItemName: "Chicken Fingers", Category: "dinner", Price: 11.99 },
    { ItemName: "Pizza", Category: "dinner", Price: 11.99 },
    { ItemName: "Wings", Category: "side", Price: 8.99 },
    { ItemName: "Breadsticks", Category: "side", Price: 5.99 },
    { ItemName: "Ceasar Salad", Category: "salad", Price: 4.99 },
    { ItemName: "Cinnamon Roll", Category: "dessert", Price: 8.99 }
  ];


  public incrementCounter() {
    this.currentCount++;
  }



}

export class MenuItem {
  public ItemName: string = "";
  public Category: string = "";
  public Price: number = 0;
}
