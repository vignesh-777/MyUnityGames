using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void Update()
    {
        
        // Check for PC or mobile input
        if (Input.GetKeyDown(KeyCode.Space)|| Input.GetKeyDown(KeyCode.Mouse0) || 
        (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
        {
            LoadGameScene();
        }
        
    }

    void LoadGameScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
