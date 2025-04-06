using UnityEngine;

public class GameOver : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent<BirdScript>(out _)){
            GameOverManger.Instance.TriggerGameOver();
        }
    }
}
