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
    public class Case
    {

        CaseDao caseDao = new CaseDao();

        public Guid InsertCase(CaseEntity caseEntity)
        {
            return caseDao.InsertCase(caseEntity);

        }

        public bool UpdateCase(CaseEntity caseEntity)
        {
            return caseDao.UpdateCase(caseEntity);
        }

        public bool DeleteCase(CaseEntity caseEntity)
        {
            return caseDao.DeleteCase(caseEntity);
        }

        public DataSet SelectCaseByCaseId(Guid caseId)
        {
            return caseDao.SelectCaseByCaseId(caseId);
         
        }

        public DataSet SelectAllCase()
        {
            return caseDao.SelectAllCase();

        }

        public Guid InsertCaseType(CaseTypeEntity caseTypeEntity)
        {
            return caseDao.InsertCaseType(caseTypeEntity);

        }

        public bool UpdateCaseType(CaseTypeEntity caseTypeEntity)
        {
            return caseDao.UpdateCaseType(caseTypeEntity);

        }

        public bool DeleteCaseType(CaseTypeEntity caseTypeEntity)
        {
            return caseDao.DeleteCaseType(caseTypeEntity);
          
        }

        public DataSet SelectCaseTypeByCaseTypeId(Guid caseTypeId)
        {
            return caseDao.SelectCaseTypeByCaseTypeId(caseTypeId);

        }

        public DataSet SelectAllCaseType(Guid caseTypeId)
        {
            return caseDao.SelectAllCaseType(caseTypeId);

        }

        public bool IsCaseCodeExists(string caseCode)
        {
            return caseDao.IsCaseCodeExists(caseCode);

        }

    }
}
