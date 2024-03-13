using System;
using System.Collections.Generic;

namespace Game
{
    public class ConditionComponent
    {
        private HashSet<Type> _conditions = new ();

        public void Add<T>() where T : ICondition
        {
            _conditions.Add(typeof(T));
        }
        public void Remove<T>() where T : ICondition
        {
            _conditions.Remove(typeof(T));
        }
        public bool Has<T>() where T : ICondition
        {
            return _conditions.Contains(typeof(T));
        }
    }
}