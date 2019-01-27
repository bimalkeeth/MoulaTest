import {Inject, Injectable} from '@angular/core';
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {IRequestContract} from "../contract/requestcontract";
import {ITriangularContract} from "../contract/triangularcontract";
import {Observable,of} from "rxjs";
import {catchError} from "rxjs/operators";

@Injectable()
export class DrawingService {
  data:ITriangularContract;
  constructor( @Inject(HttpClient) public http: HttpClient,@Inject('BASE_URL') public baseUrl: string) {

  }

  processTriangularRequest(request:IRequestContract):ITriangularContract{

     this.http.put<ITriangularContract>(this.baseUrl+"api/TriangularApi/ProcessData", request)
      .subscribe(result=>{
        this.data=result;
      });
      return this.data;
  }


}
