import { Injectable } from '@angular/core';
import { OrderItem } from './order-item.model';
import { Order } from './order.model';

@Injectable({
  providedIn: 'root'
})
export class OrderService {
  formData: Order;
  //this line use list data include list.
  orderItems:OrderItem[];

  constructor() { }
}
