
using UnityEngine;

public class SpawnPowers : MonoBehaviour
{
    [SerializeField] GameObject[] powers;
    [SerializeField]float powerUpChance = 0.3f;

    public void PowerUpSpawner(Vector2 pos){
        float rool = Random.value;
        if(rool <= powerUpChance){
            int powerIndex = Random.Range(0,powers.Length);
            Instantiate(powers[powerIndex],pos,Quaternion.identity);
        }
    }

}
