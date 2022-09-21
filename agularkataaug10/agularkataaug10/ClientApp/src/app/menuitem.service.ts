import { Inject, Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class MenuitemService {

  constructor(private httpCLient: HttpClient) {

  }

  private readonly userRequestUrl: string = "https://reqres.in/api/users?page=1"

  public GetAvailableMenuItems(): MenuItem[] {
    return this.availableMenuItems;
  }

  public async GetUserList(): Promise<ExampleUser> {

  }

  private userList: ExampleUser[] = [];
  private readonly availableMenuItems: MenuItem[] = [
    { name: "Apples", price: 3.99, foodCategory: "fruit" },
    { name: "Bananas", price: 1.99, foodCategory: "fruit" },
    { name: "Avocado", price: 4.99, foodCategory: "vegetable" },
    { name: "Ribeye", price: 13.99, foodCategory: "meat" }
  ];
}



export class MenuItem {
  public name: string = "";
  public price: number = 0;
  public foodCategory: string = "";
}



export class ExampleUserList {
  public page: number = 0;
  public per_page: number = 0;
  public total: number = 0;
  public total_pages: number = 0;
  public data: ExampleUser[] = [];
}

export class ExampleUser {
  public id: number = 0;
  public email: string = "";
  public first_name: string = "";
  public last_name: string = "";
  public avatar: string = "";
}
