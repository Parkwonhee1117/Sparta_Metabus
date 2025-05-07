using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public static int ProjectileCount = 0;
    public static int Wave = 1;
    public static bool IsMiniGameStart = false;

    private bool _isSpawneProjectiles = false;
    private ProjectileManager projectileManager;
    private StatHandler statHandler;
    private PlayerController playerController;

    void Awake()
    {
        Instance = this;

        projectileManager = GetComponentInChildren<ProjectileManager>();
        statHandler = FindAnyObjectByType<StatHandler>();
        playerController = FindAnyObjectByType<PlayerController>();
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
            _isSpawneProjectiles = false;
            statHandler.Health = 100;
            Wave = 1;
            projectileManager.Speed = 4;
        }
    }

}
