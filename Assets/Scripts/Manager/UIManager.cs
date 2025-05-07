using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public enum UIState
{
    Game,
    Score,
    Lobby
}
public class UIManager : MonoBehaviour
{
    GameUI gameUI;
    ScoreUI scoreUI;
    UIState currentState;

    void Awake()
    {
        gameUI = GetComponentInChildren<GameUI>(true);
        gameUI.Init(this);
        scoreUI = GetComponentInChildren<ScoreUI>(true);
        scoreUI.Init(this);
        
    }
    public void ChangePlayerHP(float currentHP, float maxHP)
    {
        gameUI.UpdateHPSlider(currentHP/ maxHP);
    }

    public void SetPlayGame()
    {
        ChangeState(UIState.Game);
        gameUI.ShowWave(GameManager.Wave);
    }

    public void GameOver()
    {
        ChangeState(UIState.Score);
        scoreUI.UpdateWave(GameManager.Wave);
    }

    public void Lobby()
    {
        ChangeState(UIState.Lobby);
    }

    public void ChangeState(UIState state)
    {
        currentState = state;
        gameUI.SetActive(currentState);
        scoreUI.SetActive(currentState);
    }
}
