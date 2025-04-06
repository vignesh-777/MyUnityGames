
using UnityEngine;

public class PlatFromMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    void Update()
    {
        //Handle Game Over
        if(GameOverManger.Instance != null && GameOverManger.Instance.IsGameOvered()){
            return;
        }
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
    }
}
