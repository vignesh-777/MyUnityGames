using System.Collections;
using UnityEngine;


public class PipeSpawner : MonoBehaviour
{
    [SerializeField] GameObject pipePrefab;
    [SerializeField] float initialSpawnDelay;
    float currentSpawnDelay;

    //pipe spawn at x-point mention
    [Header("X-Spawn Point")]
    [SerializeField] float xSpawnPoint;

    //pipe y clamp distance
    [Header("Y-Limits")]
    [SerializeField] float PlusYLimit;
    [SerializeField] float MinusYLimit;
    void Start()
    {
        StartCoroutine(SpawnPipes());
        
    }
    IEnumerator SpawnPipes(){
        while(true){
            //some delay
            yield return new WaitForSeconds(currentSpawnDelay);
            //specify the pos
            float spawnDistance = Random.Range(MinusYLimit,PlusYLimit);
            //creating a object
            GameObject pipe = Instantiate(pipePrefab,new Vector2(xSpawnPoint,spawnDistance),Quaternion.identity);
            //updating spawn delay time
            UpdateSpawnDelay();
        }    
    }
    void UpdateSpawnDelay(){
        int score = ScoreManager.Instance.GetScore();//getting score
        float progress = (float)score/1000;

        if(progress >= 0.75f){
            currentSpawnDelay = 1.5f;
        }
        else if(progress >= 0.50){
            currentSpawnDelay = 1.8f;
        }
        else if(progress >=0.25){
            currentSpawnDelay = 2f;
        }else{
            currentSpawnDelay = initialSpawnDelay;
        }

    }
}
