import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MainservService } from 'src/services/mainserv.service';
import { car } from '../../models/carsdata';
import { PaymentserviceService } from 'src/services/paymentservice.service';
import jsPDF from 'jspdf';
import { Router } from '@angular/router';

@Component({
  selector: 'app-bookingcart',
  templateUrl: './bookingcart.component.html',
  styleUrls: ['./bookingcart.component.css']
})
export class BookingcartComponent {

  bookcardata!: Array<car>;
  cardata!: Array<car>;
  flag: boolean = false;
  email!: string | null;
  amt: any = 10000;
  bookingamountform!: FormGroup;
  constructor(private demo: MainservService, private fb: FormBuilder, private http: HttpClient, private serv: PaymentserviceService,private route :Router) {
    this.bookingamountform = this.fb.group({
      amount: ['', [Validators.required, Validators.min(10000), Validators.max(25000)]]
    })

    this.bookingamountform.patchValue({ amount: this.amt })



    this.email = localStorage.getItem('useremail')
    let i = localStorage.getItem('id')
    this.demo.getallcars().subscribe((p: any) => {
      //console.log(p);
      this.cardata = p

      // //console.log(this.cityarr);
      let carid: string | null = localStorage.getItem('carid')
      this.bookcardata = this.cardata.filter((x: any) => x.carid == carid)

      //console.log(this.bookcardata);




    });
  }

  get amount() {
    return this.bookingamountform.get('amount')
  }

  cartamount() {
    this.amt = this.bookingamountform.value.amount;
    // //console.log(this.bookingamountform.value);

    //console.log(this.amt);

  }
  ordercar(pay: number, email: any) {
    let id = localStorage.getItem('id')
    let carid = localStorage.getItem('carid')
    let bookdata = { userid: id, createdby: id, modifiedby: id, carid: carid }

    this.serv.createOrder(pay).subscribe(
      {
        next: (resp: any) => {
          const options = {
            key: 'rzp_test_A5ZSz6riT6Yh0l',
            amount: pay * 100,
            currency: 'INR',
            name: 'Spinny',
            description: "description",
            order_id: resp.OrderId,


            handler: (response: any) => {
              // Handle successful payment
              //console.log(response);
              //console.log(response.razorpay_payment_id);
              //console.log(options);





              const httpOptions = {
                headers: new HttpHeaders({
                  'Authorization': 'Basic ' + btoa('rzp_test_A5ZSz6riT6Yh0l:OH1axejjA5HZ2jYYnJhP2XT4')
                })
              };
              // book cars
              this.demo.bookcar(bookdata).subscribe(data => {
                //console.log(data);
                const orderitem = localStorage.setItem('itemid', data)

                var userid = localStorage.getItem('id')
                var itemid = localStorage.getItem('orderitem')


                // const obj2 = {amount:options.amount,}
                // const data = {...obj1,...options}
                const obj1 = { paymentId: response.razorpay_payment_id, userid: userid, itemid: data }
                //console.log(obj1);
                // //console.log(data);
                // payment
                this.demo.payment(obj1).subscribe(data => {
                  //console.log(data);
                  this.generateInvoicePDF(data)
                  let i = localStorage.getItem('carid')
                  // update-payment-table
                  this.demo.paymenttable(i,data).subscribe(d => {
                    //console.log(d);
                    // alert("Car has been Sold")
                    // this.route.navigate([''])
                  })

                })
              })

            },
            prefill: {
              name: 'Aman',
              email: email,
              contact: '6352288527'
            }
          };

          const rzp1 = new (window as any).Razorpay(options);
          rzp1.open();
        },
        error: (err: any) => {
          alert("Error While Loading Razorpay")
        }
      }
    )

  }

  flagged() {
    this.flag = true
  }


  generateInvoicePDF(cardata: any) {
    const doc = new jsPDF();
    const totalPagesExp = '{total_pages_count_string}';

    // Invoice title and header settings
    const invoiceTitle = 'Car Booking Invoice';
    const invoiceTitleFontSize = 24;
    const headerColor = '#4CAF50';
    const headerFontSize = 18;

    // Content settings
    const contentMargin = 10;
    const contentYStart = 60;
    const lineHeight = 12;
    const additionalInfoY = contentYStart + lineHeight * 5;

    // Styling for table
    const tableHeaders = ['Payment ID', 'Payment Amount', 'Payment Method', 'Payment Date', 'Status'];
    const tableFontSize = 12;
    const tableColor = '#333';
    const tableHeadersColor = '#222';
    const tableBodyColor = '#444';

    // Customized header
    doc.setFontSize(invoiceTitleFontSize);
    doc.setTextColor(headerColor);
    doc.text(invoiceTitle, contentMargin, contentYStart);

    // Payment details section
    doc.setFontSize(headerFontSize);
    doc.setTextColor(headerColor);
    doc.text('Payment Details', contentMargin, contentYStart + lineHeight);

    // Generate the table using autoTable
    (doc as any).autoTable({
      head: [tableHeaders],
      body: [[
        cardata.paymentId,
        cardata.amount,
        cardata.paymentmethod,
        cardata.time,
        cardata.status
      ]],
      startY: contentYStart + lineHeight * 2,
      headStyles: {
        fillColor: tableHeadersColor,
        textColor: '#FFF',
        fontSize: tableFontSize
      },
      bodyStyles: {
        textColor: tableBodyColor,
        fontSize: tableFontSize
      },
      theme: 'grid'
    });

    // Additional information section
    doc.setFontSize(headerFontSize);
    doc.setTextColor(headerColor);
    doc.text('Additional Information', contentMargin, additionalInfoY);

    // Display additional information about the payment
    doc.setFontSize(tableFontSize);
    doc.setTextColor(tableColor);
    doc.text(`Total Amount: $${cardata.amount}`, contentMargin, additionalInfoY + lineHeight);

    // Save the PDF with a specific name (use the payment ID in the filename)
    doc.save(`car_booking_invoice_${cardata.paymentId}.pdf`);
  }


}
