using System;
using UnityEngine.Events;

public class GlobalEventManager
{
    public static UnityEvent OnEnemyKilled = new UnityEvent();
    public static UnityEvent<float> OnSpeedChanged = new UnityEvent<float>();
    public static void SendEnemyKilled()
    {
        OnEnemyKilled.Invoke();
    }
    public static void SendSpeedChanged(float value)
    {
        OnSpeedChanged.Invoke(value);
    }
}
