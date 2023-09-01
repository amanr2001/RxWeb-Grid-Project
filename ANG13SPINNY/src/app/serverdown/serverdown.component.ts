import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { LoaderService } from '../../services/loader.service';
import { MainservService } from '../../services/mainserv.service';

@Component({
  selector: 'app-serverdown',
  templateUrl: './serverdown.component.html',
  styleUrls: ['./serverdown.component.css']
})
export class ServerdownComponent {
  constructor(private demo:MainservService,private router :Router, private loader:LoaderService) {}

  retry() {

    //this.loader.setFlag(true)
    console.log(this.loader.flag);

    this.demo.testingapi().subscribe(
      {
        next:(response:any)=>{
          // this.loader.setFlag(false)
          this.router.navigate([''])
        },
        error:(err:any)=>{
          // this.loader.setFlag(false)

        }

      }
    )
  }
}
