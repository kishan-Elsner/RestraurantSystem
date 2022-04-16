import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { MatDialog,MatDialogConfig } from '@angular/material/dialog';
import { OrderService } from 'src/app/shared/order.service';
import { OrderItemComponent } from '../order-item/order-item.component';

@Component({
  selector: 'app-order',
  templateUrl: './order.component.html'
})
export class OrderComponent implements OnInit {

  constructor(public  service: OrderService,private dialog:MatDialog ) { }

  ngOnInit(): void {
    this.resetForm();
  }
  
  resetForm(from ?: NgForm)
  {
    if(from != null)
        from.resetForm();
      this.service.formData={
          OrderID:0,
          OrderNo:Math.floor(100000+Math.random()*900000).toString(),
          CustomberId:0,
          PMethod:'', 
          GTotal:0
        };
        this.service.orderItems=[];
       
      
    
  }
   
  AddEditOrdeName(OrderItemIndex:any,OrderId:any)
  {
      const dialogconfing=new MatDialogConfig();
      dialogconfing.autoFocus=true;
      dialogconfing.disableClose=true;
      dialogconfing.width="50%";
      dialogconfing.data={OrderItemIndex,OrderId};

      this.dialog.open(OrderItemComponent, dialogconfing );
     
  }
}
