import { Component } from '@angular/core';
import { HttpClientModule } from "@angular/common/http";
import { PostService, PostInfo } from '../post.service'; 

@Component({
  selector: 'app-counter-component',
  templateUrl: './counter.component.html'
})
export class CounterComponent {
  public currentCount = 0;

  public incrementCounter() {
    this.currentCount++;
  }

  public loadedPosts: PostInfo[] = [];

  constructor(private thisPostService: PostService)
  {

  }

  public async testA() {
    console.log("Test A was called");
    const promise = new Promise(function (resolve, reject) {
      setTimeout(function () {
        resolve('Promise returns after 1.5 second!');
      }, 1500);
    });
    await promise.then(function (value) {
      console.log(value);
      // Promise returns after 1.5 second!
    });
  }
  public testB() {
    // console.log("Test B was called");
    this.thisPostService.newPostsAvailableEvent.subscribe((gotData) => {
      this.loadedPosts = gotData;
      console.log("Data arrived!  We got " + gotData.length.toString() + " records.");
    })
    this.thisPostService.GetInforFromServer();
  }

}
