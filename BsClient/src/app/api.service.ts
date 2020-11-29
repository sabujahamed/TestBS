import { Posts } from './Models/Posts';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
    providedIn: 'root'
  })
export class ApiService {
    // tslint:disable-next-line:no-inferrable-types
    private apiURL = "https://localhost:44313/api/Post/GetPostDetails";


constructor(private httpClient: HttpClient) { }



// tslint:disable-next-line:typedef
public getAll(obj: any ){
    return this.httpClient.post(this.apiURL, obj);
}
}
