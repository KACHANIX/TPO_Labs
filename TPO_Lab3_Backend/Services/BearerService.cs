﻿using System;
using TPO_Lab3_Backend.Entities;
using TPO_Lab3_Backend.Models;

namespace TPO_Lab3_Backend.Services
{
    public class BearerService
    {
        private readonly BearerRepository _bearerRepository;
        private readonly AlmsgivingRepository _almsgivingRepository;
        private readonly Mapper _mapper;

        public BearerService(BearerRepository bearerRepository, Mapper mapper, AlmsgivingRepository almsgivingRepository)
        {
            _bearerRepository = bearerRepository;
            _mapper = mapper;
            _almsgivingRepository = almsgivingRepository;
        }

        public bool CheckNicknameIsFree(string nickname)
        {
            return _bearerRepository.IsBearerNicknameFree(nickname);
        }

        public bool RegisterBearer(BearerInEntity bearer)
        {
            try
            {
                var bearerModel = _mapper.BearerEntityToModel(bearer);
                _bearerRepository.RegisterNewBearer(bearerModel);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public BearerProfile GetBearerProfile(int bearerId)
        {
            var bearer = _bearerRepository.GetBearerById(bearerId);
            var almsgivings = _almsgivingRepository.GetAllBearersAlmsgivings(bearerId);
           var alms =  _mapper.AlmsToAlmsEntities(almsgivings);
           return new BearerProfile()
           {
               Nickname = bearer.Nickname,
               Phone = bearer.Phone,
               Almsgivings = alms
           };
        }

        public bool AutheticateBearer(BearerInEntity bearer)
        {
            return _bearerRepository.Authorize(_mapper.BearerEntityToModel(bearer));
        }
    }
}
