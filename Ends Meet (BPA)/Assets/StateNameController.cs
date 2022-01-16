using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateNameController : MonoBehaviour
{
    public static int characterSelected;
    public static bool readyToSpawnCharacter;
    public static int difficulty;
    public static int currentWave = 1;
    public static int zombiesAlive = 0;

    //main player stats
    public static string username = "NameNotAssigned";
    public static string Rank = "beginner";
    public static int Level = 1;
    public static int XP = 0;
    public static int maxXP = 25;
    public static int DNA = 0;
    public static int[] researchUpgrades = new int[1000];
    //main player stats

    public static GameObject playerCharacter;
    public static int blood;
    
    //character stats
    public static float damageBoost = 0f;
    public static float attackSpeedBoost = 0f;
    public static float healthBoost = 0f;
    public static float healthRegenBoost = 0f;
    public static float manaBoost = 0f;
    public static float manaRegenBoost = 0f;
    public static float visionBoost = 0f;
    public static float attackRangeBoost = 0f;

    // have not implimented upgrades for
    public static float armorBoost = 0f;
    public static float movementSpeedBoost;
    
    
    //character stats
}
