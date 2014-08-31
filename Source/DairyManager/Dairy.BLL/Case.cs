﻿using System;
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

        public bool DeleteCase(Guid caseId)
        {
            return caseDao.DeleteCase(caseId);
        }

        public DataSet SelectCaseByCaseId(Guid caseId)
        {
            return caseDao.SelectCaseByCaseId(caseId);
         
        }

        public DataSet SelectAllCase()
        {
            return caseDao.SelectAllCase();

        }

        public bool IsCaseExists(string code)
        {

            return caseDao.IsCaseExists(code);
        }

        public Guid InsertCaseType(CaseTypeEntity caseTypeEntity)
        {
            return caseDao.InsertCaseType(caseTypeEntity);

        }

        public bool UpdateCaseType(CaseTypeEntity caseTypeEntity)
        {
            return caseDao.UpdateCaseType(caseTypeEntity);

        }

        public bool DeleteCaseType(Guid caseTypeId)
        {
            return caseDao.DeleteCaseType(caseTypeId);
          
        }

        public DataSet SelectCaseTypeByCaseTypeId(Guid caseTypeId)
        {
            return caseDao.SelectCaseTypeByCaseTypeId(caseTypeId);

        }

        public DataSet SelectAllCaseType()
        {
            return caseDao.SelectAllCaseType();

        }

        public bool IsCaseCodeExists(string caseCode)
        {
            return caseDao.IsCaseCodeExists(caseCode);

        }

        public DataSet SelectAllOffence()
        {
            return caseDao.SelectAllOffence();
        }

        public DataSet SelectAllCourt()
        {
            return caseDao.SelectAllCourt();
        }

  

        public DataSet SelectClientDescriptionByCaseId(Guid caseId)
        {
            return caseDao.SelectClientDescriptionByCaseId(caseId);
        }


    }
}
