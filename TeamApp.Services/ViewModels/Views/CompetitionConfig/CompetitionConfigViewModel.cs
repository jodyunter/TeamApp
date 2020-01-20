using System;
using System.Collections.Generic;
using System.Text;

namespace TeamApp.ViewModels.Views.CompetitionConfig
{
    public class CompetitionConfigViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<int> Years { get; set; }
    }
}
