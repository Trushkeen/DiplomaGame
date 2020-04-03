using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static WeaponBase[] DisabledWeapons;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void DisableActiveWeapons()
    {
        DisabledWeapons = GameObject.FindObjectsOfType<WeaponBase>();
        foreach (var w in DisabledWeapons)
        {
            w.gameObject.SetActive(false);
        }
    }

    public static void EnableDisabledWeapons()
    {
        if (DisabledWeapons != null)
        {
            foreach (var w in DisabledWeapons)
            {
                w.gameObject.SetActive(true);
            }
            DisabledWeapons = null;
        }
        else
        {
            Debug.LogWarning("EnableDisabledWeapons did not run because DisabledWeapons is null, run DisableActiveWeapons first");
        }
    }
}
