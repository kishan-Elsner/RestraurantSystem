import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ItemService {
  getItemList() {
    throw new Error('Method not implemented.');
  }

  constructor(private http:HttpClient) { }

  get(){
  return  this.http.get(environment.apiUrl + '/Item').toPromise();
  }
}
