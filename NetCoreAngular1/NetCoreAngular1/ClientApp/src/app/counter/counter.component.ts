import { Component } from '@angular/core';

@Component({
  selector: 'app-counter-component',
  templateUrl: './counter.component.html'
})
export class CounterComponent {
  public currentCount = 0;
  public title = "MyTest";
  public names = [
    'Fred', 'Julie', 'Sam', 'Olivia', 'Adam', 'Jennifer'
  ];


  /*
  public runTestA() {
    alert("Worked");
  }*/

  public runTestA() {
    let item1 = document.getElementById("item1");
    item1!.innerText = "Item 1 is different";
  }

  public incrementCounter() {
    this.currentCount++;
    let userName = this.GetUsersName(8);


    if (userName!.length > 15) {
      alert("User name    " + userName + "    is too long");
    }
    else
    {
      console.log("The user's name is: " + userName);
      alert("The user's name is: " + userName);
    }
    
  }



  public GetUsersName(minLength: number): string | null
  {
    let userName: string| null = "";
    while (userName!.length < minLength)
    {
      alert("Name " + userName + " cannot be lower than " + minLength);
      userName = prompt("Enter name ");
      if (userName!.length >= minLength) {
        // Do nothing because the test will pass if the condition is true
      }
      else
      {
        alert("The name " + userName + " is too short. ");
      }
    }
    return userName;
  }


  public countries: Country[] = [
    { name: "Egypt", officialLanguage: "Arabic", primaryColor: "red" },
    { name: "Mexico", officialLanguage: "Spanish", primaryColor: "green" },
    { name: "Brazil", officialLanguage: "Portugese", primaryColor: "blue" },
    { name: "Italy", officialLanguage: "Italian", primaryColor: "purple" },
    { name: "Netherlands", officialLanguage: "Dutch", primaryColor: "yellow" },
  ];

  public OnClickedChangeCountry(): void
  {
    let countryFromUser: string|null;
    countryFromUser = prompt("Enter a name of a country");
    let foundCountry: Country | null = null;

    for (let currCountry = 0; currCountry < this.countries.length; currCountry++)
    {
      if (countryFromUser == this.countries[currCountry].name)
      {
        foundCountry = this.countries[currCountry];
        break;
      }
    }

    let foundCountryName = document.getElementById("CountryName");
    foundCountryName!.innerText = foundCountry!.name;

    let foundCountryLanguage = document.getElementById("CountryOfficialLanguage");
    foundCountryLanguage!.innerText = foundCountry!.officialLanguage;


    let newColorString: string = "color:" + foundCountry!.primaryColor;
    foundCountryName!.setAttribute("style", newColorString);
    foundCountryLanguage!.setAttribute("style", newColorString);
  }

}

export class Country
{
  public name: string = "";
  public officialLanguage: string = "";
  public primaryColor: string = "";

}
