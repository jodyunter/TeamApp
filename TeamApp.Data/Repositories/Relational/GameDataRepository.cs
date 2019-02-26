using System;
using System.Collections.Generic;
using System.Linq;
using TeamApp.Data.Relational.Repositories;
using TeamApp.Domain;
using TeamApp.Domain.Repositories;

namespace TeamApp.Data.Repositories.Relational
{
    public class GameDataRepository : DataRepository<GameData>, IGameDataRepository
    {
        public GameDataRepository(IRelationalRepository<GameData> repo) : base(repo) { }

        public GameData GetCurrentData()
        {
            return baseRepo.First();
        }
    }
}
