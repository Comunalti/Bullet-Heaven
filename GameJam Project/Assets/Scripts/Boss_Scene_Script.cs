using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss_Scene_Script : MonoBehaviour{
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Boss_Scene")
            SceneManager.LoadScene("Boss_scene");
    }
}
