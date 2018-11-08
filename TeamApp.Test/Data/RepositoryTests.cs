
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
    public abstract class RepositoryTests<T>:IDisposable where T :IDataObject
    {   

        private ISession session;
        private Configuration configuration;

        private bool doNotDrop = false;

        protected IRepository<T> repository;
        public RepositoryTests()
        {
            session = NHibernateHelper.OpenSession();
            configuration = NHibernateHelper.GetConfiguration().BuildConfiguration();
            SetupDatabase();
            SetupRepository();
        }

        
        public abstract void SetupRepository();
        public abstract void AddData();
        public abstract T GetAddItem();
        public abstract T UpdateItem(T item);

        public void Dispose()
        {
            if (!doNotDrop)
            {
                DropDatabase();
            }            
            session.Close();
        }

        private void SetupDatabase()
        {
            var schemaExport = new SchemaExport(configuration);
            schemaExport.SetOutputFile("../../../sqloutput/ddl.sql");
            schemaExport.Execute(false, true, false);
        }

        private void DropDatabase()
        {
            var schemaExport = new SchemaExport(configuration);
            schemaExport.Drop(false, true);
        }

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
