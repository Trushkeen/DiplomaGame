using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersManager : MonoBehaviour
{
    private static PlayersManager Instance = null;

    public List<PlayerStats> Players;

    private PlayersManager() { }

    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if(Instance == this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    public static PlayersManager GetInstance() => Instance;

    public int GetAvailableID()
    {
        int id = Random.Range(0, 1000);
        foreach (var i in Players)
        {
            if(i.ID == id)
            {
                GetAvailableID();
            }
        }
        return id;
    }
}
