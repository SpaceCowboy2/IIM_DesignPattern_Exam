using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthSlider : MonoBehaviour
{
    [SerializeField] PlayerEntity player;
    [SerializeField] Slider slider;


    private void Start()
    {
        player.Health.OnUpdateUIHealth += UpdateHealthBar;
    }

    public void UpdateHealthBar()
    {
        slider.maxValue = player.Health.MaxHealth;
        slider.value = player.Health.CurrentHealth;
    }
}
