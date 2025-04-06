using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float speed;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (transform.parent != null)
        {
        rb.simulated = false;
        rb.velocity = Vector2.zero;
        }
    }
    void Update() {
        rb.velocity = rb.velocity.normalized * speed;
    }
    
    public void shootDirection(Vector2 direction){
        transform.parent = null;
        rb.simulated = true;
        rb.velocity = direction * speed;
    }
}
