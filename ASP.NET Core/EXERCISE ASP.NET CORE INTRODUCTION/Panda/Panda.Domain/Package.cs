using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Panda.Domain.Enums;

namespace Panda.Domain
{
    public class Package
    {
        public string Id { get; set; }

        public string Description { get; set; }

        public double Weight { get; set; }

        public string ShippingAddress { get; set; }

        public Status Status { get; set; }

        public DateTime EstimatedDeliveryDate { get; set; }

        
        public string RecipientId { get; set; }
        public PandaUser Recipient { get; set; }

    }
}
