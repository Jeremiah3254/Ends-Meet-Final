using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L0KnightAbilitiesScript : MonoBehaviour
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

        }else if (index == 1) {

        }else if (index == 2) {
            
        }else if (index == 3) {
            
        }else if (index == 4) {
            
        }else if (index == 5) {
            
        }else if (index == 6) {
            
        }else if (index == 7) {
            
        }else if (index == 8) {
            
        }else if (index == 9) {
            
        }else if (index == 10) {
            TwinSlah(10);
        }else if (index == 11) {
            ThrowSword(11);
        }else if (index == 12) {
            
        }else if (index == 13) {
            
        }else if (index == 14) {
            
        }
    }


    void TwinSlah(int index) {
        GameObject enemyBase = GameObject.Find("MobManagement");
        GameObject currentEnemyReference = enemyBase.GetComponent<WaveManager>().currentZombies[findClosestEnemy()];
        //Debug.Log("errr");
        //Debug.Log(Vector3.Distance(currentEnemyReference.transform.position,StateNameController.playerCharacter.transform.position));
        if ((currentEnemyReference != null) && (Vector3.Distance(currentEnemyReference.transform.position,StateNameController.playerCharacter.transform.position) <= 2)) {// range from ability + 1;
            currentEnemyReference.GetComponent<StatusManager>().health = currentEnemyReference.GetComponent<StatusManager>().health - ((StateNameController.playerCharacter.GetComponent<PlayerMovement>().characterDamage+StateNameController.damageBoost)*2f);
        }
        activeAbilities[index] = false;
    }

    void ThrowSword(int index) {
        GameObject enemyBase = GameObject.Find("MobManagement");
        GameObject currentEnemyReference = enemyBase.GetComponent<WaveManager>().currentZombies[findClosestEnemy()];
        //Debug.Log("errr");
        //Debug.Log(Vector3.Distance(currentEnemyReference.transform.position,StateNameController.playerCharacter.transform.position));
        if ((currentEnemyReference != null) && (Vector3.Distance(currentEnemyReference.transform.position,StateNameController.playerCharacter.transform.position) <= 3)) {// range from ability + 1;
            currentEnemyReference.GetComponent<StatusManager>().health = currentEnemyReference.GetComponent<StatusManager>().health - ((StateNameController.playerCharacter.GetComponent<PlayerMovement>().characterDamage+StateNameController.damageBoost)*1.5f);
        }
        activeAbilities[index] = false;
    }

    int findClosestEnemy() {
        GameObject enemyBase = GameObject.Find("MobManagement");
        int closestEnemy = 0;  
        float closestEnemyPoisiton = float.MaxValue;

        for (int i = 0; i<enemyBase.GetComponent<WaveManager>().currentZombies.Length; i++) {
            if (enemyBase.GetComponent<WaveManager>().currentZombies[i] != null) {
                if (Vector3.Distance(enemyBase.GetComponent<WaveManager>().currentZombies[i].transform.position,StateNameController.playerCharacter.transform.position) < closestEnemyPoisiton) {
                    closestEnemyPoisiton = Vector3.Distance(enemyBase.GetComponent<WaveManager>().currentZombies[i].transform.position,StateNameController.playerCharacter.transform.position);
                    closestEnemy = i;
                }
            }
        }
        return closestEnemy;
    }
}
