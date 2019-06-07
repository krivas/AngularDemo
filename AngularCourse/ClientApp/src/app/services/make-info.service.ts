import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable()
export class MakeInfoService {

   
   private url:string ="http://localhost:53413/api/Make";
  constructor(private _http:HttpClient) 
  {
    
   }

  getMake()
  {
    return this._http.get<Array<Make>>(this.url);
  }
  createMake(make:Make )
  {
        return this._http.post(this.url,make);
  }
  editMake(make:Make )
  {
        return this._http.put(this.url,make);
  }
  deleteMake(make:Make )
  {
    
    const options = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
      }),
      body:make,
    };
    return this._http.delete(this.url,options);
  }
}

export class Make {
  public name:string;
  public models:Model[];
}
export class Model {

  public name:string; 
  public make:Make; 
  public makeId:number;
}
