using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
public class WaveManager : MonoBehaviour
{
    public Text waveAmountDisplay;
    public GameObject[] zombieTypes;
    public GameObject[] currentZombies;
 
    public GameObject[] spawnableLocations;
    public float mobSpawnDelay;
 
    public bool spawnNewWave;
    public bool currentWaveFound;
    //public int zombiesAlive;
 

    int zombiesSpawned = 0;
    public int zombieAmount;
    //Types of zombies to Spawn
    public int normalZombies;
    public int speedyZombies;
    public int giantZombies;
    public int inteligentZombies;
    //Types of zombies to spawn
    public Wave[] waves;
 
    Coroutine spawningMobs;
    bool spawnOnCD = false;
 
    void Start()
    {
        currentZombies = new GameObject[50000];
    }
 
    // Update is called once per frame
    void Update()
    {
        waveAmountDisplay.text = (StateNameController.currentWave).ToString();
        if (currentWaveFound == true) {
            currentWaveFound = false;
            StateNameController.zombiesAlive = 0;
 
            zombieAmount = waves[StateNameController.currentWave-1].zombieAmount;
            normalZombies = waves[StateNameController.currentWave-1].normalZombies;
            speedyZombies = waves[StateNameController.currentWave-1].speedyZombies;
            giantZombies = waves[StateNameController.currentWave-1].giantZombies;
            inteligentZombies = waves[StateNameController.currentWave-1].inteligentZombies;
 
            spawnNewWave = true;
        }
 
        if (zombieAmount != 0 && spawnNewWave == true) {
            if (spawnOnCD == false) {
                spawningMobs = StartCoroutine(spawnDelay());
            }
        } else if (zombieAmount == 0 && StateNameController.zombiesAlive == 0) {
            Debug.Log(StateNameController.zombiesAlive); // remove
            if (waves.Length > ((StateNameController.currentWave)-1)) {
                StateNameController.currentWave +=1;
                zombiesSpawned = 0;
                currentWaveFound = true;
                spawnNewWave = true;
                StopCoroutine(spawnDelay());
            }
        } else {
        }
    }
 
    IEnumerator spawnDelay() {
        //Debug.Log("One");
        spawnOnCD = true;
        addDifficultyBuff(spawningOrder(), zombieTypes[spawningOrder()].GetComponent<StatusManager>().maxHealth, zombieTypes[spawningOrder()].GetComponent<AttackClosestPlayer>().enemyDamage, zombieTypes[spawningOrder()].GetComponent<AttackClosestPlayer>().attackRange, zombieTypes[spawningOrder()].GetComponent<AttackClosestPlayer>().attackSpeed);
        tallyZombies();
        zombiesSpawned+=1;
        yield return new WaitForSeconds(mobSpawnDelay);
        spawnOnCD = false;
        //Debug.Log("Two");
    }
 
    public int spawningOrder() {
        if (normalZombies > 0) {
            return 0;
        } else if (speedyZombies > 0) {
            return 1;
        } else if (giantZombies > 0) {
            return 2;
        } else if (inteligentZombies > 0) {
            return 3;
        }
        return 0;
    }
 
    public void tallyZombies() {
        if (spawningOrder() == 0) {
            normalZombies = normalZombies-1;
        }else if (spawningOrder() == 1) {
            speedyZombies = speedyZombies-1;
        }else if (spawningOrder() == 2) {
            giantZombies = giantZombies-1;
        }else if (spawningOrder() == 3) {
            inteligentZombies = inteligentZombies-1;
        }
        zombieAmount = zombieAmount-1;
    }
 
    public void addDifficultyBuff(int zombieType,float health,float damage,float range,float attackSpeed) {
        if (StateNameController.difficulty == 1) {
            health = (health*0.1f);
            damage = (damage*0.1f);
            range = (range*0.1f);
            attackSpeed = (int) (attackSpeed*0.1f);
        }
        addChallengeEffects(zombieType,health,damage,range,attackSpeed);
    }
 
    public void addChallengeEffects(int zombieType,float health,float damage,float range,float attackSpeed) {
        spawnZombie(zombieType,health,damage,range,attackSpeed);
    }
 
    public void spawnZombie(int zombieType,float health,float damage,float range,float attackSpeed) {
        GameObject newZombie = Instantiate(zombieTypes[zombieType],spawnableLocations[(int) (Random.Range(0,spawnableLocations.Length))].transform.position, zombieTypes[zombieType].transform.rotation);
        //assign zombie buffs
        newZombie.GetComponent<StatusManager>().maxHealth = health;
        newZombie.GetComponent<StatusManager>().health = health;
        newZombie.GetComponent<AttackClosestPlayer>().enemyDamage = damage;
        newZombie.GetComponent<AttackClosestPlayer>().attackRange = range;
        newZombie.GetComponent<AttackClosestPlayer>().attackSpeed = attackSpeed;
        //assign zombie buffs
 
        //(int) (Random.Range(0,spawnableLocations.Length))
        currentZombies[zombiesSpawned] = newZombie;
        StateNameController.zombiesAlive+=1;
    }
}