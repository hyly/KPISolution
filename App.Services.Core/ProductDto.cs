using System;
using System.Collections.Generic;
using App.Data.DomainModel.Entities;
using System.Runtime.Serialization;

namespace App.Services.Core
{
    [DataContract]
    public class ProductDto : Product
    {
        public ProductDto()
            : base()
        {

        }
    }
}
