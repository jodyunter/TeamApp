import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-team-detail',  
  templateUrl: '../pages/team-detail.component.html',
  styleUrls: ['../css/team-detail.component.css']
})
export class TeamDetailComponent implements OnInit {
  @Input() team: Team;

  constructor() { }

  ngOnInit() {
  }

}
