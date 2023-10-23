import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-value', //لما اعزذ انفذ الكومبوننت لازم انادي عليه بالسليكتور بتاعه
  templateUrl: './value.component.html',
  styleUrls: ['./value.component.css']
})
export class ValueComponent implements OnInit {

  values : any ; //من نوع اني علشان معرفش الداتا اللي جايالي هتتخزن فيها من اني نوع
  constructor(private http : HttpClient) //هيعمل بروربرتي من نوع httpclient
   { }

  ngOnInit()
  {
    this.getValue();
  }

  getValue() //function
  {
    this.http.get('http://localhost:5077/api/values').subscribe (
      response => {this.values = response ;},
      error => {console.log(error);}
    )


  }

}
