using UnityEngine;

public class Paddle : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float moveSpeed;
    [SerializeField] Vector2 direction = new Vector2(1,4);
    float hInput;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        hInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(hInput * moveSpeed , 0f);
        
        //checking any child ball is present to shoot
        if(transform.childCount > 0 && Input.GetKeyDown(KeyCode.Space)){
            Ball ball = GetComponentInChildren<Ball>();
            if(ball != null){
                ball.shootDirection(direction);
            }else{
                return;
            }
        }
        
    }
}
