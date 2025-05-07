using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatHandler : MonoBehaviour
{
    [Range(1, 100)][SerializeField] private int _hp = 100;
    [Range(1, 10)][SerializeField] private int _speed = 5;

    public int Health
    {
        get => _hp;
        set => _hp = Mathf.Clamp(value, 0, 100);
    }

    public int Speed
    {
        get => _speed;
        set => _speed = Mathf.Clamp(value, 0, 10);
    }
}
