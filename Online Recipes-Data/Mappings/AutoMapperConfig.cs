using AutoMapper;
using Online_Recipes_Domain.Account;
using Online_Recipes_Domain.DTOs;
using Online_Recipes_Domain.Models;

namespace Online_Recipes_Data.Mappings
{
    public class AutoMapperConfig : Profile
    {
        // Mapeamento entre Class do Domain
        public AutoMapperConfig()
        {
            //Recipe -> RecipeDTO
            CreateMap<Recipe, RecipeDto>().ReverseMap();

            //User -> UserDTO
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
