import { Component, ElementRef, OnInit, ViewChild,Renderer2  } from '@angular/core';
import { Store } from '@ngrx/store';
import { sellcar } from '../../stores/models/sellcarmodel';
import { carapproval, carreqlength, filterdatabyapproved, sortcarbypricehigh, sortcarbypricelow, sortcarbystatus } from '../../stores/sellrequeststore/store.selector';
import { Observable, filter, map } from 'rxjs';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { delcarreq, denyreq, updatedata } from '../../stores/sellrequeststore/store.action';
import { HttpClient } from '@angular/common/http';
import { StoreServiceService } from '../../stores/services/store-service.service';
import { AppGrid } from '../app-grid';
import { vDegreeLookupBase } from './v-sellapproval-list';
import { pagination } from '../../stores/models/paginationmodel';
import { GridCustomTemplate } from '@rxweb/grid';
import { GRID_CUSTOM_TEMPLATES } from './GridCustomTemplate';
import { log } from 'console';

@Component({
  selector: 'app-sellapproval',
  templateUrl: './sellapproval.component.html',
  styleUrls: ['./sellapproval.component.css']
})
export class SellapprovalComponent implements OnInit {

  // cardata!: Observable<Array<sellcar>>;
  // cardata2!: Observable<Array<sellcar>>;
  outlets: any
  editform!: FormGroup;
  // id!: number;
  // p: any
  // constructor(private store: Store<Array<sellcar>>, private serv: StoreServiceService, private fb: FormBuilder, private http: HttpClient) {
    // this.editform = this.fb.group({
    //   sellerprice: ['', Validators.required],
    //   outlet: ['', Validators.required]
    // })
  // }
  // ngOnInit(): void {
  //   this.cardata = this.store.select(carapproval)
    // this.http.get(this.serv.baseurl + '/Admin/outlets').subscribe({
    //   next: (resp: any) => {
    //     this.outlets = resp
    //   },
    //   error: (err: any) => {
    //     console.log(err);

    //   }
    // })
  // }

  // get sellerP(){
  //   return this.editform.get("sellerprice")
  // }
  // get outl(){
  //   return this.editform.get("outlet")
  // }



  // approvalid(id: number) {
  //   this.id = id
  // }

  // approval() {
  //   this.store.dispatch(updatedata({ carid: this.id, sellcars: this.editform.value }))


  // }
  // delcarreq(carid: number) {
  //   this.store.dispatch(delcarreq({ carid: carid }))
  // }
  // cancid!: number;
  // cancelid(i: number) {
  //   this.cancid = i
  // }
  // cancelrequest() {
  //   this.store.dispatch(denyreq({ carid: this.cancid }))
  // }

  // sort(event: any) {
  //   if (event.target.value == '1') {

  //     this.cardata = this.store.select(sortcarbystatus)
  //   }
  //   if (event.target.value == '2') {

  //     this.cardata = this.store.select(sortcarbypricelow)
  //   }
  //   if (event.target.value == '3') {

  //     this.cardata = this.store.select(sortcarbypricehigh)
  //   }
  // }

  // filter(event: any) {
  //   console.log(event.target.value);
  //   if (event.target.value == '0') {
  //     this.cardata = this.store.select(carapproval)
  //   }
  //   else {

  //     this.cardata = this.store.select(filterdatabyapproved(event.target?.value))
  //   }
  // }


  @ViewChild('myModal') modal!: ElementRef;
  title = 'RxGridStatic';
  gridConfig!: AppGrid;
  d: pagination = {} as pagination;
  flag:boolean=false
  degreeTypeList: any=[];
  dropTypeList: any=[];
   data = {
    "pagenum": this.d.pageindexnum,
    "pagesize": this.d.pagesize,
    "val": "",
    "sortby": "carbrand",
    "orderby": false
  }

  constructor(private store: Store<Array<sellcar>>, private serv: StoreServiceService, private fb: FormBuilder, private http: HttpClient) {
    // localStorage.clear();
    this.editform = this.fb.group({
      sellerprice: ['', Validators.required],
      outlet: ['', Validators.required]
    })
    this.d.pagesize = 10
    this.d.pageindexnum = 1
    
    this.staticData();
  }
  ngOnInit() {
    // this.bindGrid()
    // this.binddropgrid()

    GridCustomTemplate.register(GRID_CUSTOM_TEMPLATES);

    this.http.get(this.serv.baseurl + '/Admin/outlets').subscribe({
      next: (resp: any) => {
        this.outlets = resp
      },
      error: (err: any) => {
        console.log(err);

      }
    })
   }
   binddropgrid(){
   
   }

   approval(){
    let data = this.editform.value
      this.http.put<any>("https://localhost:7011/api/Admin/"+this.approvalid,data).subscribe(data=>{
        console.log(data);
        alert("Car accepted")
        this.close()
        
      })
   }

   close(){
    const modalElement = this.modal.nativeElement;
    if (modalElement) {
      modalElement.classList.remove('show');
      modalElement.style.display = 'none';
    }
   }

  onClick() {
    this.d.pagesize = this.gridConfig.maxPerPage
    console.log(this.gridConfig.maxPerPage);
    this.staticData()

  }


  approvalid!:number;
  handleRowClick(rowDat: any) {
    // alert(`Row clicked! Data: ${JSON.stringify(rowDat)}`);

    console.log(rowDat.carid);
    this.approvalid=rowDat.carid
    const modalElement = this.modal.nativeElement;
  if (modalElement) {
    modalElement.classList.add('show');
    modalElement.style.display = 'block';
  }   
      
    
  }
  // bindGrid() {
  //   this.gridConfig = new AppGrid(this.degreeTypeList, vDegreeLookupBase, {
    
  //   });

  // }
  handlePageChanging = (nextPage: number) => {
    console.log('Page ', nextPage);
    this.d.pageindexnum = nextPage

    // console.log(this.degreeTypeList);
    
    this.staticData()
    this.initializeGrid()

  };

  deny(data:any){
    // alert(data.carid)
    this.http.put<any>("https://localhost:7011/api/Admin/Denyreq/"+data.carid,data).subscribe(d=>{
      console.log(d);
      alert("Car has been denied")
      
    })
  }

  arr:any=[]
  onc(event:any){
    console.log(event.target.value);
    
    var x = this.gridConfig.gridColumns.find((x:any)=>x.headerKey==event.target.value)
    console.log(this.gridConfig.gridColumns);
    if(x){
      x.visible=event.target.checked;
      console.log(x);
      if(event.target.checked){
        // this.arr.push(x?.name);
        this.arr=(this.gridConfig.gridColumns.map(x=>x.name))

      }
      else{
        let i = this.arr.findIndex((x:any)=>x===event.target.value)
        if(i!==-1){
          this.arr.splice(i,1)
        }
      }

    }
   
     this.staticData()
  }


  initializeGrid() {
    if (this.flag) {


      // this.gridConfig.storeProcedure.nextPage=1
      // this.gridConfig.storeProcedure.length=this.degreeTypeList.length
      this.gridConfig.reDesign()
      this.gridConfig.updateSource([]);
      this.gridConfig.updateSource(this.degreeTypeList);
      // this.gridConfig.destroy()
      
      

    }
    else if(!this.flag){

    this.gridConfig = new AppGrid(this.degreeTypeList, vDegreeLookupBase, {
      actions:{

        onClick: this.handleRowClick.bind(this),
        onDeny:this.deny.bind(this)
      }
    });
    
    this.gridConfig.maxPerPage = (this.d.pagesize ?? 0 > this.d.total!! ? this.d.pagesize : this.d.total) ?? 0
    
    this.gridConfig.storeProcedure = { nextPage: 1, length: this.d.total ?? 10, onPageChanging: this.handlePageChanging, onPageSorting: this.sortpage }
    this.flag=true
    
    console.log(this.gridConfig.gridColumns.map(x=>x.name));
    this.arr=(this.gridConfig.gridColumns.map(x=>x.name))

    }
    
  }




  sortpage=(columnName: string, order: boolean, currentPage: number) =>{
    
    
    
    // if (columnName === "carbrand") {
    //   console.log("car");

    //   this.degreeTypeList.sort((a: any, b: any) => a.carbrand.localeCompare(b.carbrand));      
      
    // }
    // if(columnName==="carmodel"){
    //   this.degreeTypeList.sort((a: any, b: any) => a.carmodel.localeCompare(b.carmodel));
      
    // }
    console.log(columnName);
    console.log(order);

    
    this.data.sortby=columnName;
    this.data.orderby=order;
    console.log(this.data);
    
    this.staticData()
    
  }
  
  
  search(data:any){
    console.log(data);
    this.data.val=data;
    this.staticData()
    
    
  }
  staticData() {
   
 
      this.data.pagenum=this.d.pageindexnum,
      this.data.pagesize= this.d.pagesize,
    console.log(this.data.pagesize);
    
    

    this.http.post(`https://localhost:7011/api/Admin`,this.data).subscribe((data: any) => {
      // console.log(data);

      this.degreeTypeList = data.result
      // this.dropTypeList=data.result.carid
      console.log(this.degreeTypeList);
    console.log(Object.keys(this.degreeTypeList[0]));
    this.dropTypeList=Object.keys(this.degreeTypeList[0])

      this.d.total = data.len
      
      this.initializeGrid()
      this.binddropgrid()
    })
  }
}
