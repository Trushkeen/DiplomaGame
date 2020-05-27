using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class QuestManager : MonoBehaviour
{
    public TextMeshProUGUI QuestText;

    private List<GameObject> QuestObjects = new List<GameObject>();
    private List<GameObject> SortedQuestObjects = new List<GameObject>();
    private GameObject TargetLoot;
    private GameObject EscapePoint;

    void Start()
    {
        QuestObjects.AddRange(GameObject.FindGameObjectsWithTag("QuestLoot"));
        Lvl1Scenario();
    }

    void Update()
    {
        if (TargetLoot != null)
        {
            if (!Locale.LocaleLoaded)
            {
                Locale.LoadLocale();
            }
            QuestText.text = Locale.Get("find") + TargetLoot.GetComponent<LootableItem>().Loot.Name;
            Waypoints.Instance.UpdateWaypoint(TargetLoot.transform);
        }
        else
        {
            if (SortedQuestObjects.Count > 0)
            {
                SortedQuestObjects.RemoveAt(0);
                TargetLoot = SortedQuestObjects[0];
            }
        }
        //if script causes exception, we need to add a escape point and adapt script for it
    }

    private void Lvl1Scenario()
    {
        foreach (var item in QuestObjects)
        {
            var loot = item.GetComponent<LootableItem>().Loot;
            if (loot.Name == "PDA")
            {
                SortedQuestObjects.Add(item);
                SortedQuestObjects.AddRange(QuestObjects);
                TargetLoot = item;
            }
        }
    }
}
