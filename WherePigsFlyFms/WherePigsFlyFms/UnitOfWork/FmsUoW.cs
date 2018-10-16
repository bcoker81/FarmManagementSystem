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
        private GenericRepository<MedicalRecords> _medicalRepo;

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

        public GenericRepository<MedicalRecords> MedicalRepo
        {
            get
            {
                if (_medicalRepo == null)
                {
                    _medicalRepo = new GenericRepository<MedicalRecords>(_entities);
                }

                return _medicalRepo;
            }
        }

        public void Commit()
        {
            _entities.SaveChanges();
        }
       
    }
}