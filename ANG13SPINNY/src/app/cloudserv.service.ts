import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class CloudservService {
  CLOUD_NAME:string='spinnydata'
  constructor(private http:HttpClient) {

  }
      imageUrl:string='https://api.cloudinary.com/v1_1/spinnydata/image/upload'
  uploadimage(file:File,preset:string){
    const data = new FormData();
    data.append('file',file);
    data.append('upload_preset',preset);
    data.append('cloud_name','spinnydata');
    data.append('public_id',file.name + new Date().getTime());
    return this.http.post(this.imageUrl,data)
  }


}
