using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Waypoints : MonoBehaviour
{
    public Image IconImg;
    public bool Visible = true;

    public Transform Player;
    public Transform Target;
    public Camera Camera;

    public float CloseEnoughDist;

    #region Singleton
    public static Waypoints Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            print("Several instances of waypoints found");
            return;
        }
        Instance = this;
    }
    #endregion

    private void Update()
    {
        if (Target != null)
        {
            CheckOnScreen();
            UpdDistance();
        }
    }

    public void UpdateWaypoint(Transform target)
    {
        Target = target;
    }

    private void UpdDistance()
    {
        if (Vector3.Distance(Player.position, Target.position) < CloseEnoughDist)
        {
            IconImg.enabled = false;
        }
    }

    private void GetDistance()
    {
        float dist = Vector3.Distance(Player.position, Target.position);

        if (dist < CloseEnoughDist)
        {
            IconImg.enabled = false;
        }
    }

    private void CheckOnScreen()
    {
        float thing = Vector3.Dot((Target.position - Camera.transform.position).normalized, Camera.transform.forward);

        if (thing <= 0)
        {
            ToggleUI(false);
        }
        else
        {
            ToggleUI(true);
            transform.position = Camera.WorldToScreenPoint(Target.position);
        }
    }

    private void ToggleUI(bool value)
    {
        IconImg.enabled = value;
        //DistanceText.enabled = value;

    }


}
