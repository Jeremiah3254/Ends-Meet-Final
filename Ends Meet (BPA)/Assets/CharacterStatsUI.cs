using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterStatsUI : MonoBehaviour
{
    public int basecharacterPrice;
    public float additiveBoostPrice;

    [Header("Character Statistics Stuff")]
    public GameObject[] characters;
    public Text playerKillsDisplay;
    public Text killAmountDisplayBaseRequirement;

    public Text characterName;
    public Text characterDescription;
    public Image weaponImageIcon;
    public Image ArmorImageIcon;

    public Text resourceDisplayText;

    [Header("Healthbar Stuff")]
    public GameObject healthBarUI;
    public Slider healthBar;
    public Text healthBarDisplayText;

    [Header("Energyhbar Stuff")]
    public GameObject energyBarUI;
    public Slider energyBar;
    public Text energyBarDisplayText;

    [Header("Image Storing")]

    public string[] characterNames;

    [TextArea]
    public string[] characterDescriptionsText;
    public Sprite[] WeaponImageIcons;
    public Sprite[] ArmorImageIcons;

    int characterIndexNum;

    [Header("Character Stats Boost Stuff")]
    public Text characterNameForStats;
    public Text estimatedStatBoostCost;
    //ATK Bar
    public Slider attackSlider;
    public Text attackNumericDisplay;
    //ATK SPD Bar
    public Slider attackSpeedSlider;
    public Text attackSpeedNumericDisplay;
    //VIT Bar
    public Slider healthSlider;
    public Text healthNumericDisplay;
    //VIT REG Bar
    public Slider healthRegenSlider;
    public Text healthRegenNumericDisplay;
    //DEF Bar
    public Slider defenceSlider;
    public Text defenceNumericDisplay;
    //M SPD Bar
    public Slider movementSpeedSlider;
    public Text movementSpeedNumericDisplay;

    public float characterCost;


    void Update() {
        //setting text values for sliders
        attackNumericDisplay.text = calulateBoostMultiplier(attackSlider)+"x";
        attackSpeedNumericDisplay.text = calulateBoostMultiplier(attackSpeedSlider)+"x";
        healthNumericDisplay.text = calulateBoostMultiplier(healthSlider)+"x";
        healthRegenNumericDisplay.text = calulateBoostMultiplier(healthRegenSlider)+"x";
        defenceNumericDisplay.text = calulateBoostMultiplier(defenceSlider)+"x";
        movementSpeedNumericDisplay.text = calulateBoostMultiplier(movementSpeedSlider)+"x";
        //setting text values for sliders
        estimatedStatBoostCost.text = "Estimated Cost:"+(calculateCharacterBuffCost()).ToString();
        killAmountDisplayBaseRequirement.text = "Kills:"+(calculatedBaseValue()).ToString();
        //.text = "Your Kills:"+dbManagement.getZombieKills().ToString();
        //Debug.Log((dbManagement.getLevel()).ToString());
        //StateNameController.TESTINGSTUFF();

        characterIndexNum = getCharacterIndex();
        //resourceDisplayText.text = (StateNameController.blood).ToString();
        healthBarDisplayText.text = (characters[characterIndexNum].GetComponent<StatusManager>().health).ToString()+"/"+((characters[characterIndexNum].GetComponent<StatusManager>().maxHealth)).ToString();
        healthBar.value = setPercentages(characters[characterIndexNum].GetComponent<StatusManager>().health,(characters[characterIndexNum].GetComponent<StatusManager>().maxHealth));
        energyBarDisplayText.text = (characters[characterIndexNum].GetComponent<StatusManager>().mana).ToString()+"/"+(characters[characterIndexNum].GetComponent<StatusManager>().maxMana).ToString();
        energyBar.value = setPercentages(characters[characterIndexNum].GetComponent<StatusManager>().mana,(characters[characterIndexNum].GetComponent<StatusManager>().maxMana));
        updateIcons();
        updateCharacterStatSheet();

        basecharacterPrice = calculatedBaseValue();
        additiveBoostPrice = calculateCharacterBuffCost();
    }

    /*public static bool AbleToUseCharacter() {
        float attackPrice = ((characterIndexNum+1)*1000)*attackSlider.value;
        float attackSpeedPrice = ((characterIndexNum+1)*1000)*attackSpeedSlider.value;
        float healthPrice = ((characterIndexNum+1)*1000)*healthSlider.value;
        float healthRegenPrice = ((characterIndexNum+1)*1000)*healthRegenSlider.value;
        float defencePrice = ((characterIndexNum+1)*1000)*defenceSlider.value;
        float movementSpeedPrice = ((characterIndexNum+1)*1000)*movementSpeedSlider.value;
        if (dbManagement.getZombieKills()>=((characterIndexNum*500)+(attackPrice+attackSpeedPrice+healthPrice+healthRegenPrice+defencePrice+movementSpeedPrice))) {
            return true;
        }
        return false;
    }*/


    int calculatedBaseValue() {
        return(characterIndexNum*500);
    }


    string calulateBoostMultiplier(Slider sliderTAR) {
        return (1f+sliderTAR.value).ToString();
    }

    float calculateCharacterBuffCost() {
        float attackPrice = ((characterIndexNum+1)*1000)*attackSlider.value;
        float attackSpeedPrice = ((characterIndexNum+1)*1000)*attackSpeedSlider.value;
        float healthPrice = ((characterIndexNum+1)*1000)*healthSlider.value;
        float healthRegenPrice = ((characterIndexNum+1)*1000)*healthRegenSlider.value;
        float defencePrice = ((characterIndexNum+1)*1000)*defenceSlider.value;
        float movementSpeedPrice = ((characterIndexNum+1)*1000)*movementSpeedSlider.value;

        return (attackPrice+attackSpeedPrice+healthPrice+healthRegenPrice+defencePrice+movementSpeedPrice);
    }

    int getCharacterIndex() {
        return characterIndexNum = GameObject.Find("CharacterSelection").GetComponent<CharacterSelection>().currentCharacterCamera;
    }

    float setPercentages(float num1,float num2) {
        return num1/num2;
    }

    void updateIcons() {
        characterDescription.text = characterDescriptionsText[characterIndexNum];
        characterName.text = characterNames[characterIndexNum];
        characterNameForStats.text = characterNames[characterIndexNum];
        weaponImageIcon.sprite = WeaponImageIcons[characterIndexNum];
        ArmorImageIcon.sprite = ArmorImageIcons[characterIndexNum];
    }

    void updateCharacterStatSheet() {
        //weapon stuff
        gameObject.transform.Find("Background").transform.Find("WeaponIconBorder").GetComponent<WeaponTooltipTrigger>().weaponName = fetchWeaponName();
        gameObject.transform.Find("Background").transform.Find("WeaponIconBorder").GetComponent<WeaponTooltipTrigger>().damage = (characters[characterIndexNum].GetComponent<PlayerMovement>().characterDamage);
        gameObject.transform.Find("Background").transform.Find("WeaponIconBorder").GetComponent<WeaponTooltipTrigger>().range = (characters[characterIndexNum].GetComponent<PlayerMovement>().attackRange);
        gameObject.transform.Find("Background").transform.Find("WeaponIconBorder").GetComponent<WeaponTooltipTrigger>().attackSpeed = (characters[characterIndexNum].GetComponent<PlayerMovement>().attackSpeed/(1));
        gameObject.transform.Find("Background").transform.Find("WeaponIconBorder").GetComponent<WeaponTooltipTrigger>().targets = "Ground";
    
        //armor stuff
        gameObject.transform.Find("Background").transform.Find("ArmorIconBorder").GetComponent<ArmorTooltipTrigger>().ArmorName = fetchArmorName();
        gameObject.transform.Find("Background").transform.Find("ArmorIconBorder").GetComponent<ArmorTooltipTrigger>().armor = (characters[characterIndexNum].GetComponent<PlayerMovement>().armor);
        gameObject.transform.Find("Background").transform.Find("ArmorIconBorder").GetComponent<ArmorTooltipTrigger>().lifeRegen = (characters[characterIndexNum].GetComponent<PlayerMovement>().lifeRegen);
        gameObject.transform.Find("Background").transform.Find("ArmorIconBorder").GetComponent<ArmorTooltipTrigger>().movementSpeed = (characters[characterIndexNum].GetComponent<PlayerMovement>().speed);
    }

    string fetchWeaponName() {
        if (characterIndexNum == 0) { //characterSelected
            return "Fists";
        } else if (characterIndexNum == 1) {
            return "Steel Sword";
        }
        return "";
    }

    string fetchArmorName() {
        if (characterIndexNum == 0) {
            return "Broken Shield";
        } else if (characterIndexNum == 1) {
            return "Steel Shield";
        }
        return "";
    }



}
