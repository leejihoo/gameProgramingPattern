using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class StaminaBar : MonoBehaviour
{
    public Slider bar;

    public void StaminaBarUpdate()
    {
        var character = transform.parent.parent.GetComponent<GameActor>();
        Debug.Log("스태미나가 변경됨");
        bar.value = (float)character.currentStamina / character.maxStamina;
    }
}
