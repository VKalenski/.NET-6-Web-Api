using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Dtos.Character;
using Dtos.Fight;
using Dtos.Skill;
using Dtos.Weapon;
using Models;

namespace _NET_6_Web_Api
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Character, GetCharacterDto>();
            CreateMap<AddCharacterDto, Character>();
            CreateMap<Weapon, GetWeaponDto>();
            CreateMap<Skill, GetSkillDto>();
            CreateMap<Character, HighscoreDto>();
        }        
    }
}