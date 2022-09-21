import { Component, OnInit } from '@angular/core';
import { StoreService, MenuItems, UserList, Customer } from '../store.service';

@Component({
  selector: 'app-menu-display',
  templateUrl: './menu-display.component.html',
  styleUrls: ['./menu-display.component.css']
})
export class MenuDisplayComponent implements OnInit {

  public theMenuItems: MenuItems[] = [];
  public customer: Customer[] = [];
  

  constructor(private myMenuItemService: StoreService, private myStoreService: StoreService) {
    this.theMenuItems = myMenuItemService.getAvailableMenuItems();
  }

  async ngOnInit(): Promise<void> {
    this.customer = await this.myStoreService.GetCustomers();
  }

}
