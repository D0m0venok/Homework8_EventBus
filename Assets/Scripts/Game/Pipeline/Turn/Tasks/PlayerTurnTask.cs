using Game.Effects;
using UI;
using UnityEngine;

namespace Game.Pipeline.Turn.Tasks
{
    public sealed class PlayerTurnTask : Task
    {
        private readonly EventBus _eventBus;
        private readonly HeroListEntity  _attackingPlayerEntities;
        private readonly HeroListEntity  _defendingPlayerEntities;
        private readonly HeroListView _attackingPlayerViews;
        private readonly HeroListView _defendingPlayerViews;
        private readonly TeamType _teamType;
        private int _heroIndex = -1;

        public PlayerTurnTask(EventBus eventBus, HeroEntitiesService entitiesService, UIService uiService, TeamType teamType)
        {
            _eventBus = eventBus;
            _teamType = teamType;
            
            if (_teamType == TeamType.Red)
            {
                _attackingPlayerEntities = entitiesService.GetRedPlayerEntities();
                _defendingPlayerEntities = entitiesService.GetBluePlayerEntities();

                _attackingPlayerViews = uiService.GetRedPlayer();
                _defendingPlayerViews = uiService.GetBluePlayer();
            }
            else
            {
                _attackingPlayerEntities = entitiesService.GetBluePlayerEntities();
                _defendingPlayerEntities = entitiesService.GetRedPlayerEntities();
                
                _attackingPlayerViews = uiService.GetBluePlayer();
                _defendingPlayerViews = uiService.GetRedPlayer();
            }
        }

        protected override void OnRun()
        {
            _attackingPlayerViews.SetActive(true);
            _defendingPlayerViews.SetActive(false);

            var count = _attackingPlayerEntities.Count;
            for (var i = 0; i < count; i++)
            {
                _heroIndex = ++_heroIndex % count;
                var hero = _attackingPlayerEntities.GetEntity(_heroIndex);

                if (hero.Get<HealthComponent>().IsAlive)
                {
                    if (hero.TryGet<ConditionComponent>(out var conditionComponent) && conditionComponent.Has<FrozenCondition>())
                    {
                        conditionComponent.Remove<FrozenCondition>();
                        continue;
                    }
                    
                    hero.Get<StartTurnComponent>().StartTurn();
                    _defendingPlayerEntities.HeroClicked += OnHeroClicked;
                    break;
                }
            }
        }
        protected override void OnFinish()
        {
            _attackingPlayerViews.GetView(_heroIndex).SetActive(false);
        }
        
        private void OnHeroClicked(IEntity targetEntity)
        {
            _defendingPlayerEntities.HeroClicked -= OnHeroClicked;
            
            var sourceEntity = _attackingPlayerEntities.GetEntity(_heroIndex);

            if (sourceEntity.TryGet<AbilityComponent>(out var abilityComponent) && 
                abilityComponent.Ability.Effect is RandomTargetEffect randomTargetEffect)
            {
                if(randomTargetEffect.Percent > Random.Range(0, 100))
                {
                    abilityComponent.PlaySoundAbility();
                    var tempEnemies = _defendingPlayerEntities.GetEntities();
                    tempEnemies.Remove((HeroEntity)targetEntity);
                    targetEntity = tempEnemies[Random.Range(0, tempEnemies.Count)];
                }
            }

            _eventBus.RaiseEvent(new AttackEvent(sourceEntity, targetEntity));
            
            if (abilityComponent.Ability.Effect is HealingEffect healingEffectEvent)
            {
                abilityComponent.PlaySoundAbility();
                var heroes = _attackingPlayerEntities.GetEntities();
                heroes.Remove(sourceEntity);
                var target = heroes[Random.Range(0, heroes.Count)];
                _eventBus.RaiseEvent(new HealingEvent(target, healingEffectEvent.Health));
            }
            else if (abilityComponent.Ability.Effect is DamageEffect damageEffectEvent)
            {
                abilityComponent.PlaySoundAbility();
                var enemies = _defendingPlayerEntities.GetEntities();
                var target = enemies[Random.Range(0, enemies.Count)];
                _eventBus.RaiseEvent(new DealDamageEvent(target, damageEffectEvent.Damage));
            }
            
            Finish();
        }
    }
}