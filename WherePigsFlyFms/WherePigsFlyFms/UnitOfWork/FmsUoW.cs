using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WherePigsFlyFms.Data;
using WherePigsFlyFms.Models;
using WherePigsFlyFms.Repository;

namespace WherePigsFlyFms.UnitOfWork
{
    public class FmsUoW : IFmsUoW
    {
        private GenericRepository<Animals> _animalRepo;
        //private GenericRepository<MedicalRecords> _medicalRepo;
        private GenericRepository<VaccinationModel> _vaccineRepo;
        private GenericRepository<MedLookupModel> _lookupRepo;
        private GenericRepository<AttachmentModel> _attachmentRepo;
        private FmsDbContext _entities;

        public FmsUoW(FmsDbContext Entities)
        {
            _entities = Entities;
        }

        public GenericRepository<Animals> AnimalRepo {
            get
            {
                if (_animalRepo == null)
                {
                    _animalRepo = new GenericRepository<Animals>(_entities);
                }

                return _animalRepo;
            }
        }

        public GenericRepository<AttachmentModel> AttachmentRepo
        {
            get
            {
                if (_attachmentRepo == null)
                {
                    _attachmentRepo = new GenericRepository<AttachmentModel>(_entities);
                }

                return _attachmentRepo;
            }
        }

        public GenericRepository<VaccinationModel> VaccineRepo
        {
            get
            {
                if (_vaccineRepo == null)
                {
                    _vaccineRepo = new GenericRepository<VaccinationModel>(_entities);
                }

                return _vaccineRepo;
            }
        }

        public GenericRepository<MedLookupModel> LookupRepo
        {
            get
            {
                if (_lookupRepo == null)
                {
                    _lookupRepo = new GenericRepository<MedLookupModel>(_entities);
                }

                return _lookupRepo;
            }
        }

        public void Commit()
        {
            _entities.SaveChanges();
        }
       
    }
}