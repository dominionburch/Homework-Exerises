import { Component } from '@angular/core';

@Component({
  selector: 'app-counter-component',
  templateUrl: './counter.component.html'
})
export class CounterComponent {
  public currentCount = 0;
  public emptyCountries: ExampleCounty[] = [];
  public theCountries: ExampleCounty[] = [
    { value: 5, someString: "America", theColor: "blue" },
    { value: 5, someString: "Canada", theColor: "grey" },
    { value: 5, someString: "Lithuania", theColor: "purple" }
  ];

  public countryNames: any = ['American', 'Canada', 'Denmark'];


  constructor() {
    this.countryNames = this.theCountries;
  }

  public incrementCounter() {
    this.currentCount++;
  }

  public SomeDecision(): boolean {
    if ((this.currentCount % 2) == 0)
      return true;
    else
      return false;
  }
}

export class ExampleCounty {
  public value: number = 0;
  public someString: string = "";
  public theColor: string = "";
}
