using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerManager))]
[RequireComponent(typeof(InventoryManager))]

public class Managers : MonoBehaviour
{
    public static PlayerManager Player { get; private set; }
    public static InventoryManager Inventory { get; private set; }

    private List<IGameManager> startSequence;

    private void Awake()
    {
        Player = GetComponent<PlayerManager>();
        Inventory = GetComponent<InventoryManager>();

        startSequence = new List<IGameManager>();
        startSequence.Add(Player);
        startSequence.Add(Inventory);

        StartCoroutine(StartupManagers());
    }

    private IEnumerator StartupManagers()
    {
        foreach (IGameManager manager in startSequence)
        {
            manager.Startup();
        }

        yield return null;

        int maxCountManager = startSequence.Count;
        int countReady = 0;

        while (countReady < maxCountManager)
        {
            int lastReady = countReady;
            countReady = 0;

            foreach (IGameManager manager in startSequence)
            {
                if (manager.status == ManagerStatus.Started)
                {
                    countReady++;
                }
            }
            if (countReady > lastReady)
            {
                Debug.Log("Progress: " + countReady + "/" + maxCountManager);
            }
            yield return null;
        }
        Debug.Log("All managers started up");


    }
}
