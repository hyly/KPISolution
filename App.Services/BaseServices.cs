using System;
using System.Collections.Generic;
using System.Linq;
using App.Data.DomainModel;

namespace App.Services.Implementation
{
    public abstract class BaseServices
    {
        protected IUnitOfWork unitOfWork = null;
        public BaseServices(IUnitOfWork _unitOfWork)
        {
            this.unitOfWork = _unitOfWork;
        }
    }
}
