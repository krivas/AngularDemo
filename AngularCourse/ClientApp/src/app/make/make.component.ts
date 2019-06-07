import { MakeInfoService, Make, Model } from './../services/make-info.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-make',
  templateUrl: './make.component.html',
  styleUrls: ['./make.component.css']
})
export class MakeComponent implements OnInit {

 
  makes:Array<Make>;
  models:Array<Model>;
  make:Make=new Make();
  constructor(private _makeService:MakeInfoService) {

   }

  ngOnInit() {
    this.getMakes();
  }
 getMakes()
 {
  this._makeService.getMake().subscribe(makes=>{this.makes=makes; console.log(this.makes)});
 }
  createMake(make:Make)
  {
      this._makeService.createMake(make).subscribe(x=>{
        this.getMakes();
    });
  }  
 
  editMake(make:Make)
  {
    this._makeService.editMake(make).subscribe(x=>{
      this.getMakes();
    });
    
  }

}
