using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MyToggle : MonoBehaviour, ITouchable
{
    // Je veux ouvrir un �v�nement pour les designers pour qu'ils puissent set la couleur du sprite eux m�me
    [SerializeField] UnityEvent _onToggleOn;
    [SerializeField] UnityEvent _onToggleOff;
    [SerializeField] SpriteRenderer sprite;

    public bool IsActive { get; private set; }

    public void Touch(int power)
    {
        IsActive = !IsActive;

        // Debug
        if(IsActive)
        {
            Debug.Log("invoke on");
            _onToggleOn?.Invoke();
            sprite.color = Color.green;
        }
        else
        {
            Debug.Log("invoke off");
            _onToggleOff?.Invoke();
            sprite.color = Color.red;
        }
    }
}
