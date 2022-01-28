using UnityEngine;

namespace DefaultNamespace
{
    public static class Extensions
    {
        public static GameObject GetChildWithName(this GameObject obj, string name) {
            Transform trans = obj.transform;
            Transform childTrans = trans. Find(name);
            if (childTrans != null) {
                return childTrans.gameObject;
            } else {
                return null;
            }
        }
    }
}