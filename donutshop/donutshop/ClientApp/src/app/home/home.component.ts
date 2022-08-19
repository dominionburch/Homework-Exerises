import { Component } from '@angular/core';
import { HttpClientModule } from "@angular/common/http";
import { DonutService, BigDonut, DonutInfo} from '../donut.service'; 

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})

export class HomeComponent {

  public loadedDonuts: BigDonut = new BigDonut();
  private isNewDonutsAvailableEventSubscribed: boolean = false;


  constructor(private thisDonutService: DonutService)
  {

  }

  public GetDonutList() {
    // The order is important here.  If we subscribe FIRST, we can guarantee we will receive
    // all data provided by the event.  If we subscribe SECOND, we may not.
    if (!this.isNewDonutsAvailableEventSubscribed) {
      this.thisDonutService.newDonutAvailableEvent.subscribe((gotData) => {
        for (let currElementNo = 0; currElementNo < gotData.count; currElementNo++)
          this.loadedDonuts.results.push(gotData.results[currElementNo]);
       console.log("Data arrived!  We got " + gotData.count.toString() + " records.");
      })
      this.isNewDonutsAvailableEventSubscribed = true;
    }
    this.thisDonutService.GetInfoFromServer();
  }


}



