using System.Collections.Generic;
using System.Threading.Tasks;


namespace StarWars.Models
{
    public interface IStarWarsRepository
    {
        IEnumerable<StarWarsCharacter> GetFriends(StarWarsCharacter character);
        Task<Human> GetHumanByIdAsync(string id);
        Task<Droid> GetDroidByIdAsync(string id);
        Human AddHuman(Human human);
    }
}
