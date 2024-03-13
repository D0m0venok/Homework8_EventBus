using System;
using System.Collections.Generic;
using System.Linq;
using UI;

namespace Game
{
    public sealed class HeroListEntity
    {
        private readonly Dictionary<HeroView, HeroEntity> _entities = new();
        
        public int Count => _entities.Count;
        
        public event Action<HeroEntity> HeroClicked;

        public void AddHero(HeroView view, HeroEntity entity)
        {
            _entities.Add(view, entity);
        }
        public List<HeroEntity> GetEntities()
        {
            return _entities.Values.ToList();
        }
        public HeroEntity GetEntity(int index)
        {
            return _entities.Values.ElementAt(index);
        }
        
        public void OnHeroClicked(HeroView view)
        {
            HeroClicked?.Invoke(_entities[view]);
        }
    }
}