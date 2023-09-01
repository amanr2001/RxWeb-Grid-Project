import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Route } from '@angular/router';
import { LoaderService } from 'src/services/loader.service';
import { MainservService } from 'src/services/mainserv.service';
import { car } from '../../models/carsdata';
import { date } from '../../models/testdrive';

@Component({
  selector: 'app-car-details',
  templateUrl: './car-details.component.html',
  styleUrls: ['./car-details.component.css']
})
export class CarDetailsComponent implements OnInit {


  testrideForm!: FormGroup;
  timearr: Array<any> = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10]
  // isinputdisabled: boolean = true;
  currentDate: string;
  currentDateTime: string;
  constructor(private demo: MainservService, private route: ActivatedRoute, private http: HttpClient, private fb: FormBuilder,private loader:LoaderService) {
    this.currentDate = new Date().toISOString().split('T')[0];
      this.currentDateTime = new Date().toISOString().slice(0, 16);
    this.testrideForm = this.fb.group({
      location: ['',Validators.required],
      date: ['', Validators.required],
      time:['',Validators.required]
    })

  }

    get loc(){
      return this.testrideForm.get("location")
    }
    get dateval(){
      return this.testrideForm.get("date")
    }
  cardetails: Array<car> = []
  cardata: Array<car> = []
  similarcars:Array<car>=[]

  ngOnInit(): void {

    // this.testrideForm.get('location')?.;

    // //console.log("hhhhhh");
    // this.loader.setFlag(true)
    // let i = localStorage.getItem('id')
    // this.demo.getallcars(i).subscribe((p: any) => {
    //   //console.log(p);
    //   this.cardata = p

    //   this.route.params.subscribe(p => {
    //     //console.log(p['id']);
    //     this.cardetails = this.cardata.filter((x: any) => x.carid == p['id'])

    //     //console.log(this.cardetails);
    //     localStorage.setItem('carid',this.cardetails[0].carid.toString() )
    //   this.loader.setFlag(false)


    //   })

    //   this.http.get<any>(this.demo.baseurl+"/Cars/similarcars/"+this.cardetails[0].carbrand).subscribe(data=>{
    //     //console.log(data);
    //     this.similarcars=data;
    //   })

    //   this.testrideForm.patchValue({ location: this.cardetails[0].loc })
    // });
    this.getcardata();


  }

  getcardata(){
    this.loader.setFlag(true)
    let i = localStorage.getItem('id')
    this.demo.getallcars().subscribe((p: any) => {
      //console.log(p);
      this.cardata = p

      this.route.params.subscribe(p => {
        //console.log(p['id']);
        this.cardetails = this.cardata.filter((x: any) => x.carid == p['id'])

        //console.log(this.cardetails);
        localStorage.setItem('carid',this.cardetails[0].carid.toString() )
      this.loader.setFlag(false)


      })

      this.http.get<any>(this.demo.baseurl+"/Cars/similarcars/"+this.cardetails[0].carbrand).subscribe(data=>{
        //console.log(data);
        this.similarcars=data;
      })

      this.testrideForm.patchValue({ location: this.cardetails[0].loc })
    });
  }



  testdrive() {
    //console.log(this.cardetails[0].carid);
    let Carid = this.cardetails[0].carid;
    var userid =localStorage.getItem('id');
    console.log("aman");
    

    let intTd = { Userid: userid, carid: Carid }
    //console.log(intTd);

    this.demo.interestedtestdrive(intTd).subscribe({
      next:(data:any)=>{
        //console.log(data);
        localStorage.setItem('testid',data.testdid);
      },
      error:(err:any)=>{
        alert("Something Went Wrong.")
      }
    })

  }
  spinnyhub() {
    // this.testrideForm.get('location')?.disable();
    // //console.log("d");
    this.testrideForm.patchValue({ location: this.cardetails[0].loc })

  }
  location() {
    this.testrideForm.get('location')?.enable();
    this.testrideForm.patchValue({ location: '' })

  }
  x: number[] = []
  ondatechange(element: any) {
    //console.log(element.target.value);
    let Carid = this.cardetails[0].carid;
    let date =(element.target.value)
    //console.log(date);

    this.demo.GetTestTime(date,Carid).subscribe(data => {
      //console.log(data);
      this.x = data
    })
  }
dt!:Date
xyz:boolean=false
  timebtn(i: number) {

    this.dt = new Date(this.testrideForm.value.date);
    this.dt.setHours(this.timearr[i]+5)
this.xyz=true
  }

  // schedule td button
  scheduletd(){

let testid=localStorage.getItem('testid')

    const val = { location: this.testrideForm.value.location, date: this.dt.toISOString() }

    //console.log(this.testrideForm.value.location);
    //console.log(this.cardetails[0].loc);

    this.demo.confirmTestDrive(testid,val).subscribe({
      next:(data:any)=>{
        //console.log(data);
        alert("Test Drive Confirmed Successfully")

      },
      error:(err:any)=>{
        alert("Something Went Wrong.")
      }
    })
    this.testrideForm.reset();
  }
  ArrayGroup<Type>(arg: Array<Type>) {
    let CourseGroup:Array<Array<Type>>=[]
     for (let i = 0; i < arg.length/4; i++) {
      CourseGroup.push(arg.slice(i*4,(i+1)*4))
      }
     return CourseGroup;
   }


   
  wishlist(carid:number){
    let userid = localStorage.getItem('id')
    let data = {userid:userid,carid:carid}
    if(userid==null){
    alert("Please Login First");
    }else{

      this.demo.wishL(data).subscribe({
        next:(res:any)=>{
          console.log(res);
          this.getcardata()
        }
      })
    }

  }
}
