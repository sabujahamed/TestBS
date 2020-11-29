import { Component, OnInit } from '@angular/core';
import { ApiService } from './api.service';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = [];
  // tslint:disable-next-line:typedef

  constructor(private apiService: ApiService){}
  // tslint:disable-next-line:typedef
  OnInit(){
    this.apiService.getAll( this.title).subscribe((res: any ) => {
      console.log(res);
      this.title  = res.data;
     });

  }

}
