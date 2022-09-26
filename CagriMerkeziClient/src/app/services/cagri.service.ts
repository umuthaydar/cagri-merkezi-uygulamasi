import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { Cagri } from "../models/Cagri";

@Injectable({
    providedIn: 'root'
  })

  export class CagriService {

    constructor(private http:HttpClient) {}


    private url='http://localhost:18202/api/cagridetay'

    getCagriDetay(){
        return this.http.get<Cagri[]>(this.url)
    }
   
    postCagriDetay(cagri: Cagri){
      return this.http.post(this.url, cagri);
    }

    deleteCagriDetay(id:any){
      return this.http.delete(this.url+'/'+id);
    }
   
    updateCagriDetay(id:any,value:Cagri){
      return this.http.put(this.url+'/'+id,value);
    }
}