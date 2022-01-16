using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackClosestPlayer : MonoBehaviour
{
    GameObject[] players;
    public CharacterController controller;
    bool readyToAttack = true;
    int movementSpeed;
    public int runSpeed;
    public int walkSpeed;

    public GameObject beingTargettedIndicator;
    // enemy stats
    public float enemyDamage;
    public float attackRange;
    public float attackSpeed;
    public float armor;
    // enemy stats
    bool incombat;

    Vector3 velocity;
    float gravity = -9.18f;
    Coroutine attacking;
    //bool needToRotateToTarget = true;
    void Start()
    {
        players = new GameObject[5];
        players = GameObject.Find("PlayerSpawner").GetComponent<SpawnSelectedCharacter>().currentPlayers;
    }

    // Update is called once per frame
    void Update()
    {
        players = GameObject.Find("PlayerSpawner").GetComponent<SpawnSelectedCharacter>().currentPlayers;
        
        float dist = Vector3.Distance(players[findPlayerTarget()].transform.position,transform.position);
        if (dist <= attackRange && readyToAttack == true) {
            attacking = StartCoroutine(attackCooldown(players[findPlayerTarget()]));
        }

        if (incombat == false) {
            if (ChaseClosestTarget() == false) {
                movementSpeed = walkSpeed;
                moveToPlayer();
                //Debug.Log("rotating");
            } else {
                movementSpeed = runSpeed;
                moveToPlayer();
                //Debug.Log("walking");
            }
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    IEnumerator attackCooldown(GameObject target) {
        attackPlayer(target);
        incombat = true;
        //movementSpeed = 0;
        readyToAttack = false;
        yield return new WaitForSeconds(attackSpeed);
        incombat = false;
        readyToAttack = true;
    }

    public void attackPlayer(GameObject target) {
        if ((enemyDamage - target.GetComponent<PlayerMovement>().armor) <= 0f) {
            target.GetComponent<PlayerMovement>().inCombat = true;
            target.GetComponent<PlayerMovement>().attacked = true;
            target.GetComponent<StatusManager>().health = target.GetComponent<StatusManager>().health - 1;
        } else {
            target.GetComponent<PlayerMovement>().inCombat = true;
            target.GetComponent<PlayerMovement>().attacked = true;
            target.GetComponent<StatusManager>().health = target.GetComponent<StatusManager>().health - (enemyDamage - target.GetComponent<PlayerMovement>().armor);
        }
    }

    public int findPlayerTarget() {
        int closestEnemy = 0;  
        float closestEnemyPoisiton = float.MaxValue;
        for (int i = 0; i<players.Length; i++) {
            if (players[i] != null) {
                if (Vector3.Distance(players[i].transform.position,transform.position) < closestEnemyPoisiton) {
                    closestEnemyPoisiton = Vector3.Distance(players[i].transform.position,transform.position);
                    closestEnemy = i;
                }
            }
        }
        return closestEnemy;
    }

    public bool rotateToAngle(Quaternion desiredRotation) {
            transform.rotation = desiredRotation;
            return true;
    }

    /*
    public bool rotateToAngle(Quaternion desiredRotation) {
        transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotation, Time.deltaTime);
        if ((transform.rotation.eulerAngles.y >= desiredRotation.eulerAngles.y && transform.rotation.eulerAngles.y <= (desiredRotation.eulerAngles.y+2f)) || (transform.rotation.eulerAngles.y <= desiredRotation.eulerAngles.y && transform.rotation.eulerAngles.y >= (desiredRotation.eulerAngles.y-2f))){
            transform.rotation = desiredRotation;
            return true;
        }
        return false;
    }
    */
    public bool ChaseClosestTarget() {
        //Vector3 positionNeed = players[findPlayerTarget()].transform.position - transform.position;
        if (rotateToAngle(Quaternion.LookRotation((players[findPlayerTarget()].transform.position - transform.position),Vector3.up)) == true) {
            moveToPlayer();
        } else {
            return false;
        }
        return true;
    }

    public void moveToPlayer() {
        controller.Move(transform.forward * movementSpeed * Time.deltaTime);
    }

}
