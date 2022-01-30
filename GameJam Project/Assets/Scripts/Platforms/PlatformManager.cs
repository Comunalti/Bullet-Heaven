using DefaultNamespace;
using Player.Platforms;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    [SerializeField]
    private PlatformList platformList;

    private new Transform transform;
    
    private void OnItemAdded(PlatformTemplate obj)
    {
        Instantiate(obj.uiPlatform, transform);
    }

    private void OnItemRemoved(PlatformTemplate obj)
    {

        foreach (Transform child in transform)
        {
            if (child.GetComponent<PlatformButton>().platformTemplate == obj)
            {
                Destroy(child.gameObject);
            }
        }
    }
    
    private void Awake()
    {
        transform = GetComponent<Transform>();
    }

    private void OnEnable(){
        platformList.ItemAddedEvent += OnItemAdded;
        platformList.ItemRemovedEvent += OnItemRemoved;

        foreach (var template in platformList.platformTemplates){
            OnItemAdded(template);
        }
    }

    
    private void OnDisable()
    {
        platformList.ItemAddedEvent -= OnItemAdded;
        platformList.ItemRemovedEvent -= OnItemRemoved;

        foreach (Transform childTransform in transform)
        {
            Destroy(childTransform.gameObject);
        }
    }
}