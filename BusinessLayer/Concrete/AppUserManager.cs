using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AppUserManager : IAppUserService
    {
        IAppUserDal _appUserDal;

        public AppUserManager(IAppUserDal appUserDal)
        {
            _appUserDal = appUserDal;
        }

        public void TAdd(AppUser t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(AppUser t)
        {
            _appUserDal.Delete(t);
        }

        public AppUser TGetById(int id)
        {
            return _appUserDal.GetById(id);
        }

        public AppUser TGetByName(string name)
        {
            return _appUserDal.ListCondition(x => x.UserName == name).FirstOrDefault();
        }

        public List<AppUser> TGetList()
        {
            return _appUserDal.GetListAll();
        }

        public List<AppUser> TGetListFilter(Expression<Func<AppUser, bool>> filter)
        {
            return _appUserDal.ListCondition(filter);
        }

        public void TUpdate(AppUser t)
        {
            throw new NotImplementedException();
        }
    }
}
