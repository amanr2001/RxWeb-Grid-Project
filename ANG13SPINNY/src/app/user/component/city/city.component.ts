import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Route, Router, NavigationExtras } from '@angular/router';
import { MainservService } from 'src/services/mainserv.service';
import { filterobj } from '../../models/selldata';
import { car, objct } from '../../models/carsdata';
import * as $ from 'jquery'
import { SearchserService } from 'src/services/searchser.service';
import { LoaderService } from 'src/services/loader.service';

@Component({
  selector: 'app-city',
  templateUrl: './city.component.html',
  styleUrls: ['./city.component.css']
})
export class CityComponent implements OnInit {
  
  arr: Array<any> = []
  arrayofimages: Array<string> = []
  param: any;
  allcarsdata: Array<car> = []
  kmArray: any[] = ['5000', '10000', '15000', '20000', '25000']
  yearArray: any[] = ['2020', '2018', '2016', '2014', '2012']
  objarray!:objct;
  city!:string;
  constructor(private demo: MainservService, private route: ActivatedRoute, private router: Router, private http: HttpClient, private searchservice: SearchserService,private loader:LoaderService) {

    // this.filterobj.cars.push(this.searchservice.data)
    // //console.log(this.filterobj.cars);
    // this.filter()
    this.demo.getobject().subscribe({
      next:(resp:any)=>{
        console.log(resp);
        this.objarray=resp
      }
    })

    route.queryParamMap.subscribe(
      p => {
        let a = p.get('filter')
        let b = JSON.parse(a as string);
        //console.log(b);
        //console.log(p);
        //console.log(p.get('filter'));

      }

    )
    //console.log(this.param);
    this.route.queryParams.subscribe(
      params => {
        const searchterm = params['filter']
      }
    )

    //   let i = localStorage.getItem('id')
    // this.demo.getallcars(i).subscribe((p: any) => {
    //   //console.log(p);

    //   // //console.log(this.cityarr);
    //   this.arr = p

    //   this.route.params.subscribe(p => {
    //     //console.log(p['cityname']);
    //       this.city=p['cityname']

    //     this.allcarsdata = this.arr.filter(x => x.city == p['cityname'])

    //     //console.log(this.allcarsdata);
    //     this.filteredarr = this.allcarsdata
    //     this.route.params.subscribe(x=>{

    //       //console.log(x['carb']);
    //       this.filterobj.cars=[]
    //       this.searchval=x['carb']
    //       if(this.searchval){
    //      let i = this.filterobj.cars.findIndex(x=>x===this.searchval)
    //         if(i!==-1){

    //            this.filterobj.cars.splice(i,1);

    //           }
    //           this.searchval=x['carb']
    //       }
    //       this.onc("s")

    //       // //console.log(x['carb']);


    //       //console.log(this.filteredarr);
    //       //console.log(this.filterobj);

    //     })

    //   })
    // })
    this.getallcARS()
    this.filter()
  }

  getallcARS(){
    let i = localStorage.getItem('id')
    this.loader.setFlag(true)
    this.demo.getallcars().subscribe((p: any) => {
      //console.log(p);

      // //console.log(this.cityarr);
      this.arr = p

      this.route.params.subscribe(p => {
        //console.log(p['cityname']);
          this.city=p['cityname']

        this.allcarsdata = this.arr.filter(x => x.city == p['cityname'])

        //console.log(this.allcarsdata);
        this.filteredarr = this.allcarsdata
        this.route.params.subscribe(x=>{

          //console.log(x['carb']);
          this.filterobj.cars=[]
          this.searchval=x['carb']
          if(this.searchval){
         let i = this.filterobj.cars.findIndex(x=>x===this.searchval)
            if(i!==-1){

               this.filterobj.cars.splice(i,1);

              }
              this.searchval=x['carb']
          }
          this.onc("s")

          // //console.log(x['carb']);


          //console.log(this.filteredarr);
          //console.log(this.filterobj);

        })

      })
      this.loader.setFlag(false)
    })
  }



  // on init
  ngOnInit(): void {


    var myCarousel = document.querySelector('#myCarousel')


    $('.carousel .carousel-item').each(function () {
      var minPerSlide = 4;
      var next = $(this).next();
      if (!next.length) {
        next = $(this).siblings(':first');
      }
      next.children(':first-child').clone().appendTo($(this));

      for (var i = 0; i < minPerSlide; i++) {
        next = next.next();
        if (!next.length) {
          next = $(this).siblings(':first');
        }

        next.children(':first-child').clone().appendTo($(this));
      }
    });



    // get all cars models
    this.demo.getcarmodelsforfilter().subscribe((data: any) => {
      //console.log(data);
      this.carmodelfilterdata = data;
      //console.log(this.carmodelfilterdata);
    })


  }
  onsearch(event: any) {



  }



  sort(element: any) {
    //console.log(element.target.value);
    if (element.target.value == 1) {
      this.filteredarr = this.allcarsdata.sort((a, b) => {
        //console.log(a.createdDate);
        return new Date(b.createdDate).getTime() - new Date(a.createdDate).getTime()
      })
    }
    else if (element.target.value == 2) {
      this.filteredarr = this.allcarsdata.sort((a, b) => {
        return a.sellerprice - b.sellerprice
      })
    }
    else if (element.target.value == 3) {
      this.filteredarr = this.allcarsdata.sort((a, b) => {
        return b.sellerprice - a.sellerprice
      })
    }
    this.filter()
  }


  filteredarr: Array<car> = [];
  carmodelfilterdata: Array<string> = [];


  // filter object
  filterobj: filterobj = {
    cars: [],
    year: '',
    Fuel: [],
    kms: '',
  }

  // clear
  clearall() {
    this.filterobj.cars = []
    this.filterobj.Fuel = []
    this.filterobj.kms = ''
    this.filterobj.year = ''
    this.filter()

  }

  searchval: any;
  removeval:any;
  // check box


  onc(selectedValue: any) {
    // debugger;
    if (this.searchval ) {
      if(this.filterobj.cars.includes(this.searchval)){
        let i = this.filterobj.cars.findIndex(x=>x===this.searchval);
        if (i !== -1) {
          this.filterobj.cars.splice(i, 1)
        }
      }
      else{

        this.filterobj.cars.push(this.searchval);
        //console.log(this.filterobj.cars);
        this.filter()
        this.searchval = ""
      }

    }
    else if (selectedValue.target?.checked) {
      this.filterobj.cars.push(selectedValue.target.value)
    }
    else if (!selectedValue.target?.checked) {
      let i = this.filterobj.cars.findIndex(c => c === selectedValue.target.value);
      if (i !== -1) {
        this.filterobj.cars.splice(i, 1)
      }

    }
    // //console.log(this.filteredarr);

    // //console.log(this.filterobj);

    this.router.navigate([], {

      relativeTo: this.route,
      queryParams: { filter: JSON.stringify(this.filterobj) },
      queryParamsHandling: 'merge'
    });
    // //console.log(this.allcarsdata);
    this.filter()

  }

  onchange(select: any) {
    if (select.target.checked)
      this.filterobj.year = select.target.value



    //console.log(this.filterobj);
    this.filter()

  }


  onselkms(select: any) {

    if (select.target.checked) {
      this.filterobj.kms = select.target.value
    }
    else if (!select.target.checked) {
      this.filterobj.kms = '';
    }
    this.filter();
  }

  onchangefuel(select: any) {
    if (select.target.checked) {

      this.filterobj.Fuel.push(select.target.value);
    }
    else {
      let i = this.filterobj.Fuel.findIndex(x => x === select.target.value)
      if (i !== -1) {

        this.filterobj.Fuel.splice(i, 1)
      }
    }

    this.filter();
  }

  // onchangebody(select: any) {
  //   if (select.target.checked) {
  //     this.filterobj.body.push(select.target.value);
  //   }
  //   else {
  //     let i = this.filterobj.body.findIndex(x => x === select.target.value)
  //     if (i != -1) {
  //       this.filterobj.body.splice(i, 1);
  //     }
  //   }

  //   this.filter();
  // }


  filter() {
    let brands = this.filterobj.cars;
    let year = this.filterobj.year;
    let fuel = this.filterobj.Fuel;
    let kms = this.filterobj.kms;



    if (brands.length && fuel.length && kms.length) {

      this.filteredarr = this.allcarsdata.filter(c => Number(c.year) >= Number(year) && brands.includes(c.carbrand) && fuel.includes(c.fuel) && Number(c.kmdriven) >= Number(kms))
    }

    else if (kms.length && fuel.length) {
      this.filteredarr = this.allcarsdata.filter(c => Number(c.year) >= Number(year) && fuel.includes(c.fuel) && Number(c.kmdriven) >= Number(kms));

    }
    else if (kms.length && brands.length) {
      this.filteredarr = this.allcarsdata.filter(c => Number(c.year) >= Number(year) && Number(c.kmdriven) >= Number(kms) && brands.includes(c.carbrand))
    }
    else if (fuel.length && brands.length) {
      this.filteredarr = this.allcarsdata.filter(c => Number(c.year) >= Number(year) && fuel.includes(c.fuel) && brands.includes(c.carbrand))

    }
    else if (brands.length) {

      this.filteredarr = this.allcarsdata.filter(c => Number(c.year) >= Number(year) && brands.includes(c.carbrand))
    }
    else if (fuel.length) {
      this.filteredarr = this.allcarsdata.filter(c => Number(c.year) >= Number(year) && fuel.includes(c.fuel))

    }
    else if (year) {
      this.filteredarr = this.allcarsdata.filter(c => Number(c.year) >= Number(year))

    }
    else if (kms) {
      this.filteredarr = this.allcarsdata.filter(c => Number(c.kmdriven) >= Number(kms))

    }
    else {
      this.filteredarr = this.allcarsdata
    }
    //console.log(this.filteredarr);


  }


  wishlist(carid:number){
    let userid = localStorage.getItem('id')
    let data = {userid:userid,carid:carid}
    if(userid==null){
      alert("Please login first")
    }
    else{

      this.demo.wishL(data).subscribe({
        next:(res:any)=>{
          console.log(res);
          this.getallcARS();
        }
      })
      
    }
  }

}
