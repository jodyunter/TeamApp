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
            UpdateAuditTrail(e.State, e.Persister.PropertyNames, (IDataObject)e.Entity);
            return false;
        }
        public bool OnPreInsert(PreInsertEvent e)
        {            
            UpdateAuditTrail(e.State, e.Persister.PropertyNames, (IDataObject)e.Entity);
            return false;
        }
        private void UpdateAuditTrail(object[] state, string[] names, IDataObject entity)
        {
            var idx = Array.FindIndex(names, n => n == "UpdatedBy");
            state[idx] = "Uknown";
            entity.LastModifiedBy = state[idx].ToString();
            idx = Array.FindIndex(names, n => n == "UpdatedTimestamp");
            DateTime now = DateTime.Now;
            state[idx] = now;
            entity.LastModifiedOn = now;
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
