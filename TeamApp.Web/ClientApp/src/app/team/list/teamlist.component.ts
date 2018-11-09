import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-teamlist',
  templateUrl: './teamlist.component.html'
})
export class TeamListComponent {
  public teamListData: TeamListItem[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<TeamListItem[]>(baseUrl + 'api/Team/GetTeams').subscribe(result => {
      this.teamListData = result;
    }, error => console.error(error));
  }
  

}

interface TeamListItem {
  id: number,
  name: string,
  nickName: string,
  shortName: string,
  skill: number,
  owner: string,
  firstYear: number,
  lastYear: number,
  active: boolean
}


