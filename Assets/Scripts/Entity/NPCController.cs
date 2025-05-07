using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    PlayerController playerController;
    bool _isPlayerInTrigger = false;

    void Awake()
    {
        playerController = FindAnyObjectByType<PlayerController>();
    }

    void Update()
    {
        if (_isPlayerInTrigger && Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("게임을 시작합니다.");
            playerController.transform.position = new Vector3(40, 0, 0);
            GameManager.IsMiniGameStart = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("화살 피하기 게임을 시작하겠습니까? (상호작용 F)");
            _isPlayerInTrigger = true;
        }

    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _isPlayerInTrigger = false;
        }
    }
}
