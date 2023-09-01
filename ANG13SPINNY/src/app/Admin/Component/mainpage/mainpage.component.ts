import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { selecteduser, userlen } from '../../stores/userstore/userstore.selector';
import { loaddata } from '../../stores/sellrequeststore/store.action';
import { loaduser, loaduserdata } from '../../stores/userstore/userstore.action';
import { user } from '../../stores/models/usermodel';
import { Observable, from, map } from 'rxjs';
import { carreqlength } from '../../stores/sellrequeststore/store.selector';
import { loadorder } from '../../stores/orderstore/orderstore.action';
import { loadpayment } from '../../stores/paymentstore/paymentstore.action';
import { pay } from '../../stores/models/paymentmodel';
import {   last5Dpayments, paylen, selectpayment, totalpayment } from '../../stores/paymentstore/paymentstore.selector';
import { jsPDF } from 'jspdf';
// import 'jspdf-autotable';
import { HttpClient } from '@angular/common/http';


@Component({
  selector: 'app-mainpage',
  templateUrl: './mainpage.component.html',
  styleUrls: ['./mainpage.component.css']
})
export class MainpageComponent {
  // Custom Fonts Object


  udata!: any;
  userlen!: Observable<number>;
  carlen!: Observable<number>;
  paydata!: Observable<Array<pay>>;
  paylen!: Observable<number>;
  totalrevenue!: Observable<number>;
  last5Dpayment!: Observable<number>;
  p: any;
  b: any;

  constructor(private store: Store,private http:HttpClient) {

    this.store.dispatch(loaduser())
    this.store.dispatch(loadpayment())
    this.paydata = this.store.select(selectpayment)
    this.paylen = this.store.select(paylen)
    this.last5Dpayment = this.store.select(last5Dpayments)
    this.totalrevenue = this.store.select(totalpayment)
    this.store.dispatch(loadpayment())
    this.store.select(selecteduser)
    // this.udata = this.store.select(selecteduser)
    this.userlen = this.store.select(userlen)
    this.carlen = this.store.select(carreqlength)
    this.store.dispatch(loadorder())

    this.http.get("https://localhost:7011/api/Admin/getusers").subscribe(data=>{
      this.udata=data
      this.userdata2=data
      this.http.get("https://localhost:7011/api/Payment/getuserdataaa").subscribe({
        next:(res:any)=>{
          console.log(res);
          this.userdata = res
        }
      })
    })

    this
  }


  generatePDF() {
    const now = new Date();
    const year = now.getFullYear();
    const month = (now.getMonth() + 1); // Months are 0-based
    const day = (now.getDate());
    const hours = (now.getHours());
    const minutes = (now.getMinutes());
    const seconds = (now.getSeconds());
    this.paydata.subscribe((d: any) => {
      const doc = new jsPDF();
      const totalPagesExp = '{total_pages_count_string}';

      // Example: Create a table with payment data
      const headers = ['Payment ID', 'Status', 'Payment Method', 'Amount', 'Payment Date'];
      const data = d.map((payment: { paymentid: any; paymentstatus: any; paymentmethod: any; paymentamount: any; paymentdatetime: any; }) => [
        payment.paymentid,
        payment.paymentstatus,
        payment.paymentmethod,
        payment.paymentamount,
        payment.paymentdatetime,
      
      ]);

      doc.setFontSize(18);
      doc.text('Payment Report', 10, 20);

      // Generate the table using autoTable
      (doc as any).autoTable({
        head: [headers],
        body: data,
        startY: 30
      });

      // Save the PDF with a specific name
      doc.save(`payment_report${year}-${month}-${day} ${hours}:${minutes}:${seconds}.pdf`);
    });
  }


  userdata:Array<any>=[]
  userdata2:any=[]
  searchdata:Array<any>=[]
  search(keyword:any){
    if(keyword.length!=0){
      
      this.searchdata=this.userdata.filter(x=>x.toLowerCase().match(keyword.toLowerCase()))
      
      this.userdata2=this.udata.filter((x:any)=>this.searchdata.includes(x.username))
    }
    else{
      this.userdata2 = this.udata
    }

  
    console.log(this.udata);
    
    console.log(this.searchdata);
  }

  sort(element:any){
    console.log(element.target.value);
    if(element.target.value=='1'){
      this.userdata2 = this.udata.sort((x:any,y:any)=>{
        return x.username.localeCompare(y.username)
      })
      console.log(this.userdata2);
      
    }
    if(element.target.value=='2'){
      this.userdata2 = this.udata.sort((x:any,y:any)=>{
        return y.username.localeCompare(x.username)
      })
      console.log(this.userdata2);
      
    }
  }
}
