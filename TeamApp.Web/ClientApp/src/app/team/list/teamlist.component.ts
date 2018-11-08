import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-teamlist',
  templateUrl: './teamlist.component.html'
})
export class TeamListComponent {
  public standingsData: Standings;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Standings>(baseUrl + 'api/SampleData/Standings').subscribe(result => {
      this.standingsData = result;
    }, error => console.error(error));
  }
  

}

interface TeamListItem {
  teamName: string   
}


