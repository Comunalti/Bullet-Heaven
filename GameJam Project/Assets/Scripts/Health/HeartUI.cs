using UnityEngine;

[RequireComponent(typeof(Animator))]
public class HeartUI : MonoBehaviour
{
    private Animator _animator;

    public bool isEmpty = false;
    private void Start()
    {
        _animator = GetComponent<Animator>();
    }
    
    [ContextMenu("Empty heart")]
    public void SetEmpty()
    {
        isEmpty = true;
        _animator.SetTrigger("Empty");
    }
    [ContextMenu("Fill heart")]
    public void SetFull()
    {
        isEmpty = false;
        _animator.SetTrigger("Fill");
    }
}