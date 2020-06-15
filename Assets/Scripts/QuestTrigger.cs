using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestTrigger : MonoBehaviour
{
    [Header("Voiceover")]
    public bool HasVOClip = false;
    [Header("No need to set source, it finds itself")]
    public AudioSource VOSource;
    public AudioClip VOClip;
    public float WaypointDelaySeconds;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayVOClip();
            QuestManager.Instance.UpdateObjective();
            Destroy(gameObject);
        }

    }

    private void Start()
    {
        VOSource = GameObject.FindGameObjectWithTag("VOPlayer").GetComponent<AudioSource>();
    }

    public void PlayVOClip()
    {
        if (VOClip != null)
        {
            VOSource.clip = VOClip;
            VOSource.Play();
            if (WaypointDelaySeconds == 0)
                DelayWaypoint(VOClip.length);
            else
                DelayWaypoint(WaypointDelaySeconds);
        }
        else
        {
            print("Set voiceover clip to trigger: " + gameObject.name);
        }
    }

    private IEnumerator DelayWaypoint(float length)
    {
        Waypoints.Instance.CloseEnoughDist = 100000F;
        yield return new WaitForSeconds(length);
        Waypoints.Instance.CloseEnoughDist = 100F;
    }
}
