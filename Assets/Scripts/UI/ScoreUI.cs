using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : BaseUI
{
    [SerializeField] private Button _retryButton;
    [SerializeField] private Button _RobbyButton;

    PlayerController playerController;

    public override void Init(UIManager uIManager)
    {
        base.Init(uIManager);

        playerController = FindAnyObjectByType<PlayerController>();

        _retryButton.onClick.AddListener(OnclickRetryButton);
        _RobbyButton.onClick.AddListener(OnclickRobbyButton);
    }

    void OnclickRetryButton()
    {
        GameManager._isSpawneProjectiles = false;
        GameManager.IsMiniGameStart = true;

        uIManager.SetPlayGame();
    }

    void OnclickRobbyButton()
    {
        playerController.transform.position = new Vector3(0, 0, 0);
        uIManager.Lobby();
    }

    protected override UIState GetUIState()
    {
        return UIState.Score;
    }
}
