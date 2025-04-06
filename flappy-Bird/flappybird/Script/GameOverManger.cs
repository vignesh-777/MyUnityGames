using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManger : MonoBehaviour
{
   public static GameOverManger Instance;
   [SerializeField] GameObject gameOverObject;
   bool isGameOver;

    void Awake()
    {
        if(Instance != null && Instance != this){
            return;
        }
        Instance = this;
        gameOverObject.SetActive(false);

    }
    void Update()
    {
        if(isGameOver && (Input.anyKeyDown || Input.touchCount > 0)){
            StartCoroutine(RestartGame());
        }
    }
    IEnumerator RestartGame(){
        Time.timeScale = 1f;
        yield return new WaitForSecondsRealtime(0.3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    public void TriggerGameOver() {
        isGameOver = true;
        Time.timeScale = 0f;
        gameOverObject.SetActive(true);
    }
    public bool IsGameOvered(){
        return isGameOver;
    }
}
