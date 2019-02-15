using NHibernate.Event;
using System;
using System.Collections.Generic;
using System.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TeamApp.Domain;

namespace TeamApp.Data.Repositories.Relational.NHibernate
{
    internal class AuditEventListener : IPreUpdateEventListener, IPreInsertEventListener
    {    
        public bool OnPreUpdate(PreUpdateEvent e)
        {
            UpdateAuditTrail(e.State, e.Persister.PropertyNames, (IDataObject)e.Entity, false);
            return false;
        }
        public bool OnPreInsert(PreInsertEvent e)
        {
            UpdateAuditTrail(e.State, e.Persister.PropertyNames, (IDataObject)e.Entity, true);
            return false;
        }
        private void UpdateAuditTrail(object[] state, string[] names, IDataObject entity, bool isCreate)
        {
            DateTime now = DateTime.Now;

            var idx = Array.FindIndex(names, n => n == "LastModifiedBy");
            state[idx] = Thread.CurrentPrincipal.Identity.Name;
            entity.LastModifiedBy = state[idx].ToString();
            idx = Array.FindIndex(names, n => n == "LastModifiedOn");            
            state[idx] = now;
            entity.LastModifiedOn = now;

            if (isCreate)
            {
                idx = Array.FindIndex(names, n => n == "CreatedBy");
                state[idx] = Thread.CurrentPrincipal.Identity.Name;
                entity.CreatedBy = state[idx].ToString();
                idx = Array.FindIndex(names, n => n == "CreatedOn");
                state[idx] = now;
                entity.CreatedOn = now;

            }

        }

        public Task<bool> OnPreUpdateAsync(PreUpdateEvent @event, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> OnPreInsertAsync(PreInsertEvent @event, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
