using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class ExitHandler : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            QuitGame();
        }
    }

    void QuitGame()
    {
    #if UNITY_EDITOR
        // Stop play mode in the editor
        EditorApplication.isPlaying = false;
    #else
        // Quit application on mobile or build
        Application.Quit();
    #endif
    }
}
