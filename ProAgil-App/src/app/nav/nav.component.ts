import { Component, OnInit, Input} from '@angular/core';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  constructor() { }

  searchtext : string = '';

  @Input() valueSearch : string;

  ngOnInit() {
  }

  search(value : string){
    console.log(this.searchtext);
  }

}
