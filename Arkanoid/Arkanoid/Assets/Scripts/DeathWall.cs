using UnityEngine;

public class DeathWall : MonoBehaviour
{
    GameObject[] balls;
    void Update()
    {
        balls  =GameObject.FindGameObjectsWithTag("Ball");
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent<Ball>(out Ball ball)){  
            if(balls.Length == 1){                
                PlayerHealth.Instance.HeartHit(1);
            }       
            Destroy(ball.gameObject);
        }
    }
}
