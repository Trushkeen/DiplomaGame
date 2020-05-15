using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Waypoints : MonoBehaviour
{
    private Image IconImg;
    private Text DistanceText;

    public Transform Player;
    public Transform Target;
    public Camera Camera;

    public float CloseEnoughDist;

    private void Start()
    {
        IconImg = GetComponent<Image>();
        DistanceText = GetComponentInChildren<Text>();
    }

    private void Update()
    {
        if (Target != null) 
        {
            GetDistance();
            CheckOnScreen();
        }
    }

    private void GetDistance() 
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;

        float dist = Vector3.Distance(Player.position, Target.position);
        DistanceText.text = dist.ToString("f1") + "m";

        if (dist < CloseEnoughDist)
        {
            Destroy(gameObject);
        }
    }

    private void CheckOnScreen() 
    {
        float thing = Vector3.Dot((Target.position - Camera.transform.position).normalized, Camera.transform.forward);
        
        if (thing <= 0) 
        {
            TaggleUI(false);
        }
        else 
        {
            TaggleUI(true);
            transform.position = Camera.WorldToScreenPoint(Target.position);
        }
    }

    private void TaggleUI(bool value) 
    {
        IconImg.enabled = value;
        DistanceText.enabled = value;

    }


}
