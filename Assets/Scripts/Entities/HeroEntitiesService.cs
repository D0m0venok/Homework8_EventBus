using System;
using System.Collections.Generic;
using System.Linq;
using UI;
using Random = UnityEngine.Random;

namespace Game
{
    public sealed class HeroEntitiesService
    {
        private readonly HeroListEntity _redPlayerEntities = new();
        private readonly HeroListEntity _bluePlayerEntities = new();
        private readonly UIService _uiService;
        
        
        public HeroEntitiesService(HeroConfigs configs, UIService uiService)
        {
            _uiService = uiService;
            
            var models = new Queue<HeroConfig>(configs.Heroes.OrderBy(x => Random.value).ToArray());

            var redPlayer = _uiService.GetRedPlayer();
            redPlayer.OnHeroClicked += _redPlayerEntities.OnHeroClicked;
            foreach (var heroView in redPlayer.GetViews())
            {
                _redPlayerEntities.AddHero(heroView, new HeroEntity(models.Dequeue(), heroView, TeamType.Red));
            }

            var bluePlayer = _uiService.GetBluePlayer();
            bluePlayer.OnHeroClicked += _bluePlayerEntities.OnHeroClicked;
            foreach (var heroView in bluePlayer.GetViews())
            {
                _bluePlayerEntities.AddHero(heroView, new HeroEntity(models.Dequeue(), heroView, TeamType.Blue));
            }
        }
        
        ~HeroEntitiesService()
        {
            _uiService.GetRedPlayer().OnHeroClicked -= _redPlayerEntities.OnHeroClicked;
            _uiService.GetBluePlayer().OnHeroClicked -= _bluePlayerEntities.OnHeroClicked;
        }
        
        public HeroListEntity GetRedPlayerEntities()
        {
            return _redPlayerEntities;
        }
        public HeroListEntity GetBluePlayerEntities()
        {
            return _bluePlayerEntities;
        }
    }
}