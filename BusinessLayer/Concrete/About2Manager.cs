using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class About2Manager : IAbout2Service
    {
        IAbout2DaL _about2DaL;
        public About2Manager(IAbout2DaL about2DaL)
        {
            _about2DaL = about2DaL;
        }
        public void TAdd(About2 t)
        {
            _about2DaL.Insert(t);
        }

        public void TDelete(About2 t)
        {
            _about2DaL.Delete(t);
        }

        public About2 TGetById(int id)
        {
            return _about2DaL.GetById(id);
        }

        public List<About2> TGetList()
        {
            return _about2DaL.GetListAll();
        }
        public List<About2> TGetListFilter(Expression<Func<About2, bool>> filter)
        {
            return _about2DaL.ListCondition(filter);
        }

        public void TUpdate(About2 t)
        {
            _about2DaL.Update(t);
        }
    }
}
