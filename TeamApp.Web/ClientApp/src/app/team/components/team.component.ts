import { Component, OnInit, Inject } from '@angular/core';
import { TeamService } from '../../services/team.service';

@Component({
  selector: 'app-team',
  templateUrl: '../pages/team.component.html',
  styleUrls: ['../css/team.component.css']
})

export class TeamComponent implements OnInit {
  teams: Team[];
  selectedTeam: Team;

  constructor(private teamService: TeamService) {
      
  }
  createNewTeam(): void {
    this.selectedTeam = {
      id: 0,
      name: "",
      nickName: "",
      shortName: "",
      owner:"",
      skill: 5,
      firstYear: 1,
      lastYear: null,
      active: true
    } as Team;
  }
  saveTeam(): void {
    this.teamService.saveTeam(this.selectedTeam).subscribe(team => this.selectedTeam = team);
    this.getTeams();
  }

  getTeams(): void {
    this.teamService.getTeams().subscribe(teams => this.teams = teams);
  }
  onSelect(team: Team): void {
    this.selectedTeam = team;    
  }

  ngOnInit() {
    this.getTeams();
  }

}
