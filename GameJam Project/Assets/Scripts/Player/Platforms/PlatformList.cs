using System;
using System.Collections.Generic;
using System.Linq;
using DefaultNamespace;
using UnityEngine;

namespace Player.Platforms
{
    [CreateAssetMenu]
    public class PlatformList : ScriptableObject
    {
        public List<PlatformTemplate> platformTemplates = new List<PlatformTemplate>();

        public event Action<PlatformTemplate> ItemAddedEvent;
        public event Action<PlatformTemplate> ItemRemovedEvent;

        [ContextMenu("remove last item")]
        private void RemoveLastItem()
        {
            Remove(platformTemplates.Last());
        }
        
        [ContextMenu("add last item")]
        private void AddLastItem()
        {
            ItemAddedEvent?.Invoke(platformTemplates.Last());
        }
        
        public void Add(PlatformTemplate platformTemplate)
        {
            platformTemplates.Add(platformTemplate);
            ItemAddedEvent?.Invoke(platformTemplate);
        }
        
        public void Remove(PlatformTemplate platformTemplate)
        {
            if (platformTemplates.Remove(platformTemplate))
            {
                ItemRemovedEvent?.Invoke(platformTemplate);
            }
        }
    }
}