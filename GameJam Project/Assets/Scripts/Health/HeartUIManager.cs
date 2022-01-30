using System.Collections.Generic;
using System.Linq;
using Entity;
using UnityEngine;

public class HeartUIManager : MonoBehaviour
{
    [SerializeField] private GameObject _heartPrefab;
    [SerializeField] private Health _health;

    
    public List<HeartUI> Hearts = new List<HeartUI>();

    private void Start()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);

        }

        //_health = GetComponentInParent<Health>();
        AddHeart(Mathf.CeilToInt(_health.MaxHealth));
        _health.OnDiedEvent += OnDeath;
        _health.OnHealthAddedEvent += FillHeart;
        _health.OnHealthRemovedEvent += RemoveHeart; 
    }

    private void OnDestroy()
    {
        _health.OnDiedEvent -= OnDeath;
        
    }

    private void OnDeath()
    {
        _health.OnHealthAddedEvent -= FillHeart;
        _health.OnHealthRemovedEvent -= RemoveHeart; 
        gameObject.SetActive(false);
    }

    public void AddHeart(int quantity)
    {
        for (int i = 0; i < quantity; i++)
        {
            AddHeart();
        }
    }
    [ContextMenu("Create new heart")]
    public void AddHeart()
    {
        Hearts.Add(Instantiate(_heartPrefab, transform).GetComponent<HeartUI>());
    }

    [ContextMenu("Fill heart")]
    public void FillHeart()
    {
        var heart = Hearts.First(a => a.isEmpty);
        heart.SetFull();
    }
    
    [ContextMenu("Empty heart")]
    public void RemoveHeart()
    {
        var heart = Hearts.Last(a => !a.isEmpty);
        heart.SetEmpty();
    }
}