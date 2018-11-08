using System;
using System.Collections.Generic;
using System.Text;

namespace TeamApp.Services.ViewModels.Views
{
    public class TeamViewModel
    {
        public string Name { get; set; }
        public string NickName { get; set; }
        public string ShortName { get; set; }
        public int Skill { get; set; }
        public string Owner { get; set; }
        public int? FirstYear { get; set; }
        public int? LastYear { get; set; }
        public bool Active { get; set; }
    }
}
