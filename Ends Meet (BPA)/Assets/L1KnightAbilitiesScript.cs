using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L1KnightAbilitiesScript : MonoBehaviour
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
            IncreaseCharacterWeaponrange(2);
        }else if (index == 3) {
            IncreaseCharacterVision(3);
        }else if (index == 4) {
            IncreaseMovementSpeed(4);
        }else if (index == 5) {
            IncreaseCharacterHealth(5);
        }else if (index == 6) {
            IncreaseCharacterLifeRegen(6);
        }else if (index == 7) {
            IncreaseCharacterManaRegen(7);
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
        StateNameController.damageBoost = StateNameController.damageBoost + 1f;
        activeAbilities[index] = false;
    }

    void IncreaseCharacterAttackSpeed(int index) {
        StateNameController.attackSpeedBoost = StateNameController.attackSpeedBoost + 8f;
        activeAbilities[index] = false;
    }

    void IncreaseCharacterWeaponrange(int index) {
        StateNameController.attackRangeBoost = StateNameController.attackRangeBoost + 0.25f;
        activeAbilities[index] = false;
    }

    void IncreaseCharacterVision(int index) {
        StateNameController.visionBoost = StateNameController.visionBoost + 1.5f;
        activeAbilities[index] = false;
    }

    void IncreaseMovementSpeed(int index) {
        StateNameController.movementSpeedBoost = StateNameController.movementSpeedBoost + 0.5f;
        activeAbilities[index] = false;
    } 

    void IncreaseCharacterHealth(int index) {
        StateNameController.healthBoost = StateNameController.healthBoost + 15f;
        activeAbilities[index] = false;
    } 

    void IncreaseCharacterLifeRegen(int index) {
        StateNameController.healthRegenBoost = StateNameController.healthRegenBoost + 0.35f;
        activeAbilities[index] = false;
    }

    void IncreaseCharacterManaRegen(int index) {
        StateNameController.manaRegenBoost = StateNameController.manaRegenBoost + 0.15f;
        activeAbilities[index] = false;
    }
}
