using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Diagonactic;
using GameSandbox.Components;

namespace GameSandbox.Entities
{
    public class EntityManager
    {
        private List<Entity>[] _entitySets;
        private Dictionary<ComponentType, int> _indexMap;
        private int _indexCount = 0;

        public EntityManager()
        {
            int numComponents = Enum.GetValues(typeof(ComponentType)).Length;
            _entitySets = new List<Entity>[numComponents]; 
            _indexMap = new Dictionary<ComponentType, int>(Enums.EqualityComparer<ComponentType>());
        }

        public void AddEntity(Entity entity)
        {
            bool added = false;
            foreach(var key in _indexMap.Keys)
            {
                // Is there an entry in the map matching this entities components?
                if ((entity.ComponentMask & key) == key) 
                {
                    _entitySets[_indexMap[key]].Add(entity);
                    added = true;
                }
            }
            // If not added to _entityset, add an entry with the entity componentMask and store it.
            if (!added)
            {
                int key = GetOrCreateIndex(entity.ComponentMask);
                _entitySets[key].Add(entity);
            }
        }

        public void RemoveEntity(Entity entity)
        {
            // TODO: Implement. Need entity ID.
        }

        public List<Entity> GetEntities(ComponentType type)
        {
            return _entitySets[_indexMap[type]];
        }
        
        private int GetOrCreateIndex(ComponentType mask)
        {
            // If there's no entry, create an index and initialize a list in the entity array
            if (!_indexMap.TryGetValue(mask, out int index)) 
            {
                _indexMap[mask] = _indexCount;
                _entitySets[_indexCount] = new List<Entity>();
                return _indexCount++;
            }
            return index;
        }

        public void AddSystemEntry(ComponentType entitySet)
        {
            GetOrCreateIndex(entitySet);
           
        }
    }
}
