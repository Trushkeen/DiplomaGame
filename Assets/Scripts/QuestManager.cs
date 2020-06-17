using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class QuestManager : MonoBehaviour
{
    public TextMeshProUGUI QuestText;
    public GameObject Walloff;

    public GameObject[] Objectives;
    public int CurrentObjective = 0;
    public string LocalePrefix = "lvl1_";
    private GameObject[] Spawners;

    #region Singleton
    public static QuestManager Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            print("Several instances of quest managers found");
            return;
        }
        Instance = this;
    }
    #endregion

    private void Start()
    {
        Spawners = GameObject.FindGameObjectsWithTag("SpawnMob");
        
        Waypoints.Instance.UpdateWaypoint(Objectives[CurrentObjective].transform);
        QuestText.text = Locale.Get(LocalePrefix + CurrentObjective.ToString());
    }

    public void UpdateObjective()
    {
        CurrentObjective++;
        if (CurrentObjective < Objectives.Length)
        {
            Waypoints.Instance.enabled = true;
            Waypoints.Instance.UpdateWaypoint(Objectives[CurrentObjective].transform);
            QuestText.text = Locale.Get(LocalePrefix + CurrentObjective.ToString());

            switch (CurrentObjective)
            {
                case 3:
                    Destroy(Walloff);
                break;

                case 6:
                    foreach (GameObject gameObject in Spawners) 
                    {
                        gameObject.SetActive(true);
                    }
                break;
            }
        }
        else
        {
            Waypoints.Instance.enabled = false;
        }
    }
}
