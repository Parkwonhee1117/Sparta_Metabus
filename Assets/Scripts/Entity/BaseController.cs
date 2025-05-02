using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseController : MonoBehaviour
{
    protected AnimationHandler animationHandler;

    protected virtual void Awake()
    {
        animationHandler = GetComponent<AnimationHandler>();
    }
}
