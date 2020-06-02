using System;
using System.Collections.Generic;
using TPO_Lab3_Backend.Entities;
using TPO_Lab3_Backend.Models;

namespace TPO_Lab3_Backend.Services
{
    public class Mapper
    {
        public Bearer BearerEntityToModel(BearerInEntity entity)
        {
            return new Bearer()
            {
                Nickname = entity.Nickname,
                Phone = entity.Phone,
                Password = entity.Password
            };
        }

        public List<AlmsgivingsEntity> AlmsToAlmsEntities(List<Almsgiving> almsgivings)
        {
            var bearersAlms = new List<AlmsgivingsEntity>();
            almsgivings.ForEach(alm =>
                bearersAlms.Add(new AlmsgivingsEntity()
                {
                    Date = alm.Date,
                    Id = alm.Id,
                    Name = alm.Name,
                    Type = alm.Type
                }));
            return bearersAlms;
        }

        public AlmsgivingEntity AlmsToAlmEntity(Almsgiving alms, Bearer bearer, string photo)
        {
            return new AlmsgivingEntity()
            {
                Id = alms.Id,
                Description = alms.Description,
                BearerId = bearer.Id,
                Date = alms.Date,
                Name = alms.Name,
                Nickname = bearer.Nickname,
                Phone = bearer.Phone,
                Photo = photo,
                Type= alms.Type
            };
        }

        public Almsgiving AlmEntityToAlms(AlmsgivingEntity alms, DateTime dateTime,string filepath)
        {
            return new Almsgiving()
            {
                BearerId = alms.BearerId,
                Date = dateTime,
                Description = alms.Description,
                Name = alms.Name,
                Photo = filepath,
                Type = alms.Type
            };
        }
    }
}