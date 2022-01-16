using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ArmorTooltipTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public string ArmorName;
    public float armor;
    public float lifeRegen;
    public float movementSpeed;


    public void OnPointerEnter(PointerEventData eventData) {
        TooltipSystem.showArmorTooltip(ArmorName,armor,lifeRegen,movementSpeed);
    }

    public void OnPointerExit(PointerEventData eventData) {
       TooltipSystem.hideArmorTooltip();
    }

}
