import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { StoreServiceService } from '../../stores/services/store-service.service';
import { MainservService } from 'src/services/mainserv.service';
import { homedata } from '../../stores/models/homemodel';
import { AppGrid } from '../app-grid';
import { vDegreeLookupBase } from '../v-degree-list';
import { log } from 'console';

@Component({
  selector: 'app-user-home-page',
  templateUrl: './user-home-page.component.html',
  styleUrls: ['./user-home-page.component.css']
})
export class UserHomePageComponent implements OnInit{

  ManageHomeForm !:FormGroup;
  tabData:any;
  tData:any
  gridConfig!: AppGrid;
  flag:boolean=false;

  constructor(private demo: MainservService,private serv: StoreServiceService, private fb: FormBuilder, private http: HttpClient){
    this.ManageHomeForm=this.fb.group({
      imageUrl:[''],
      imageTitle:[''],
      imageText:[''],
      mainPageType:[''],
      pageStatus:['']
    })
    this.gettabdata = this.gettabdata.bind(this);
    this.search = this.search.bind(this);
  }

  ngOnInit(): void {
   this.gettabdata()
  }
  bindGrid(){
    this.gridConfig = new AppGrid(this.tabData, vDegreeLookupBase, {
      // actions: {}
    });
    this.gridConfig.storeProcedure={nextPage:1,length:this.tabData.length,onPageChanging:this.tdata}
  }

  tdata= (nextPage: number) =>{
    console.log(nextPage);
    this.gridConfig.storeProcedure.nextPage=nextPage
    this.initializeGrid()
  }
  initializeGrid() {
    if (this.flag) {
        // Destroy or clean up existing instance if needed
        // this.gridConfig.storeProcedure.length=this.tabData.length
        this.gridConfig.updateSource([]);
        this.gridConfig.updateSource(this.tabData);
        
      }
      else if(!this.flag){
        this.bindGrid()
        this.flag=true
      }
    // this.gridConfig = new AppGrid(this.tabData, vDegreeLookupBase);
}

  gettabdata(){
    this.serv.getmainpageTabData().subscribe({
      next:(res:any)=>{
        this.tData=res
        this.tabData=this.tData.map((d:any)=>d.data)
        console.log(this.tData.map((d:any)=>d.data));
        this.initializeGrid();
        
      }
    })
  }
  
  search(data:any){
    console.log(data);
    console.log(this.tData);
    
    console.log(this.tabData);
    this.tabData=this.tData.map((d:any)=>d.data).filter((x:any)=>x.name.includes(data))
    console.log(this.tabData);
    
   this.initializeGrid();
  }


  img!:File;
  selectimg(event:any){
    this.img = event.target.files[0];
  }
  addData(){
    let data:homedata = this.ManageHomeForm.value;
    console.log(data);
    
    const imgdata = new FormData();
    imgdata.append('file',this.img);
    this.http.post(this.demo.baseurl+'/upload/upload',imgdata).subscribe({
      next:(resp:any)=>{
        data.imageUrl=resp.url;
        this.http.post(this.demo.baseurl+'/MainPages',data).subscribe({
          next:(response:any)=>{
            alert("image added successfully");
            this.gettabdata();
          },
          error:(err:any)=>{
            console.log(err);
            
          }
        })
      }
    })
  }
updateid!:number;
  pat(data:any){
    console.log(data);
    console.log(this.ManageHomeForm.value);
    this.updateid=data.mainId
    const newValues = {
      imageTitle: data.imageTitle,
      imageText: data.imageText,
      //email: 'johndoe@example.com',
      imageUrl:'',mainPageType:data.mainPageType,pageStatus:data.pageStatus
    };
    console.log(newValues);
    
    this.ManageHomeForm.patchValue(newValues)
    
  }

  upd(){
    let data:homedata = this.ManageHomeForm.value
    const imgdata = new FormData();
    imgdata.append('file',this.img);
    this.http.post(this.demo.baseurl+'/upload/upload',imgdata).subscribe({
      next:(resp:any)=>{
        data.imageUrl=resp.url;
        this.serv.updatemainpage(this.updateid,data).subscribe({
          next:(res:any)=>{
            alert("successfully update the data");
            this.gettabdata();
          }
        });
      }
    })
      
  }

  delid!:number;
  del(id:number){
    this.delid=id
  }
  deletedata(){
    this.serv.deletemainpagedata(this.delid).subscribe({
      next:(res:any)=>{
        console.log(res);
        this.gettabdata();
      }
    })
  }

}
