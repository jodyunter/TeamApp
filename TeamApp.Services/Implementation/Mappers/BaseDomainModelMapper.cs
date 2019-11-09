using AutoMapper;
using System.Collections.Generic;
using System.Linq;

namespace TeamApp.Services.Implementation.Mappers
{    
    public class BaseDomainModelMapper<Domain, Model> 
    {
        virtual public IEnumerable<Model> MapDomainToModel(IList<Domain> objs)
        {
            var result = new List<Model>();

            objs.ToList().ForEach(obj =>
            {
                result.Add(MapDomainToModel(obj));
            });

            return result;
        }
        virtual public IEnumerable<Model> MapDomainToModel(IEnumerable<Domain> objs)
        {
            var result = new List<Model>();

            objs.ToList().ForEach(obj =>
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

        virtual public Domain MapModelToDomain(Model mod)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Model, Domain>();
            });

            return config.CreateMapper().Map<Model, Domain>(mod);
        }

        virtual public IEnumerable<Domain> MapModelToDomain(IEnumerable<Model> models)
        {
            var result = new List<Domain>();

            models.ToList().ForEach(obj =>
            {
                result.Add(MapModelToDomain(obj));
            });

            return result;
        }

    }
}
