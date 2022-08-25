import { Injectable } from '@angular/core';
import { Input, Output, EventEmitter } from '@angular/core';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';


@Injectable({
  providedIn: 'root'
})
export class PostService {

  constructor(private httpClient: HttpClient) { }
  @Output() newPostsAvailableEvent = new EventEmitter<PostInfo[]>();

  private storedPostInfos: PostInfo[] = [];

  public GetInforFromServer() {
    let apiURL: string = "https://jsonplaceholder.typicode.com/posts";
    this.httpClient.get<PostInfo[]>(apiURL).subscribe((gotData) => {
      this.storedPostInfos = gotData;
      this.newPostsAvailableEvent.emit(this.storedPostInfos);
    });
  }
}


export class PostInfo {
  public userId: number = 0;
  public id: string = "";
  public title: string = "";
  public body: string = "";
} 
