
using System.Collections;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField] GameObject ballPrefab;
    GameObject[] ball;
    private float originalPaddleSize;

    void Start()
    {
        ball = GameObject.FindGameObjectsWithTag("Ball"); //getting the ball present in scene
        originalPaddleSize = transform.localScale.x;
    }
    enum PowerState{
        DoubleIt,BallSizeUp,UltraPower,PaddleSizeUp,LifeGain
    }
    private PowerState powerState;
    
    
    void HandlePower(PowerState state){
        //Refresh all time calls
         ball = GameObject.FindGameObjectsWithTag("Ball");
        switch(state){

            //doubling the in screen for presented balls 
            case PowerState.DoubleIt:
                foreach(GameObject balls in ball){                    
                    GameObject go = Instantiate(ballPrefab,balls.transform.position,Quaternion.identity);

                }
                break;

            //Increasing the Ball size by 2
            case PowerState.BallSizeUp:
                foreach(GameObject balls in ball){                    
                    balls.transform.localScale *= 1.5f;
                }
                break;

            
            case PowerState.UltraPower:
                //perform
                break;

            //Increasing the Paddle size by 2 on x-axis
            case PowerState.PaddleSizeUp:
                transform.localScale = 
                new Vector3(transform.localScale.x * 1.5f,
                            transform.localScale.y,
                            transform.localScale.z);
                StartCoroutine(changeToOriginalState()); // power only for few min
                break;

            //Increases the life
            case PowerState.LifeGain:
                PlayerHealth.Instance.HeartHit(-1); // by Sending negative value  health get increases
                break;

        }
    }

    IEnumerator changeToOriginalState(){
        yield return new WaitForSeconds(8f);
        if(transform.localScale.x > originalPaddleSize){
            transform.localScale = new Vector3(originalPaddleSize,transform.localScale.y,transform.localScale.z);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(System.Enum.TryParse(collision.tag, out PowerState power)){
            HandlePower(power);
            Destroy(collision.gameObject);
        }
    }

}
