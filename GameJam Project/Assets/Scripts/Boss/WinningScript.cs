using System.Collections;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinningScript : MonoBehaviour{
    private void Start() {
        GlobalEvents.WinGame += Winning;
    }

    public void Winning() {
        StartCoroutine(SceneStarterCoroutine());
    }
    
    private IEnumerator SceneStarterCoroutine() {
        yield return new WaitForSeconds(0.5f);
        Time.timeScale = 1;
        SceneManager.LoadScene("Winning");
    }
}
