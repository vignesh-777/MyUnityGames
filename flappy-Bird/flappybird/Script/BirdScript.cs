using UnityEngine;
[RequireComponent(typeof(Rigidbody2D),typeof(Animator))]
public class BirdScript : MonoBehaviour
{
    [Header("Bird-Inputs")]
   [SerializeField] float jumpForce;
   [SerializeField] KeyCode jumpButtonKey = KeyCode.Space;
   [SerializeField] KeyCode jumpMouseKey = KeyCode.Mouse0;
   [Header("Audio")]
   [SerializeField] AudioClip flyAudio;
   [SerializeField] AudioClip deiAudio;

    //Components
    Rigidbody2D rb;
    Animator ani;
    AudioSource audioSource;
    bool isJumping;

    void Start()
    {
        //grabbing rigid body
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
        //grabbing animator
        ani = GetComponent<Animator>();
        //grabbing audio source
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        //Handle Game Over
        if(GameOverManger.Instance != null && GameOverManger.Instance.IsGameOvered()){
            audioSource.PlayOneShot(deiAudio);
            return;
        }
        //Animation
        FlappyBirdAnimation();

        //flying
        HandleInput();
        
    }
    void HandleInput(){
        //For System Inputs
        if(Input.GetKeyDown(jumpButtonKey) || Input.GetKeyDown(jumpMouseKey)){
            jump();
            
        }
        //For Mobile Inputs
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began){
            jump();
        }
        isJumping = rb.velocity.y < 0.1f;
    }

    void jump(){
        rb.velocity = Vector2.up * jumpForce;
        if(audioSource != null && flyAudio != null){
            audioSource.PlayOneShot(flyAudio);
        }
    }
    void FlappyBirdAnimation(){
        ani.SetBool("Fly",isJumping);
        ani.SetBool("Fall",!isJumping);
    }
    

}
