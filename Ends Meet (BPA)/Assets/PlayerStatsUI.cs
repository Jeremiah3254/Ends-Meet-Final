using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatsUI : MonoBehaviour
{
   public Text playerStatsText;
   public Text playerLevelText;
   public Slider xpbarSlider;
    void Update() {
        checkForLevelUp();
        playerStatsText.text = "ID:"+StateNameController.username+"\n"+"Rank:"+StateNameController.Rank+"\n"+"XP:"+(StateNameController.XP).ToString()+"\n"+"DNA:"+(StateNameController.DNA).ToString();
        playerLevelText.text = (StateNameController.Level).ToString();
        xpbarSlider.value = calculateXPBar();
    }

   public void openResearchMenu(GameObject menu) {
       if (menu.activeSelf == false) {
           menu.SetActive(true);
       } else {
           menu.SetActive(false);
       }
   }

   float calculateXPBar() {
       return (float)((float)StateNameController.XP/(float)StateNameController.maxXP);
   }

   public void checkForLevelUp() {
       if (StateNameController.XP>=StateNameController.maxXP) {
            int calculationHolder = 0;
            StateNameController.XP = StateNameController.XP - StateNameController.maxXP;
            calculationHolder = ((StateNameController.Level*5)+20);
            StateNameController.maxXP = calculationHolder*StateNameController.Level;
            StateNameController.Level = StateNameController.Level+1;
       }
   }
}
