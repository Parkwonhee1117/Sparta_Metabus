using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : BaseController
{
    public void Death()
    {
        transform.position = new Vector3(0, 0, 0);
        Debug.Log("죽었습니다.");
        GameManager.IsMiniGameStart = false;
    }
}
