using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[HelpURL("https://docs.google.com/spreadsheets/d/1knAsXaUlot1VMU7SI1vdu7wnUkQrw_rbwXQ73LraDBQ/edit?usp=sharing")]
public class CommandCardDisplay : MonoBehaviour
{
    [Header("don't touch")]
    public GameObject[] abilityButtons;
    public Button[] buttonManagement;
    public Image[] abilityBackgrounds;
    public Image[] abilityIcons;
    [Header("These can be updated")]

    public Sprite[] ccIcons;

    //public CardTemplate[] commandCardsOriginal;
    public CardTemplate[] commandCards;
    public int currentLayer = 0; 

    bool cooldownChecking = false;
    Coroutine cooldownActive;
    public GameObject abilityFunctionalityHolder;

    // [0]-No Object  [1]-UpgradeButton  [2]-AbilityButton  [3]-PassiveIcon  [4]-LayerButton


    void Awake() {
      //commandCards = new CommandCard[commandCardsOriginal.Length];
        for (int i = 0; i<commandCards[StateNameController.characterSelected].commandCardsOriginal.Length; i++) {
            commandCards[StateNameController.characterSelected].commandCards[i] = Instantiate(commandCards[StateNameController.characterSelected].commandCardsOriginal[i]);
        }
        
        buttonManagement[0].onClick.AddListener(() => buttonClickedController(0));
        buttonManagement[1].onClick.AddListener(() => buttonClickedController(1));
        buttonManagement[2].onClick.AddListener(() => buttonClickedController(2));
        buttonManagement[3].onClick.AddListener(() => buttonClickedController(3));
        buttonManagement[4].onClick.AddListener(() => buttonClickedController(4));
        buttonManagement[5].onClick.AddListener(() => buttonClickedController(5));
        buttonManagement[6].onClick.AddListener(() => buttonClickedController(6));
        buttonManagement[7].onClick.AddListener(() => buttonClickedController(7));
        buttonManagement[8].onClick.AddListener(() => buttonClickedController(8));
        buttonManagement[9].onClick.AddListener(() => buttonClickedController(9));
        buttonManagement[10].onClick.AddListener(() => buttonClickedController(10));
        buttonManagement[11].onClick.AddListener(() => buttonClickedController(11));
        buttonManagement[12].onClick.AddListener(() => buttonClickedController(12));
        buttonManagement[13].onClick.AddListener(() => buttonClickedController(13));
        buttonManagement[14].onClick.AddListener(() => buttonClickedController(14));
        //buttonManagement[15].onClick.AddListener(() => buttonClickedController(15));
        /*for (int q = 0; q<buttonManagement.Length; q++) {
            buttonManagement[q].onClick.AddListener(() => buttonClickedController(q));
        }*/
    }

    void Update() {
        updateCCDisplay();
        setAbilityCooldown();
        if (cooldownChecking == false) {
            cooldownActive = StartCoroutine(abilityCooldown());
        }
    }

    void buttonClickedController(int buttonID) {
        //Debug.Log("Test "+buttonID);
        if (commandCards[StateNameController.characterSelected].commandCards[currentLayer].commandCardType[buttonID] != 0 || commandCards[StateNameController.characterSelected].commandCards[currentLayer].commandCardType[buttonID] != 3) {
            if (commandCards[StateNameController.characterSelected].commandCards[currentLayer].commandCardType[buttonID] == 4) {
                currentLayer = commandCards[StateNameController.characterSelected].commandCards[currentLayer].effectLayer[buttonID];
            } else if (commandCards[StateNameController.characterSelected].commandCards[currentLayer].commandCardType[buttonID] == 1 && commandCards[StateNameController.characterSelected].commandCards[currentLayer].currentCD[buttonID] == commandCards[StateNameController.characterSelected].commandCards[currentLayer].maxCD[buttonID]) {
                if (StateNameController.blood >= commandCards[StateNameController.characterSelected].commandCards[currentLayer].ccCosts[buttonID] && commandCards[StateNameController.characterSelected].commandCards[currentLayer].currentUpgrade[buttonID] < commandCards[StateNameController.characterSelected].commandCards[currentLayer].maxUpgrade[buttonID]) {
                    StateNameController.blood = StateNameController.blood - commandCards[StateNameController.characterSelected].commandCards[currentLayer].ccCosts[buttonID];
                    commandCards[StateNameController.characterSelected].commandCards[currentLayer].currentCD[buttonID] = 0f;
                    findScript(StateNameController.characterSelected,currentLayer,buttonID);
                    commandCards[StateNameController.characterSelected].commandCards[currentLayer].currentUpgrade[buttonID] += 1;
                }

            }else if (commandCards[StateNameController.characterSelected].commandCards[currentLayer].commandCardType[buttonID] == 2 && commandCards[StateNameController.characterSelected].commandCards[currentLayer].currentCD[buttonID] >= commandCards[StateNameController.characterSelected].commandCards[currentLayer].maxCD[buttonID] && StateNameController.playerCharacter.GetComponent<StatusManager>().mana >= commandCards[StateNameController.characterSelected].commandCards[currentLayer].ccCosts[buttonID]) {
                if (checkIfExecutable(buttonID)) {
                    commandCards[StateNameController.characterSelected].commandCards[currentLayer].currentCD[buttonID] = 0f;
                    StateNameController.playerCharacter.GetComponent<StatusManager>().mana = StateNameController.playerCharacter.GetComponent<StatusManager>().mana - commandCards[StateNameController.characterSelected].commandCards[currentLayer].ccCosts[buttonID];
                    findScript(StateNameController.characterSelected,currentLayer,buttonID);
                }
                //findScript(StateNameController.characterSelected,currentLayer,buttonID);
            }
        }
    }
    public void updateCCDisplay() {
        //Debug.Log(StateNameController.characterSelected);
        for (int i = 0; i<commandCards[StateNameController.characterSelected].commandCards[currentLayer].commandCardType.Length; i++) {
            if (commandCards[StateNameController.characterSelected].commandCards[currentLayer].commandCardType[i] != 0) {
                //Debug.Log(commandCards[StateNameController.characterSelected].commandCards[currentLayer].commandCardImageID[i]);
                abilityBackgrounds[i].sprite = ccIcons[commandCards[StateNameController.characterSelected].commandCards[currentLayer].commandCardImageID[i]];
                abilityIcons[i].sprite = ccIcons[commandCards[StateNameController.characterSelected].commandCards[currentLayer].commandCardImageID[i]];
                abilityButtons[i].GetComponent<TooltipTrigger>().uName = commandCards[StateNameController.characterSelected].commandCards[currentLayer].ccName[i];
                abilityButtons[i].GetComponent<TooltipTrigger>().uDescription = commandCards[StateNameController.characterSelected].commandCards[currentLayer].ccDescription[i];
                abilityButtons[i].GetComponent<TooltipTrigger>().uCost = commandCards[StateNameController.characterSelected].commandCards[currentLayer].ccCosts[i];
                abilityButtons[i].GetComponent<TooltipTrigger>().empty = false;
                abilityButtons[i].GetComponent<TooltipTrigger>().minUPG = commandCards[StateNameController.characterSelected].commandCards[currentLayer].currentUpgrade[i];
                abilityButtons[i].GetComponent<TooltipTrigger>().maxUPG = commandCards[StateNameController.characterSelected].commandCards[currentLayer].maxUpgrade[i];
                abilityButtons[i].GetComponent<TooltipTrigger>().abilityType = commandCards[StateNameController.characterSelected].commandCards[currentLayer].commandCardType[i];
                abilityButtons[i].GetComponent<TooltipTrigger>().abilityRange = commandCards[StateNameController.characterSelected].commandCards[currentLayer].abilityRange[i];
                //Debug.Log("kindaWorked??");
            } else {
                resetVariables(i);
            }
        }
    }

    public void resetVariables(int indexID) {
        abilityBackgrounds[indexID].sprite = ccIcons[0];
        abilityIcons[indexID].sprite = ccIcons[0];
        abilityButtons[indexID].GetComponent<TooltipTrigger>().uName = "";
        abilityButtons[indexID].GetComponent<TooltipTrigger>().uDescription = "";
        abilityButtons[indexID].GetComponent<TooltipTrigger>().uCost = 0;
        abilityButtons[indexID].GetComponent<TooltipTrigger>().empty = true;
        abilityButtons[indexID].GetComponent<TooltipTrigger>().abilityType = 0;
    }

    public void setAbilityCooldown() {
        for (int i = 0; i<commandCards[StateNameController.characterSelected].commandCards[currentLayer].commandCardType.Length; i++) {
            abilityIcons[i].fillAmount = (commandCards[StateNameController.characterSelected].commandCards[currentLayer].currentCD[i]/commandCards[StateNameController.characterSelected].commandCards[currentLayer].maxCD[i]);
            //Debug.Log(commandCards[StateNameController.characterSelected].commandCards[currentLayer].currentCD[i]+"/"+commandCards[StateNameController.characterSelected].commandCards[currentLayer].maxCD[i]);
        }
    }

    IEnumerator abilityCooldown() {
        cooldownChecking = true;
        yield return new WaitForSeconds(1);
        for (int q = 0; q<commandCards[StateNameController.characterSelected].commandCards.Length; q++) {
            for (int i = 0; i<commandCards[StateNameController.characterSelected].commandCards[q].commandCardType.Length; i++) {
                if ((commandCards[StateNameController.characterSelected].commandCards[q].maxCD[i] != 0 && commandCards[StateNameController.characterSelected].commandCards[q].maxCD[i] > commandCards[StateNameController.characterSelected].commandCards[q].currentCD[i])) {
                    commandCards[StateNameController.characterSelected].commandCards[q].currentCD[i] += 1;
                }
            }
        }
        cooldownChecking = false;
    }

    public void findScript(int character,int layer,int buttonID) {
        Debug.Log("Character: "+character+" Layer: "+layer+" ButtonID: "+buttonID);
        if (character == 0) {
            if (layer == 0) {
                abilityFunctionalityHolder.GetComponent<L0PeasantAbiltiesScript>().activeAbilities[buttonID] = true;
            }else if (layer == 1) {
                abilityFunctionalityHolder.GetComponent<L1PeasantAbilitiesScript>().activeAbilities[buttonID] = true;
            }
        }else if (character == 1) {
            if (layer == 0) {
                abilityFunctionalityHolder.GetComponent<L0KnightAbilitiesScript>().activeAbilities[buttonID] = true;
            }else if (layer == 1) {
                abilityFunctionalityHolder.GetComponent<L1KnightAbilitiesScript>().activeAbilities[buttonID] = true;
            }
        } else if (character == 2) {

        }

    }



    bool checkIfExecutable(int index) {
        GameObject enemyBase = GameObject.Find("MobManagement");
        GameObject currentEnemyReference = enemyBase.GetComponent<WaveManager>().currentZombies[findClosestEnemy()];
        //Debug.Log("errr");
        //Debug.Log(Vector3.Distance(currentEnemyReference.transform.position,StateNameController.playerCharacter.transform.position));
        if ((currentEnemyReference != null) && (Vector3.Distance(currentEnemyReference.transform.position,StateNameController.playerCharacter.transform.position) <= commandCards[StateNameController.characterSelected].commandCards[currentLayer].abilityRange[index]+1f)) {
            return true;
        }
        return false;
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
