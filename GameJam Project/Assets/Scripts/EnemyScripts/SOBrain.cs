using UnityEngine;

namespace EnemyScripts{
    public abstract class SOBrain : ScriptableObject{
        public abstract void Think (MonoBehaviour monobehaviour);

        public virtual void InitializeBrain(MonoBehaviour monoBehaviour) {
            
        }
    }
}