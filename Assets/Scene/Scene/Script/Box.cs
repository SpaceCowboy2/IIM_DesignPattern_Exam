using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour, ITouchable
{
    public bool isDestroyable = true;
    [SerializeField] GameObject potionGo = null;
    public void Touch(int power)
    {
        // Wall security
        if(isDestroyable)
        {
            Destroy(gameObject);
            int randomNumber = Random.Range(0,3);

            if(randomNumber == 0)
            {
                Instantiate(potionGo,gameObject.transform.position,Quaternion.identity);
            }
        }
    }
}
