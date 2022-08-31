import { Component } from '@angular/core';

@Component({
  selector: 'app-counter-component',
  templateUrl: './counter.component.html'
})

export class CounterComponent
{
  public currentCount = 0;
  
  constructor()
  {
    //this.countryNames = this.theCountries;
  }

  
  public countries: Country[] =
  [
    { name: "Egypt", language: "Arabic", colors: "red" },
    { name: "Mexico", language: "Spanish", colors: "green" },
    { name: "Brazil", language: "Portugese", colors: "blue" },
    { name: "Italy", language: "Italian", colors: "purple" },
    { name: "Netherlands", language: "Dutch", colors: "yellow" },
    { name: "Japan", language: "Japanese", colors: "crimson" },
    { name: "China", language: "Mandarin or Cantonese", colors: "orange" },
    { name: "America", language: "English", colors: "blue" },
  ]

  public incrementCounter()
  {
    this.currentCount++;
  }

  public SomeDecision(): boolean
  {
    if ((this.currentCount % 2) == 0)
      return true;
    else
      return false;
  }

  public OnClickedChangeCountry(): void
  {
    let countryFromUser: string | null = '';
    countryFromUser = prompt('Please enter the name of a country');
    let foundCountry: Country = new Country;
    for (let currCountry = 0; currCountry < this.countries.length; currCountry++)
    {
      if (countryFromUser == this.countries[currCountry].name)
      {
        foundCountry = this.countries[currCountry];
        break;
      }
    }

    let foundCountryName = document.getElementById("CountryName");
    foundCountryName!.innerText = foundCountry?.name;

    let foundCountryLanguage = document.getElementById("CountryOfficialLanguage");
    foundCountryLanguage!.innerText = foundCountry?.language;

    let newColorString = "color: " + foundCountry?.colors;
    foundCountryName!.setAttribute("style", newColorString);

    foundCountryLanguage!.setAttribute("style", newColorString);

  }
}





export class Country
{
  public name: string = "";
  public language: string = "";
  public colors: string = "";
}
