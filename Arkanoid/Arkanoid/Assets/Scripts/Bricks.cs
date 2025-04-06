using UnityEngine;

public class Bricks : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent<Ball>(out Ball ball)){
            SpawnPowers spawnPowers = FindObjectOfType<SpawnPowers>();
            if(spawnPowers!= null){
                spawnPowers.PowerUpSpawner(transform.position);
            }
            Destroy(gameObject);
            
        }
    }
}
