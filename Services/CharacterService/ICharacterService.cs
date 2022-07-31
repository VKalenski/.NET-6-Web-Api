using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace Service.CharacterService
{
    public interface ICharacterService
    {
        Task<List<Character>> AddCharacter(Character newCharacter);        

        Task<List<Character>> GetAllCharacters();

        Task<Character> GetCharacterById(int id);
    }
}