import {Inject, Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {ToastrService} from "ngx-toastr";
import {ICustomerRequest} from "../contract/ICustomerRequest";
import {ICustomerDetail} from "../contract/ICustomerDetail";
import {catchError} from "rxjs/operators";
import {Observable, of} from "rxjs";


@Injectable({
  providedIn: 'root'
})
export class CustomerServiceService {
  data:boolean;
  constructor(@Inject(HttpClient) public http: HttpClient,@Inject('BASE_URL') public baseUrl: string,@Inject(ToastrService) public toastr: ToastrService){

  }
  //----------------------------------------------
  // Create Customer
  //----------------------------------------------
  CreateCustomer(request:ICustomerRequest):boolean{
    this.http.put<boolean>(this.baseUrl+"api/CustomerApi/CreateCustomer", request)
      .subscribe(result=>{
        this.data=result;
      });
      return this.data;
  }
  //----------------------------------------------
  // Get Top Customer
  //----------------------------------------------
  GetTopCustomers(topCustomer:number):Observable<ICustomerDetail[]>{
    return this.http.get<ICustomerDetail[]>(this.baseUrl+"api/CustomerApi/GetTopCustomer/"+topCustomer)
      .pipe(
      catchError((error: any) => {
        return of(error);
      }));
  }
}
