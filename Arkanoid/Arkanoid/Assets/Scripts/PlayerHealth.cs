using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{

    //creating the instance of class
    public static PlayerHealth Instance;

    [Header("Ui")]
   [SerializeField] public int health;
   [SerializeField] GameObject healthPrefab;
   [SerializeField] Transform imageHealthContainer;

    [Header("Ball-Spawn")]
   [SerializeField] GameObject ballPrefab;
   [SerializeField] GameObject player;
   [SerializeField] Transform spawnPos;
    void Awake()
    {
        if(Instance != null && Instance != this){
            return;
        }
        Instance = this;
    }
    void Start()
    {
        updateUiHealth();        
        StartCoroutine(SpawnBall());
    }

    public void HeartHit(int value){
        health -= value;
        if(health >0){
            
        updateUiHealth();
        StartCoroutine(SpawnBall());

        }
    }
    void  updateUiHealth(){

        //the contain any heath before game start to destroy 
        foreach(Transform child in imageHealthContainer){
            Destroy(child.gameObject);
        }

        //create ui health
        for(int i=1 ; i<health;i++){
            Instantiate(healthPrefab,imageHealthContainer);
        }
    }

    int  GetHealth(){
        return health;
    }
    
    IEnumerator SpawnBall(){
        yield return new WaitForSeconds(0.5f);
        GameObject ball = Instantiate(ballPrefab,spawnPos.position,Quaternion.identity);
        ball.transform.SetParent(player.transform);
        
    }
}
