
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

        protected ISession session;
        private Configuration configuration;

        protected bool dropDatabase = true;
        
        protected IRepository<T> repository;
        public RepositoryTests()
        {
            session = NHibernateHelper.OpenSession();
            configuration = NHibernateHelper.GetConfiguration().BuildConfiguration();
            SetupDatabase();            
            SetupRepository();            
        }

        public RepositoryTests(bool Drop, bool Setup, bool Data)
        {
            session = NHibernateHelper.OpenSession();
            configuration = NHibernateHelper.GetConfiguration().BuildConfiguration();
            if (Setup) SetupDatabase();
            if (Data) AddData();
            SetupRepository();
            dropDatabase = Drop;
        }

        public abstract void AddData();
        public abstract void SetupRepository();

        public void Dispose()
        {
            if (dropDatabase)
            {
                DropDatabase();
            }

            NHibernateHelper.CloseSession();
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

   
       
    }
}
