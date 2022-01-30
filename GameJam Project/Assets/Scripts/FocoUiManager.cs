using System;
using System.Collections.Generic;
using System.Linq;
using Player;
using UnityEngine;

public class FocoUiManager : MonoBehaviour{
    [SerializeField] private FocusSystem _playerFocusSystem;
    [SerializeField] private GameObject _focusPrefab;

    private List<FocusUi> _focusUiList = new List<FocusUi>();

    private void Awake()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }

    private void OnEnable() {
        _playerFocusSystem.IntegerFocusAddedEvent += AddOnUi;
        _playerFocusSystem.IntegerFocusRemovedEvent += RemoveFromUI;
        _playerFocusSystem.CreateDeltaMoreEvent += AddFocus;
        
        
        for (var i = 0; i < _playerFocusSystem.MaximumFocus; i++) {
            AddFocus();
        }
    }

    private void OnDisable() {
        _playerFocusSystem.IntegerFocusAddedEvent -= AddOnUi;
        _playerFocusSystem.IntegerFocusRemovedEvent -= RemoveFromUI;
        _playerFocusSystem.CreateDeltaMoreEvent -= AddFocus;

    }


    


    private void RemoveFromUI(int deltaFocusValue) {
        for (var i = 0; i < deltaFocusValue; i++) {
            RemoveFocus();
        }
    }

    private void AddOnUi(int deltaFocusValue) {
        for (var i = 0; i < deltaFocusValue; i++) {
            FillFocus();
        }
        
    }

    private void AddFocus(int quantity)
    {
        for (int i = 0; i < quantity; i++)
        {
            AddFocus();
        }
    }
    [ContextMenu("Create focus")]
    private void AddFocus() {
        var gameObject = Instantiate(_focusPrefab, transform);
        
        _focusUiList.Add(gameObject.GetComponent<FocusUi>());
    }

    [ContextMenu("Remove focus")]
    private void RemoveFocus() {
       var focusUi =  _focusUiList.LastOrDefault(ui => ui.Ativado);
       if (focusUi)
       {
           focusUi.Remove();
       }
    }

    private void FillFocus() {
        var focusUi = _focusUiList.FirstOrDefault(ui => !ui.Ativado);
        if (focusUi)
        {
            focusUi.Add();
        }
    }
}