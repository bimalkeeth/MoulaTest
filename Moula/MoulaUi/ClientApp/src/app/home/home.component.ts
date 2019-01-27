import {Component, Inject, OnInit, OnDestroy} from '@angular/core';
import {DrawingService } from "../services/drawingservice.service";
import {FormBuilder, FormControl, FormGroup, Validators} from "@angular/forms";
import {ToastrService} from "ngx-toastr";
import "rxjs-compat/add/operator/map";
import {ITriangularContract} from "../contract/triangularcontract";
import * as JXG from "../../../js/jsxgraphcore.min.js"


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls:['./home.component.css']
})
export class HomeComponent implements OnInit, OnDestroy{

  frmDrawingFormGroup: FormGroup;
  inputControl: FormControl;
  inputDataRequest:string;
  triAngularContract:ITriangularContract;
  constructor( @Inject(DrawingService) public drawService: DrawingService,
               @Inject(FormBuilder) public formBuilder: FormBuilder,
               @Inject(ToastrService) public toastr: ToastrService
               ){

  }

  ngOnDestroy(): void {

  }

  ngOnInit(): void {

    this.inputControl = new FormControl(this.inputDataRequest,{ validators: Validators.required,updateOn: 'blur'});
    this.frmDrawingFormGroup = new FormGroup({
      triangularRequestCtrl: this.inputControl,
    });

      }
  ProcessData():void{


    if(!this.inputDataRequest){
      this.toastr.error('Triangular request is empty', 'Major Error', {
        timeOut: 3000
      });
    }
    else {


      let result=  this.drawService.processTriangularRequest({RequestData:this.inputDataRequest});
      if(result){

        const board = JXG.JSXGraph.initBoard('jxgbox', {boundingbox: [-500, 500, 500, -500],axis: true});
        let A = board.create('point',[result.pointA.x,result.pointA.y],{size:3,name:'A'});
        let B= board.create('point',[result.pointB.x,result.pointB.y],{size:3,name:'B'});
        let C= board.create('point',[result.pointC.x,result.pointC.y],{size:3,name:'C'});

        let l1 = board.create('line',[A,B],{straightFirst:false, straightLast:false, lastArrow:true,strokeWidth:4,strokeColor:'#0000ff'});
        let l2 = board.create('line',[B,C],{straightFirst:false, straightLast:false, lastArrow:true,strokeWidth:4,strokeColor:'#0000ff'});
        let l3 = board.create('line',[C,A],{straightFirst:false, straightLast:false, lastArrow:true,strokeWidth:4,strokeColor:'#0000ff'});

      }
      else {
        this.toastr.error('Triangular data operation failed', 'Major Error', {
          timeOut: 3000
        });
      }

    }
  }

}
