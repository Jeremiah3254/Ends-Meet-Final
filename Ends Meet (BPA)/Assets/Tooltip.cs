using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//[ExecuteInEditMode()]
public class Tooltip : MonoBehaviour
{
   public Text uName;
   public Text uDescription;
   public Text uCostText;
   public Text uUPGAmount;
   public int abilityType;
   public int uCost;
   //public bool empty;

   public RectTransform rectTransform;

   private void Awake() {
       rectTransform = GetComponent<RectTransform>();
   }
    public void setTooltipUText(string description,string upgradeName,int cost,int minUPG,int maxUPG) {
       uName.text = upgradeName;
       uDescription.text = description;
       uCostText.text = cost.ToString();
       if (minUPG == maxUPG && maxUPG != 0) {
            uUPGAmount.text = "Max";
       } else {
           uUPGAmount.text = minUPG.ToString()+"/"+maxUPG.ToString();
       }
    }

    private void Update() {
        Vector2 position = Input.mousePosition;//new Vector2(Input.mousePosition.x,Input.mousePosition.y);
        float pivotX = position.x / Screen.width;
        float pivotY = (position.y / Screen.height)-0.25f;
        

        rectTransform.pivot = new Vector2(pivotX,pivotY);
        transform.position = position;
    }

}
 