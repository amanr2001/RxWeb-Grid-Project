import { Component, EventEmitter, OnInit, Output, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { MainservService } from 'src/services/mainserv.service';
import { filterobj } from '../../models/selldata';
import { SearchserService } from 'src/services/searchser.service';
import { LoaderService } from 'src/services/loader.service';
import { RxSelectComponent } from '@rxweb/angular';
import { FormBuilder, FormGroup } from '@angular/forms';
import { HttpClientConfig } from '@rxweb/http';
import { log } from 'console';


@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

  @ViewChild('rxselect') rxSelect!: RxSelectComponent;
  searchEventName = '';

  keyProps: any = ['cityname','cityname'];
  keyProperties: any = ['carbrand','carbrand'];
  formGroup!: FormGroup;
  formdata!:FormGroup;

  morearr: Array<string> = [
    "About us", "Blog"
  ]

  cityarr: Array<any> = []
  cityname:any
  constructor(private demo: MainservService, private router: Router, private searchservice: SearchserService, private route: ActivatedRoute,private loader:LoaderService,private fb:FormBuilder) {
    HttpClientConfig.register({hostURIs:[{name:'API',uri:'https://localhost:7011',default:true}]})

    this.formGroup = this.fb.group({
      citysearch:['']
    });
    this.formdata= this.fb.group({
      citysearchdata:['']
    })
    

  }


  get cityvalue(){
    return this.formGroup.get('citysearch')?.value
  }

  get citysearchd(){
    return this.formdata.get('citysearchdata')?.value
  }
  // cararr: Array<any> = []
  searcharr: Array<string> = []
  filteredsearch: Array<string> = []
  // @Output() searchdataa: EventEmitter<string> = new EventEmitter<string>();
  ngOnInit(): void {


    this.loader.setFlag(true)
    this.demo.getcityonly().subscribe(data => {
      this.cityarr = data
      this.cityname=this.cityarr.map(x=>x.cityname)
      console.log(this.cityname);
      
      this.x = localStorage.getItem('username')
      // //console.log(this.x);
      this.loader.setFlag(false)
    })

    this.demo.getcarmodelsforfilter().subscribe(data => {
      // //console.log(data);
      this.searcharr = data;
      this.loader.setFlag(false)


    })


  }
  x: any;
  get status() {
    return this.demo.isloggedin();

  }
// citysearch!:string
citysearch:string="Ahmedabad"
  cityval(event:any){
    this.citysearch=this.cityvalue;


  }
  sessionexp(){
    alert("Please Login ");
  }

  sellcar(){
    this.loader.setFlag(true)
    this.x = localStorage.getItem('username')
    if(this.x==null){
      this.sessionexp()
      this.loader.setFlag(false)
      this.router.navigate(['login'])

    }
    else{
      this.loader.setFlag(false)

      this.router.navigate(['/sell'])
      // [routerLink]="['/sell']"
    }
  }
  
  citydropdown(city:any){
    this.x = localStorage.getItem('username')
    //console.log(city);
   

      this.router.navigate(['used',city]);
      this.citysearch=city;
      
    
    //console.log(this.citysearch);
  }

  wishlist(){
    this.x = localStorage.getItem('username')
    if(this.x==null){
      this.sessionexp()
      this.router.navigate(['login'])
    }
    else{

      this.router.navigate(['wishlist']);
      
    }
  }
  logout(){
    localStorage.clear()
    this.router.navigate(['login'])
  }

  search(keyword:string) {
    
    if (keyword.length != 0) {
      this.filteredsearch = this.searcharr.filter(x => x.toLowerCase().match(keyword.toLowerCase()))
  
    } else {
      this.filteredsearch = []
    }
    //console.log(this.filteredsearch);

  }

  onsearch(carb: string) {
    // this.route.params.subscribe(p => {
    //   // //console.log(p['cityname']);
    //   var city = p['cityname']

    //   // this.citysearch=city
    //   //console.log(this.citysearch);

    //   this.searchdataa.emit(carb)
    //   const url = (this.router.url === '/used/'+city )   ;
    //   const url2 = (this.router.url === '/used/'+city+'/'+carb )   ;


    // })
    this.router.navigate(['used', this.cityvalue,carb])
    this.filteredsearch = []
    carb=''
    
    
  }
  searchdata(){
    this.router.navigate(['used', this.cityvalue,this.citysearchd])
    
  }
 
}
