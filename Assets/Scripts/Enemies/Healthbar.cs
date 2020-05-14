using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    public Image HPImg;
    public Image EffectImg;

    private Mob Stats;
    private float PrevFillAmount;

    void Start()
    {
        Stats = GetComponentInParent<Mob>();
        PrevFillAmount = 1F;
    }

    void Update()
    {
        if (HPImg.fillAmount != 1)
        {
            HPImg.enabled = true;
            EffectImg.enabled = true;
        }
        else
        {
            HPImg.enabled = false;
            EffectImg.enabled = false;
        }
        
        HPImg.fillAmount = Stats.HP / Stats.MaxHP;

        if (PrevFillAmount >= HPImg.fillAmount)
        {
            EffectImg.fillAmount = Mathf.Lerp(0, 1, PrevFillAmount);
            PrevFillAmount -= 0.01F;
        }

        transform.LookAt(Camera.main.transform);
    }
}
