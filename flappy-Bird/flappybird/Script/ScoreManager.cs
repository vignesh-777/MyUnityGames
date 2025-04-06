
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    int score;
    [Header("Image Reference")]
    [SerializeField] Sprite[] digitSprite;
    [SerializeField] GameObject digitImagePrefab;
    [SerializeField] Transform digitParent;
    void Awake()
    {
        if(Instance != null && Instance!=this){
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
    public void AddScore(int value){
        score += value;
        updateUiScore();
    }
    void updateUiScore(){
        //Clear previous child
        foreach(Transform child in digitParent){
            Destroy(child.gameObject);
        }   

        if(score == 0){
            CreateDigitImage(0);
            return;
        }
        foreach (char currentScore in score.ToString()){
            int returnScore = currentScore - '0';
            CreateDigitImage(returnScore);
            
        }
    }
    void CreateDigitImage(int imageIndex){
        //instantiate the image 
        GameObject digitGo = Instantiate(digitImagePrefab,digitParent);
        //grabbing  the image component from create object
        Image digitImage = digitGo.GetComponent<Image>();

        //change the sprite based on the score
        if(digitImage != null && score >= 0 && imageIndex < digitSprite.Length){
            digitImage.sprite  =  digitSprite[imageIndex];
        }else{
            Debug.LogWarning($"digit{imageIndex} is out of range");
        }
    }
    public int GetScore(){
        return score;
    }
}
