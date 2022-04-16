import { Component, Inject, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Item } from 'src/app/shared/item.model';
import { ItemService } from 'src/app/shared/item.service';
// import { MAT_DIALOG_DATA,MatDialogRef } from '@angular/material';
import { OrderItem } from 'src/app/shared/order-item.model';
import { OrderService } from 'src/app/shared/order.service';


@Component({
  selector: 'app-order-item',
  templateUrl: './order-item.component.html',
})
export class OrderItemComponent implements OnInit {

  formData:OrderItem;
   itemList:Item[];
   isValid=true;

  constructor(
    @Inject(MAT_DIALOG_DATA) public data:any,
    public dialog:MatDialogRef<OrderItemComponent>,
    private itemService:ItemService,
    private  orderService:OrderService) { }

  ngOnInit(): void {

     this.itemService.get().then(res =>  this.itemList = res as Item[]);
     if(this.validationFrom(form.value))
     {
     if(this.data.orderItemIndex==null)
      {
       

      this.formData={

        OrderitemID:null,
        OrderID:0,
        ItemID:0,
        ItemName:'', 
        price:0,
        Quantity:0,
        Total:0
      }
      
    }
    else{
      this.formData=Object.assign({},this.orderService.orderItems[this.data.orderItemIndex]);
    }
  }
     
     
  }

  //This Most Importence line 
  updatePrice(ctrl:any)
  {
    if(ctrl.selectedIndex==0)
    {
      this.formData.price=0;
      this.formData.ItemName='';
    }

    else
    {
        this.formData.price =  this.itemList[ctrl.selectedIndex-1].Price;
        this.formData.ItemName =this.itemList[ctrl.selectedIndex-1].Name;
    }

  }
  UpdateTotal()
  {
    this.formData.Total=parseFloat((this.formData.Quantity * this.formData.price).toFixed(2));
  }

  onSubmit(form:NgForm)
  {
    if(this.validationFrom(form.value))
    {
      this.orderService.orderItems.push(form.value);
      this.dialog.close();
    }
  }
  validationFrom(formdata:OrderItem)
  {
      this.isValid = true;
      if(formdata.ItemID==0)
        this.isValid=true;
      else if(formdata.Quantity==0)
          this.isValid=false;
      return this.isValid;
  }
}
