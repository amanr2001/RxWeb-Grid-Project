import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CloudservService } from 'src/services/cloudserv.service';
import { gte } from 'src/app/customvalidators/date.validator';
import { MainservService } from 'src/services/mainserv.service';
import { sellcarmodel } from '../../models/selldata';

@Component({
  selector: 'app-sellcar',
  templateUrl: './sellcar.component.html',
  styleUrls: ['./sellcar.component.css'],
})
export class SellcarComponent implements OnInit {
  arr: any = [];
  sellform!: FormGroup;
  objarray!:any
  currentDate: string;
  currentDateTime: string;
  constructor(private demo: MainservService,private fb: FormBuilder,private cloud: CloudservService,private http: HttpClient) {

    this.currentDate = new Date().toISOString().split('T')[0];
    this.currentDateTime = new Date().toISOString().slice(0, 16);
    this.sellform = this.fb.group({
      Carbrand: ['', [Validators.required]],
      Carmodel: ['', [Validators.required]],
      Price: ['', [Validators.required,Validators.pattern(/\b([5-9][0-9]{4}|[1-9][0-9]{5}|[1-9][0-9]{6}|[1-9]0{7})\b/)]],
      Modelyear: ['', [Validators.required,gte]],
      Fueltype: ['', [Validators.required]],
      Owner: ['', [Validators.required]],
      Seats: ['', [Validators.required]],
      Cartype: ['', [Validators.required]],
      Cityid: ['', [Validators.required]],
      Kmdriven: ['', [Validators.required]],
      Frontview: ['', [Validators.required]],
      Leftside: ['', [Validators.required]],
      Rightside: ['', [Validators.required]],
      Backview: ['', [Validators.required]],
    });
  }

  // Getters for validation
  get carb(){
    return this.sellform.get('Carbrand')
  }

  get carm(){
    return this.sellform.get('Carmodel')
  }

  get price(){
    return this.sellform.get('Price')
  }

  get modelyear(){
    return this.sellform.get('Modelyear')
  }

  get Fuel(){
    return this.sellform.get('Fueltype')
  }
  get owner(){
    return this.sellform.get('Owner')
  }

  get seats(){
    return this.sellform.get('Seats')
  }
  get cartype(){
    return this.sellform.get('Cartype')
  }
  get cityid(){
    return this.sellform.get('Cityid')
  }
  get km(){
    return this.sellform.get('Kmdriven')
  }
  get fview(){
    return this.sellform.get('Frontview')
  }
  get lview(){
    return this.sellform.get('Leftside')
  }
  get rview(){
    return this.sellform.get('Rightside')
  }
  get bview(){
    return this.sellform.get('Backview')
  }
  // Getters Over
  ngOnInit(): void {
    this.demo.samplecars().subscribe((p) => {
      //console.log(p);
      this.arr = p;
    });

    this.demo.getobject().subscribe({
      next:(resp:any)=>{
        //console.log(resp);
        this.objarray=resp
      }
    })
  }

  model: any = [];
  cng(element: any) {
    //console.log(element.target.value);
    this.model = this.arr.filter((x: any) => x.value == element.target.value);
    //console.log(this.model);
  }

  bool: boolean = false;
  prceed() {
    if (this.bool == false) {
      this.bool = true;
    } else {
      this.bool = false;
    }
  }

  front!: File;

  onfront(event: any) {
    this.front = event.target.files[0];
  }
  back!: File;
  onback(event: any) {
    this.back = event.target.files[0];
  }
  left!: File;
  onleft(event: any) {
    this.left = event.target.files[0];
  }
  right!: File;
  onright(event: any) {
    this.right = event.target.files[0];
  }
  formarr: any = [];
  sell() {
    // this.formarr.push({})
    let selldata: sellcarmodel = this.sellform.value;
    //console.log(selldata.Frontview);

    // this.demo.sellcar(selldata).subscribe(p=>{
    //   //console.log(p);

    // })
    let i = localStorage.getItem('id');

    const frontdata = new FormData();
    frontdata.append('file', this.front);
    this.http.post(this.demo.baseurl + '/upload/upload', frontdata).subscribe({
      next: (resp: any) => {
        //console.log(resp.url);
        selldata.Frontview = resp.url;
        const backdata = new FormData();
        backdata.append('file', this.back);
        this.http
          .post(this.demo.baseurl + '/upload/upload', backdata)
          .subscribe({
            next: (back: any) => {
              //console.log(back.url);
              selldata.Backview = back.url;
              const leftdata = new FormData();
              leftdata.append('file', this.left);
              this.http
                .post(this.demo.baseurl + '/upload/upload', leftdata)
                .subscribe({
                  next: (left: any) => {
                    //console.log(left.url);
                    selldata.Leftside = left.url;
                    const rightdata = new FormData();
                    rightdata.append('file', this.right);
                    this.http
                      .post(this.demo.baseurl + '/upload/upload', rightdata)
                      .subscribe({
                        next: (right: any) => {
                          //console.log(right.url);
                          selldata.Rightside = right.url;
                          this.http
                            .post(
                              this.demo.baseurl + '/Cars/insertdata/' + i,
                              selldata
                            )
                            .subscribe((response) => {
                              //console.log(response);
                              alert("Car Sold Successfully.")
                            });
                        },
                        error: (rerr: any) => {
                          //console.log(rerr);
                        },
                      });
                  },
                  error: (lerr: any) => {
                    //console.log(lerr);
                  },
                });
            },
            error: (berr: any) => {
              //console.log(berr);
            },
          });
      },
      error: (err: any) => {
        //console.log(err);
      },
    });

    //
    // this.cloud.uploadimage(this.front as File,"spinny").subscribe({
    //   next:(resp:any)=>{
    //     selldata.Frontview=resp.secure_url;
    //     //console.log(selldata);

    //   }
    // })
  }
}
