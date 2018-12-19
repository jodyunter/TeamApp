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

  saveTeams(): void {
    this.teamService.saveTeams(teams).subscribe();
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
