using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : BaseUI
{
    [SerializeField] public Slider HpSlider;

    void Start()
    {
        UpdateHPSlider(1);
    }

    public void UpdateHPSlider(float percentage)
    {
        HpSlider.value = percentage;
    }

    protected override UIState GetUIState()
    {
        return UIState.Game;
    }
}