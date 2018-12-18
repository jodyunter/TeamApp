import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-team',
  templateUrl: '../pages/team.component.html',
  //styleUrls: ['../css/team.component.css']
})
export class TeamComponent implements OnInit {
  teams: Team[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Team[]>(baseUrl + 'api/Team/GetTeams').subscribe(result => {
      this.teams = result;
    }, error => console.error(error));
  }

  ngOnInit() {
  }

}
