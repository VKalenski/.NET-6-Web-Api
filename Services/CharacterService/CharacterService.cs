using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Data;
using Dtos.Character;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Service.CharacterService
{
    public class CharacterService : ICharacterService
    {       
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public CharacterService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter)
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            Character character = _mapper.Map<Character>(newCharacter);
            _context.Characters.Add(character);
            await _context.SaveChangesAsync();
            serviceResponse.Data = await _context.Characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToListAsync();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacter(int id)
        {
            ServiceResponse<List<GetCharacterDto>> response = new ServiceResponse<List<GetCharacterDto>>();

            try
            {
                Character character = await _context.Characters.FirstAsync(c => c.Id == id);
                _context.Characters.Remove(character);
                await _context.SaveChangesAsync();
                response.Data = _context.Characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }           

            return response;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters()
        {
            var response =  new ServiceResponse<List<GetCharacterDto>>();
            var dbCharacters = await _context.Characters.ToListAsync();
            response.Data = dbCharacters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
            return response;
        }
        
        public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDto>();
            var dbCharacter = await _context.Characters.FirstOrDefaultAsync(c => c.Id == id);
            serviceResponse.Data = _mapper.Map<GetCharacterDto>(dbCharacter);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCracterDto updatedCracter)
        {
            ServiceResponse<GetCharacterDto> response = new ServiceResponse<GetCharacterDto>();
            try
            {
                var character = await _context.Characters.FirstOrDefaultAsync(c => c.Id == updatedCracter.Id);

                // _mapper.Map(updatedCracter, character);

                character.Name = updatedCracter.Name;
                character.HitPoints = updatedCracter.HitPoints;
                character.Strength = updatedCracter.Strength;
                character.Defense = updatedCracter.Defense;
                character.Intelligence = updatedCracter.Intelligence;
                character.Class = updatedCracter.Class;

                await _context.SaveChangesAsync();
                
                response.Data = _mapper.Map<GetCharacterDto>(character);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }           

            return response;
        }
    }
}