using System.Collections.Generic;

namespace TeamApp.Domain.Competitions.Config.Playoffs
{
    public class PlayoffCompetitionConfigValidator
    {
        public List<string> Messages { get; set; }

        private string messageFormat = "{0}\t{1}\t{2}";

        public PlayoffCompetitionConfigValidator()
        {
            Messages = new List<string>();
        }

        public bool Validate(PlayoffCompetitionConfig config, int year)
        {
            bool valid = true;

            return valid;
        }

        public bool ConfigIsActive(PlayoffCompetitionConfig config, int year)
        {
            bool valid = true;

            if (!config.IsActive(year))
            {
                var type = "PlayoffCompetitionConfig";
                var message = "Competition Configuration is not active for year.";
                var data = string.Format("Id:{0} Name:{1} Year:{2}", config.Id, config.Name, year);
                var result = string.Format(messageFormat, type, message, data);
                Messages.Add(result);
            }

            return valid;
        }

        public bool ValidateTeamsAreInGroupLevelOnlyOnce(PlayoffCompetitionConfig config, int year)
        {
            return false;
        }

    }
}
