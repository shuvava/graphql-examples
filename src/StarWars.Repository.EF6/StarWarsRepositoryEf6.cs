using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using GraphQL;

using Microsoft.EntityFrameworkCore;

using StarWars.Models;


namespace StarWars.Repository.EF6
{
    // ReSharper disable once UnusedMember.Global
    public class StarWarsRepositoryEF6 : IStarWarsRepository
    {
        private readonly StarWarsContext _context;


        public StarWarsRepositoryEF6(StarWarsContext context)
        {
            _context = context;
        }
        public IEnumerable<StarWarsCharacter> GetFriends(StarWarsCharacter character)
        {
            if (character == null)
            {
                return null;
            }
            var lookup = character.Friends;

            if (lookup == null)
            {
                return Enumerable.Empty<StarWarsCharacter>();
            }

            var friends = new List<StarWarsCharacter>();
            _context.Humans.Where(h => lookup.Contains(h.Id)).Apply(friends.Add);
            _context.Droids.Where(d => lookup.Contains(d.Id)).Apply(friends.Add);

            return friends;
        }


        public Task<Human> GetHumanByIdAsync(string id)
        {
            return _context.Humans.Where(h => h.Id == id).FirstOrDefaultAsync();
        }


        public Task<Droid> GetDroidByIdAsync(string id)
        {
            return _context.Droids.Where(h => h.Id == id).FirstOrDefaultAsync();
        }


        public Human AddHuman(Human human)
        {
            human.Id = Guid.NewGuid().ToString();
            _context.Humans.Add(human);

            _context.SaveChanges();

            return human;
        }
    }
}
