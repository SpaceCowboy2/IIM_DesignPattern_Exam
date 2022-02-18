using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour, Iobject
{
    PlayerEntity player;
    [SerializeField] int healValue;

    private void Awake()
    {
        player = FindObjectOfType<PlayerEntity>();
    }
    public void OnTouch()
    {
        
        // When we collide with a potion, we heal the player by "healValue"
        player.Health.Heal(healValue);
        Destroy(this.transform.parent.gameObject);

    }
}
