using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class HpBar : MonoBehaviour
{
    public Slider bar;
    public void HpBarUpdate()
    {
        var character = transform.parent.parent.GetComponent<GameActor>();
        Debug.Log("체력이 변경됨");
        bar.value = (float)character.currentHp / character.maxHp;
    }

}
