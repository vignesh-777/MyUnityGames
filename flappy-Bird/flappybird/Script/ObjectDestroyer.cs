
using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{
    [SerializeField] float destroyXLimit;
    void Update()
    {
        if(transform.position.x < destroyXLimit){
            Destroy(gameObject);
        }
    }
}
