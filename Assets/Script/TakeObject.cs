using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeObject : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Iobject>(out Iobject theObject))
        {
            theObject?.OnTouch();
        }
    }
}
