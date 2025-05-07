using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public static int ProjectileCount = 0;
    public static int Wave = 1;
    public static bool IsMiniGameStart = false;
    public static bool _isSpawneProjectiles = false;
    
    private ProjectileManager projectileManager;
    private StatHandler statHandler;
    private PlayerController playerController;
    private UIManager uiManager;
    private ScoreUI scoreUI;

    void Awake()
    {
        Instance = this;

        projectileManager = GetComponentInChildren<ProjectileManager>();
        statHandler = FindAnyObjectByType<StatHandler>();
        playerController = FindAnyObjectByType<PlayerController>();
        uiManager = FindAnyObjectByType<UIManager>();
    }

    void Update()
    {
        if (IsMiniGameStart && !(_isSpawneProjectiles))
        {
            projectileManager.ArrowSpawn();
            _isSpawneProjectiles = true;
        }

        if (statHandler.Health <= 0)
        {
            playerController.Death();
            uiManager.GameOver();
            _isSpawneProjectiles = false;
            statHandler.Health = 100;
            Wave = 0;
            projectileManager.Speed = 4;
            uiManager.ChangePlayerHP(statHandler.Health, 100);
        }
    }

}
