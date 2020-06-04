using System;
using System.Collections.Generic;
using System.IO;
using TPO_Lab3_Backend.Entities;
using TPO_Lab3_Backend.Models;

namespace TPO_Lab3_Backend.Services
{
    public class AlmsgivingService
    {
        private readonly AlmsgivingRepository _almsgivingRepository;
        private readonly BearerRepository _bearerRepository;
        private readonly Mapper _mapper;


        public AlmsgivingService(AlmsgivingRepository almsgivingRepository, Mapper mapper,
            BearerRepository bearerRepository)
        {
            _almsgivingRepository = almsgivingRepository;
            _mapper = mapper;
            _bearerRepository = bearerRepository;
        }

        public List<AlmsgivingsEntity> GetAll()
        {
            return _mapper.AlmsToAlmsEntities(_almsgivingRepository.GetAllAlmsgivings());
        }

        public List<AlmsgivingsEntity> SearchAlms(string searchString)
        {
            return _mapper.AlmsToAlmsEntities(_almsgivingRepository.SearchAlmsgivings(searchString));
        }

        public AlmsgivingEntity GetAlms(int id)
        {
            var alm = _almsgivingRepository.GetAlmsgivingById(id);
            var bearer = _bearerRepository.GetBearerById((int)alm.BearerId);
            var photo = Convert.ToBase64String(File.ReadAllBytes(alm.Photo));
            var asd = _mapper.AlmsToAlmEntity(alm, bearer, photo);
            return asd;
        }

        public bool AddAlms(AlmsgivingEntity alms)
        {
            try
            {
                string filepath = @"D:\TPO3_Photos\" + Guid.NewGuid() + ".jpg";
                File.WriteAllBytes(filepath, Convert.FromBase64String(alms.Photo));
                Almsgiving alm = _mapper.AlmEntityToAlms(alms, DateTime.Today, filepath);
                _almsgivingRepository.AddAlmsgiving(alm);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteAlms(int id)
        {
            try
            {
                _almsgivingRepository.DeleteAlmsgiving(id);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}