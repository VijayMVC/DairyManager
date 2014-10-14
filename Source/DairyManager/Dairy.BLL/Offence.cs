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
    public class Offence
    {
        OffenceDao offenceDao = new OffenceDao();

        public Guid InsertOffence(OffenceEntity offenceEntity)
        {
            return offenceDao.InsertOffence(offenceEntity);
        }

        public bool UpdateOffence(OffenceEntity offenceEntity)
        {
            return offenceDao.UpdateOffence(offenceEntity);
        }

        public bool DeleteOffence(Guid offenceTypeId)
        {

            return offenceDao.DeleteOffence(offenceTypeId);
         
        }

        public DataSet SelectOffenceByOffenceTypeId(Guid offenceTypeId)
        {
            return offenceDao.SelectOffenceByOffenceTypeId(offenceTypeId);
           
        }

        public DataSet SelectAllOffence()
        {
            return offenceDao.SelectAllOffence();
           
        }

        public bool IsOffenceExists(string offence)
        {
            return offenceDao.IsOffenceExists(offence);

        }
    }
}
