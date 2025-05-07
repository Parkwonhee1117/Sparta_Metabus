using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : BaseController
{
    public void Death()
    {
        Debug.Log("죽었습니다.");
        GameManager.IsMiniGameStart = false;
    }
}
