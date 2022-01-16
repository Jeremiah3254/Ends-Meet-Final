using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArmorTooltip : MonoBehaviour
{
    public Text armorName;
    public Text armor;
    public Text lifeRegen;
    public Text movementSpeed;
    public RectTransform rectTransform;

    private void Awake() {
       rectTransform = GetComponent<RectTransform>();
   }
    public void setTooltipUText(string ArmorName, float Armor,float LifeRegen, float MovementSpeed) {
       armorName.text = ArmorName;
       armor.text = (Armor).ToString();
       lifeRegen.text = (LifeRegen).ToString();
       movementSpeed.text = (MovementSpeed).ToString();
    }

    private void Update() {
        Vector2 position = Input.mousePosition;//new Vector2(Input.mousePosition.x,Input.mousePosition.y);
        float pivotX = position.x / Screen.width;
        float pivotY = (position.y / Screen.height)-0.25f;
        

        rectTransform.pivot = new Vector2(pivotX,pivotY);
        transform.position = position;
    }
}
