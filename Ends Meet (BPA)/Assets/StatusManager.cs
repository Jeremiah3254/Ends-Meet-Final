using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StatusManager : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public float mana;
    public float maxMana;

    
    public Slider manaSlider;
    public Text manaNumericDisplay;


    public int bloodReward;
    public GameObject healthBarUI;
    public Slider slider;
    public Text healthNumericDisplay;


    public Transform camTransform;
	Quaternion originalRotation;
    public bool PresetCamera;

    public bool ismob;

    public bool alreadyIncreasedStats = false;

    

    // Start is called before the first frame update
    void Start()
    {
        //camTransform = GameObject.Find("Main Camera").transform;
        mana = (maxMana+StateNameController.manaBoost);
        manaSlider.value = (maxMana+StateNameController.manaBoost);
    

        health = (maxHealth+StateNameController.healthBoost);
        slider.value = CalculateHealth();
        originalRotation = healthBarUI.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (camTransform == null && GameObject.Find("PlayerSpawner").GetComponent<SpawnSelectedCharacter>().currentPlayerCameras[0].transform != null && PresetCamera == false) {
        camTransform = GameObject.Find("PlayerSpawner").GetComponent<SpawnSelectedCharacter>().currentPlayerCameras[0].transform;
        }
        manaSlider.value = CalculateMana();
        manaNumericDisplay.text = (mana).ToString()+"/"+((maxMana+StateNameController.manaBoost)).ToString();

        slider.value = CalculateHealth();
        healthNumericDisplay.text = (health).ToString()+"/"+((maxHealth+StateNameController.healthBoost)).ToString();
        healthBarUI.transform.rotation = camTransform.rotation * originalRotation;
        if (health <= 0) {
            if (ismob == true && alreadyIncreasedStats == false) {
                alreadyIncreasedStats = true;
                StateNameController.zombiesAlive -= 1;
                //dbManagement.increaseZombieKills();
                //dbManagement.increaseXP();
                //dbManagement.increaseDNA();
                StateNameController.blood = StateNameController.blood + bloodReward;
            }
            Destroy(gameObject);
        }

        if (health > (maxHealth+StateNameController.healthBoost)) {
            health = (maxHealth+StateNameController.healthBoost);
        }

        if (mana > (maxMana+StateNameController.manaBoost)) {
            mana = (maxMana+StateNameController.manaBoost);
        }
    }
    
    float CalculateHealth() {
        return health/(maxHealth+StateNameController.healthBoost);
    }

    float CalculateMana() {
        return mana/(maxMana+StateNameController.manaBoost);
    }

    public void isZombieCounter() {
        StateNameController.zombiesAlive = StateNameController.zombiesAlive - 1;
    }
}
