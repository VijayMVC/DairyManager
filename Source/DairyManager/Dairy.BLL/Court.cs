using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Diary.DAL;
using Diary.Entity;


namespace Diary.BLL
{
    public class Court
    {
        CourtDao courtDao = new CourtDao();

        public Guid InsertCourt(CourtEntity courtEntity)
        {
            return courtDao.InsertCourt(courtEntity);
        }

        public bool UpdateCourt(CourtEntity courtEntity)
        {
            return courtDao.UpdateCourt(courtEntity);
        }

        public bool DeleteCourt(Guid courtId)
        {
            return courtDao.DeleteCourt(courtId);
        }

        public DataSet SelectCourtBycourtId(Guid courtId)
        {
            return courtDao.SelectCourtBycourtId(courtId);
        }

        public DataSet SelectAllCourt()
        {
            return courtDao.SelectAllCourt();          
        }

        public bool IsCourtExists(string court)
        {
            return courtDao.IsCourtExists(court);
        }

        public DataSet SelectAllCourtTypes()
        {
            return courtDao.SelectAllCourtTypes();          
        }
    }
}
