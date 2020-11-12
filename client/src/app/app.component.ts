import { HttpClient } from '@angular/common/http';
import { OnInit } from '@angular/core';
import { Component } from '@angular/core';
import { IPagination } from './shared/models/IPagination';
import { IProduct } from './shared/models/IProduct';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements OnInit {
  title = 'E-Commerce';
  // products: IProduct[];

  constructor(private http: HttpClient) {}
  ngOnInit(): void {
    // this.http
    //   .get('https://localhost:44321/api/products')
    //   .subscribe((response: IPagination) => {
    //     this.products = response.data;
    //   });
  }
}
