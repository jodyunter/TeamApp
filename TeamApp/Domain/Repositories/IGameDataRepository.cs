using System;
using System.Collections.Generic;
using System.Text;

namespace TeamApp.Domain.Repositories
{
    public interface IGameDataRepository:IRepository<GameData>
    {
        GameData GetCurrentData();     
    }
}
