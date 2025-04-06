using UnityEngine;

public class ScoreObject : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] AudioClip pointAudio;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent<BirdScript>(out _)){
            ScoreManager.Instance.AddScore(1);
            audioSource.PlayOneShot(pointAudio);
        }
    }
}
