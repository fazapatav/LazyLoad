using LazyLoad.Data.Core;
using LazyLoad.Data.Core.Interfaces;
using LazyLoad.Domain.RepositoriesContracts;
using LazyLoad.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazyLoad.Data.Repositories
{
    public class CasoRepository: Repository<Caso>,ICasoRepository
    {
        private ILazyLoadUnitOfWork _unitOfWork;
        public CasoRepository(ILazyLoadUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
