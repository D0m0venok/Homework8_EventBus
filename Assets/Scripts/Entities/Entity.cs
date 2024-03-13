using System;
using System.Collections.Generic;
using System.Linq;

namespace Game
{
    public abstract class Entity : IEntity
    {
        private readonly Dictionary<Type, object> _components = new ();

        public void Add<T>(T component)
        {
            _components.Add(typeof(T), component);
        }
        public void Remove<T>()
        {
            _components.Remove(typeof(T));
        }
        public T Get<T>()
        {
            return (T)_components[typeof(T)];
        }
        public bool TryGet<T>(out T element)
        {
            if (_components.TryGetValue(typeof(T), out var e))
            {
                element = (T)e;
                return true;
            }
            
            element = default;
            return false;
        }
        public object[] GetAll()
        {
            return _components.Values.ToArray();
        }
    }

}