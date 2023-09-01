import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { MainservService } from 'src/services/mainserv.service';

@Component({
  selector: 'app-wishlist',
  templateUrl: './wishlist.component.html',
  styleUrls: ['./wishlist.component.css']
})
export class WishlistComponent {

  filteredarr: any;
  constructor(private demo: MainservService, private route: ActivatedRoute, private router: Router) {
    let i = localStorage.getItem('id')
    this.demo.getwishL(i).subscribe({
      next: (res: any) => {
        this.filteredarr = res
        console.log(res);


      }
    })

  }

}
