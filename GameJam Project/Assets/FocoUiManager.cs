using System.Collections.Generic;
using System.Linq;
using Player;
using UnityEngine;

public class FocoUiManager : MonoBehaviour{
    [SerializeField] private FocusSystem _playerFocusSystem;
    [SerializeField] private GameObject _focusPrefab;

    private List<FocusUi> _focusUiList = new List<FocusUi>();

    private void OnEnable() {
        _playerFocusSystem.IntegerFocusAddedEvent += AddOnUi;
        _playerFocusSystem.IntegerFocusRemovedEvent += RemoveFromUI;
        
        for (var i = 0; i < _playerFocusSystem.maximumFocus; i++) {
            AddFocus();
        }
    }

    private void OnDisable() {
        _playerFocusSystem.IntegerFocusAddedEvent -= AddOnUi;
        _playerFocusSystem.IntegerFocusRemovedEvent -= RemoveFromUI;
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
    [ContextMenu("Create focus")]
    private void AddFocus() {
        var gameObject = Instantiate(_focusPrefab, transform);
        
        _focusUiList.Add(gameObject.GetComponent<FocusUi>());
    }

    [ContextMenu("Remove focus")]
    private void RemoveFocus() {
       var focusUi =  _focusUiList.Last(ui => ui.Ativado);
       focusUi.Remove();
    }

    private void FillFocus() {
        var focusUi = _focusUiList.First(ui => !ui.Ativado);

        focusUi.Add();
    }
}