using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : BaseUI
{
    [SerializeField] private Slider _hpSlider;
    [SerializeField] private TextMeshProUGUI _wave;

    void Start()
    {
        UpdateHPSlider(1);
    }

    public void ShowWave(int wave)
    {
        _wave.text = wave.ToString();
    }

    public void UpdateHPSlider(float percentage)
    {
        _hpSlider.value = percentage;
    }

    protected override UIState GetUIState()
    {
        return UIState.Game;
    }
}