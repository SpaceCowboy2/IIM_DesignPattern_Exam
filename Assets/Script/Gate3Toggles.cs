using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate3Toggles : MonoBehaviour
{
    private int nbtoggles = 0;
    public void IncrementValue()
    {
        Debug.Log("++");
        nbtoggles++;
        CheckIfDestroyable();
    }

    public void DecrementValue()
    {
        Debug.Log("--");
        nbtoggles--;
        
    }

    public void CheckIfDestroyable()
    {
        if (nbtoggles >= 3)
        {
            Debug.Log("destroy");
            Destroy(gameObject);
        }
    }
}
