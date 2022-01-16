using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L1PeasantAbilitiesScript : MonoBehaviour
{
    public bool[] activeAbilities = new bool[15];
    void Update()
    {
        for (int i = 0; i<activeAbilities.Length; i++) {
            if (activeAbilities[i] == true) {
                AbilityChecker(i);
            }
        }

    }

    void AbilityChecker(int index) {
        if (index == 0) {
            IncreaseCharacterDamage(0);
        }else if (index == 1) {
            IncreaseCharacterAttackSpeed(1);
        }else if (index == 2) {
            IncreaseCharacterHealth(2);
        }else if (index == 3) {
            IncreaseCharacterLifeRegen(3);
        }else if (index == 4) {
            IncreaseCharacterVision(4);
        }else if (index == 5) {
            
        }else if (index == 6) {
            
        }else if (index == 7) {
            
        }else if (index == 8) {
            
        }else if (index == 9) {
            
        }else if (index == 10) {
            
        }else if (index == 11) {
            
        }else if (index == 12) {
            
        }else if (index == 13) {
            
        }else if (index == 14) {
            
        }
    }

    void IncreaseCharacterDamage(int index) {
        StateNameController.damageBoost = StateNameController.damageBoost + 0.5f;
        activeAbilities[index] = false;
    }

    void IncreaseCharacterAttackSpeed(int index) {
        StateNameController.attackSpeedBoost = StateNameController.attackSpeedBoost + 5f;
        activeAbilities[index] = false;
    }

    void IncreaseCharacterHealth(int index) {
        StateNameController.healthBoost = StateNameController.healthBoost + 10f;
        activeAbilities[index] = false;
    } 

    void IncreaseCharacterLifeRegen(int index) {
        StateNameController.healthRegenBoost = StateNameController.healthRegenBoost + 0.25f;
        activeAbilities[index] = false;
    }

    void IncreaseCharacterVision(int index) {
        StateNameController.visionBoost = StateNameController.visionBoost + 1f;
        activeAbilities[index] = false;
    }

}