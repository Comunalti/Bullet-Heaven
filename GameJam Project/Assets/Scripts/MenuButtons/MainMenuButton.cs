using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButton : MonoBehaviour{
    [SerializeField] private string sceneName;
    [SerializeField] private float delay;


    public void LoadScene() {
        StartCoroutine(SceneStarterCoroutine(delay));
    }
    
    private IEnumerator SceneStarterCoroutine(float delay) {
        yield return new WaitForSeconds(delay);
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneName);
    }
}
