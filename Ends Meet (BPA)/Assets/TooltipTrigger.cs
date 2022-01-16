using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TooltipTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public string uName;
    public string uDescription;
    public int uCost;
    public bool empty;
    public int minUPG;
    public int maxUPG;
    public int abilityType;
    public float abilityRange;
    public GameObject rangeCirclePrefab;
    public GameObject enemyTargetCirclePrefab;
    
    
    int currentTarget = int.MaxValue;
    bool showAvailableTarget = false;

    void Awake() {
        //gameObject.GetComponent<Button>
        gameObject.GetComponent<Button>().onClick.AddListener(() => StartCoroutine(refreshDelay()));
    }

    IEnumerator refreshDelay() {
        yield return new WaitForSeconds(0.1f * Time.deltaTime);
        TooltipSystem.Show(uDescription,uName,uCost,empty,minUPG,maxUPG,abilityType);
    }
    public void OnPointerEnter(PointerEventData eventData) {
        TooltipSystem.Show(uDescription,uName,uCost,empty,minUPG,maxUPG,abilityType);
        if (abilityType == 2) {
            showAvailableTarget = true;
            StateNameController.playerCharacter.GetComponent<PlayerMovement>().rangeDisplayCircle = Instantiate( rangeCirclePrefab );
            StateNameController.playerCharacter.GetComponent<PlayerMovement>().rangeDisplayCircle.transform.SetParent(StateNameController.playerCharacter.transform,false);
            StateNameController.playerCharacter.GetComponent<PlayerMovement>().rangeDisplayCircle.GetComponent<Projector>().orthographicSize = abilityRange+1f;
            StateNameController.playerCharacter.GetComponent<PlayerMovement>().rangeDisplayCircle.transform.localPosition = new Vector3(0,0,0);
            StateNameController.playerCharacter.GetComponent<PlayerMovement>().rangeDisplayCircle.transform.eulerAngles = new Vector3( 90, 0, 0 );
        } else if (StateNameController.playerCharacter.GetComponent<PlayerMovement>().rangeDisplayCircle != null) {
            Destroy(StateNameController.playerCharacter.GetComponent<PlayerMovement>().rangeDisplayCircle.gameObject);
            StateNameController.playerCharacter.GetComponent<PlayerMovement>().rangeDisplayCircle = null;
        }
    }

    public void OnPointerExit(PointerEventData eventData) {
       TooltipSystem.Hide();
       if (StateNameController.playerCharacter.GetComponent<PlayerMovement>().rangeDisplayCircle != null) {
            showAvailableTarget = false;
            GameObject enemyBase = GameObject.Find("MobManagement");
            if (currentTarget != int.MaxValue && enemyBase.GetComponent<WaveManager>().currentZombies[currentTarget].GetComponent<AttackClosestPlayer>().beingTargettedIndicator.gameObject != null) {
                Destroy(enemyBase.GetComponent<WaveManager>().currentZombies[currentTarget].GetComponent<AttackClosestPlayer>().beingTargettedIndicator.gameObject);
                enemyBase.GetComponent<WaveManager>().currentZombies[currentTarget].GetComponent<AttackClosestPlayer>().beingTargettedIndicator = null;
                currentTarget = int.MaxValue;
            }

            Destroy(StateNameController.playerCharacter.GetComponent<PlayerMovement>().rangeDisplayCircle.gameObject);
            StateNameController.playerCharacter.GetComponent<PlayerMovement>().rangeDisplayCircle = null;
       }
    }

    void Update() {
        checkIfStillInRange();
        if (showAvailableTarget == true) {
            AddCircle();
        }
    }

    void checkIfStillInRange() {
        if (currentTarget != int.MaxValue) {
                GameObject enemyBase = GameObject.Find("MobManagement");
                GameObject currentEnemyReference = enemyBase.GetComponent<WaveManager>().currentZombies[currentTarget];
            if ((currentEnemyReference != null) && (Vector3.Distance(currentEnemyReference.transform.position,StateNameController.playerCharacter.transform.position) > (abilityRange+1f))) {
                Destroy(enemyBase.GetComponent<WaveManager>().currentZombies[currentTarget].GetComponent<AttackClosestPlayer>().beingTargettedIndicator.gameObject);
                enemyBase.GetComponent<WaveManager>().currentZombies[currentTarget].GetComponent<AttackClosestPlayer>().beingTargettedIndicator = null;
                currentTarget = int.MaxValue;
            } else if (currentEnemyReference == null) {
                currentTarget = int.MaxValue;
            }
        }
    }

    void AddCircle() {
        GameObject enemyBase = GameObject.Find("MobManagement");
        int currentEnemyReferenceNum = findClosestEnemy();
        GameObject currentEnemyReference = enemyBase.GetComponent<WaveManager>().currentZombies[currentEnemyReferenceNum];
        //Debug.Log("errr");
        //Debug.Log(Vector3.Distance(currentEnemyReference.transform.position,StateNameController.playerCharacter.transform.position));
        if ((currentEnemyReference != null) && (Vector3.Distance(currentEnemyReference.transform.position,StateNameController.playerCharacter.transform.position) <= (abilityRange+1f))) {// range from ability + 1.1;
            if (currentTarget == int.MaxValue) {
                currentTarget = currentEnemyReferenceNum;

                //Debug.Log(currentEnemyReferenceNum);
                currentEnemyReference.GetComponent<AttackClosestPlayer>().beingTargettedIndicator = Instantiate(enemyTargetCirclePrefab);
                currentEnemyReference.GetComponent<AttackClosestPlayer>().beingTargettedIndicator.transform.SetParent(currentEnemyReference.transform,false);
                currentEnemyReference.GetComponent<AttackClosestPlayer>().beingTargettedIndicator.GetComponent<Projector>().orthographicSize = 1f;
                currentEnemyReference.GetComponent<AttackClosestPlayer>().beingTargettedIndicator.transform.localPosition = new Vector3(0,0,0);
                currentEnemyReference.GetComponent<AttackClosestPlayer>().beingTargettedIndicator.transform.eulerAngles = new Vector3( 90, 0, 0 );
            }else if (currentEnemyReferenceNum != currentTarget) {
                Destroy(enemyBase.GetComponent<WaveManager>().currentZombies[currentTarget].GetComponent<AttackClosestPlayer>().beingTargettedIndicator.gameObject);
                enemyBase.GetComponent<WaveManager>().currentZombies[currentTarget].GetComponent<AttackClosestPlayer>().beingTargettedIndicator = null;
                currentTarget = currentEnemyReferenceNum;

                //Debug.Log(currentEnemyReferenceNum);
                currentEnemyReference.GetComponent<AttackClosestPlayer>().beingTargettedIndicator = Instantiate(enemyTargetCirclePrefab);
                currentEnemyReference.GetComponent<AttackClosestPlayer>().beingTargettedIndicator.transform.SetParent(currentEnemyReference.transform,false);
                currentEnemyReference.GetComponent<AttackClosestPlayer>().beingTargettedIndicator.GetComponent<Projector>().orthographicSize = 1f;
                currentEnemyReference.GetComponent<AttackClosestPlayer>().beingTargettedIndicator.transform.localPosition = new Vector3(0,0,0);
                currentEnemyReference.GetComponent<AttackClosestPlayer>().beingTargettedIndicator.transform.eulerAngles = new Vector3( 90, 0, 0 );
            }
        }
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
