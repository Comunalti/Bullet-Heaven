using DefaultNamespace;
using Entity;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthUI : MonoBehaviour
{
    private Image _image;
    [SerializeField] private Health _health;
    void Start()
    {
        _image = GetComponent<Image>();
        _health.OnDiedEvent += OnDied;
        _health.OnHealthRemovedEvent += OnDamage;
        _health.OnHealthAddedEvent += OnDamage;
    }

    private void OnDestroy()
    {
        _health.OnDiedEvent -= OnDied;
        _health.OnHealthRemovedEvent -= OnDamage;
        _health.OnHealthAddedEvent -= OnDamage;
    }


    private void OnDied()
    {
       Destroy(gameObject.transform.parent.gameObject);
       Destroy(_health.gameObject);
       GlobalEvents.WinGame?.Invoke();
    }

    private void OnDamage()
    {
        _image.fillAmount = _health.CurrentHealth / _health.MaxHealth;
    }
}
