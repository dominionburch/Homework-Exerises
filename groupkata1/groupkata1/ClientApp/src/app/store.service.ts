import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class StoreService {

  private availableMenuItems: MenuItems[] = [
    { name: "Pizza", category: "main", price: 14.99 },
    { name: "Lasagna", category: "main", price: 12.99 },
    { name: "Apple Pie", category: "dessert", price: 4.99 },
    { name: "Coke", category: "drink", price: 1.99 },
  ];


  constructor(private httpClient: HttpClient) {

  }

  public getAvailableMenuItems(): MenuItems[] {
    return this.availableMenuItems;
  }

  public async GetCustomers(): Promise<Customer[]> {

    let callResult: UserList | any;

    try
    {
      callResult = await this.httpClient.get<UserList>("https://reqres.in/api/users?page=1").toPromise();
      
    }
    catch
    {
      callResult = new UserList();
      callResult.data = [];
    }
    return callResult.data;
  }

}


export class MenuItems {
  public name: string = "";
  public category: string = "";
  public price: number = 0;
}


export class Customer {
  public first_name: string = "";
  public last_name: string = "";
  public email: string = "";
}

export class UserList {
  public page: number = 0;
  public perPage: number = 0;
  public data: Customer[] = [];
}
