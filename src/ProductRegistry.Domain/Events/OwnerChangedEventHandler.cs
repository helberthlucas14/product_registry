using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductRegistry.Domain.Events
{
    public class OwnerChangedEventArgs : EventArgs
    {
        public OwnerChangedEventArgs(Guid? oldOwnerId, Guid newOwnerId)
        {
            OldOwnerId = oldOwnerId;
            NewOwnerId = newOwnerId;
        }

        public Guid? OldOwnerId { get; private set; }

        public Guid NewOwnerId { get; private set; }
    }
}
