using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class WeaponTooltipTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public string weaponName;
    public float damage;
    public float range;
    public float attackSpeed;
    public string targets;


    public void OnPointerEnter(PointerEventData eventData) {
        TooltipSystem.showWeaponTooltip(weaponName,damage,range,attackSpeed,targets);
    }

    public void OnPointerExit(PointerEventData eventData) {
       TooltipSystem.hideWeaponTooltip();
    }
}

