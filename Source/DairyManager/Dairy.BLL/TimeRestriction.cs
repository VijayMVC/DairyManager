using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Diary.DAL;
using Diary.Entity;

namespace Dairy.BLL
{
    public class TimeRestriction
    {

        TimeRestrictionDao timeRestrictionDao = new TimeRestrictionDao();

        public Guid InsertTimeRestriction(TimeRestrictionEntity timeRestrictionEntity)
        {
            return timeRestrictionDao.InsertTimeRestriction(timeRestrictionEntity);
        }

        public bool UpdateTimeRestriction(TimeRestrictionEntity timeRestrictionEntity)
        {
            return timeRestrictionDao.UpdateTimeRestriction(timeRestrictionEntity);

        }

        public DataSet SelectTimeRestrictionByTimeRestrictionId(Guid timeRestrictionId)
        {
            return timeRestrictionDao.SelectTimeRestrictionByTimeRestrictionId(timeRestrictionId);
          
        }

        public DataSet SelectTimeRestrictionAll()
        {
            return timeRestrictionDao.SelectTimeRestrictionAll();

        }
    }
}
