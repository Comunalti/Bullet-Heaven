using UnityEngine;

[RequireComponent(typeof(Animator))]
public class FocusUi : MonoBehaviour{
    public bool Ativado = true;
    private Animator _animator;
    
    private void Awake() {
        _animator = GetComponent<Animator>();
    }   

    [ContextMenu("Remove")]
    public void Remove() {
        _animator.SetTrigger("RemoveFocus");
        Ativado = false;
    }
    
    [ContextMenu("Add")]
    public void Add() {
        Ativado = true;
        _animator.SetTrigger("AddFocus");
    }
}