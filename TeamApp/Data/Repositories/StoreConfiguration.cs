﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TeamApp.Domain;
using FluentNHibernate.Automapping;
using TeamApp.Domain.Competition;
using TeamApp.Domain.Competition.Seasons.Config;

namespace TeamApp.Data.Repositories
{
    public class StoreConfiguration : DefaultAutomappingConfiguration
    {
        public override bool ShouldMap(Type type)
        {
            return type.GetInterfaces().ToList().Contains(typeof(IDataObject));
        }

    }
}