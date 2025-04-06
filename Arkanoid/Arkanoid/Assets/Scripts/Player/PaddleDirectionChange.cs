using UnityEngine;

public class PaddleDirectionChange : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Ball>(out Ball ball))
        {
            //Get's ball Rigid body2D
            Rigidbody2D ballRgd = ball.GetComponent<Rigidbody2D>();
            if(ballRgd == null)
                return;
            
            //calculate the relative position(ball.x - paddle.x) / paddle.width
            float paddleWidth = GetComponent<BoxCollider2D>().bounds.size.x;
            float relativePosition = (ball.transform.position.x - transform.position.x) / paddleWidth;

            //calculate direction
            float bounceStrength = 5f;
            Vector2 newVelocity = new Vector2(relativePosition * bounceStrength,Mathf.Abs(ballRgd.velocity.y));

            //apply force
            ballRgd.velocity = newVelocity.normalized;

        }
    }
}
