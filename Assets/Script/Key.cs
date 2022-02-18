using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour, Iobject
{
    [SerializeField] GameObject wall = null;
    [SerializeField] GameObject key = null;

    public void OnTouch()
    {
        Destroy(key);
        Destroy(wall);
    }
}
