using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace TeamApp.Services.Implementation
{
    public class BaseService<Domain, Model> 
    {
        virtual public List<Model> MapDomainToModel(List<Domain> objs)
        {
            var result = new List<Model>();

            objs.ForEach(obj =>
            {
                result.Add(MapDomainToModel(obj));
            });

            return result;
        }
        virtual public Model MapDomainToModel(Domain obj)
        {

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Domain, Model>();
            });

            return config.CreateMapper().Map<Domain, Model>(obj);
        }
    }
}
