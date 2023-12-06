using System;
using UnityEngine;

public class EventBus : MonoBehaviour
{
    public static EventBus Instance;
    void Awake()
    {
        Instance = this;
    }

    public Action OnGameStarted;
    public Action<float> OnPlayerDamaged;
    public Action OnGameWin;
    public Action OnGameLoose;
}
