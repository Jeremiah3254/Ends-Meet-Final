using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponTooltip : MonoBehaviour
{
    public Text weaponName;
    public Text damage;
    public Text range;
    public Text weaponSpeed;
    public Text targets;
    public RectTransform rectTransform;

    private void Awake() {
       rectTransform = GetComponent<RectTransform>();
   }
    public void setTooltipUText(string WeaponName, float Damage, float Range, float WeaponSpeed, string Targets) {
       weaponName.text = WeaponName;
       damage.text = (Damage).ToString();
       range.text = (Range).ToString();
       weaponSpeed.text = (WeaponSpeed).ToString();
       targets.text = Targets;
    }

    private void Update() {
        Vector2 position = Input.mousePosition;//new Vector2(Input.mousePosition.x,Input.mousePosition.y);
        float pivotX = position.x / Screen.width;
        float pivotY = (position.y / Screen.height)-0.25f;
        

        rectTransform.pivot = new Vector2(pivotX,pivotY);
        transform.position = position;
    }

}
