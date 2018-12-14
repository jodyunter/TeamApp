
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using System;
using static Xunit.Assert;
using TeamApp.Data.Repositories.NHibernate;
using TeamApp.Domain;
using TeamApp.Domain.Repositories;
using Xunit;
using System.Linq;

namespace TeamApp.Test.Data
{
    public abstract class CrudRepositoryTests<T>:RepositoryTests<T> where T : IDataObject
    {   

  
        public CrudRepositoryTests():base()
        {            
        }

        
 
        public abstract T GetAddItem();
        public abstract T UpdateItem(T item);



        [Fact]
        public void ShouldExportSchema()
        {
            //nothing really to do because it is done in constructor     
            //run this to regenerate the ddl
        }
        [Fact]
        public void ShouldAdd()
        {
            var getItem = GetAddItem();

            var id = repository.Add(GetAddItem());            
        }        
        [Fact]
        public void ShouldGetAll()
        {
            AddData();

            var dataList = repository.GetAll().ToList();

            StrictEqual(10, dataList.Count);            
        }

        [Fact]
        public void ShouldGetById()
        {
            AddData();

            var dataList = repository.GetAll().ToList();

            var itemToCheck = dataList[5];

            var searchItem = repository.Get(itemToCheck.Id);

            StrictEqual(searchItem.Id, itemToCheck.Id);
        }

        [Fact]
        public void ShouldUpdateItem()
        {
            var newItem = GetAddItem();
            newItem.Id = (long)repository.Add(newItem);

            newItem = UpdateItem(newItem);

            repository.Update(newItem);

            var updatedItem = repository.Get(newItem.Id);

            Equal(updatedItem, newItem);

        }
       
    }
}
