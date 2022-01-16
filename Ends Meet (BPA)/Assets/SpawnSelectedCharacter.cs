using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSelectedCharacter : MonoBehaviour
{
    
    public int characterSelected;
    public GameObject[] cameraTypes;
    public GameObject[] currentPlayerCameras;
    public GameObject[] characterTypes;
    public GameObject[] currentPlayers;
    public bool readyToSpawn = false;
    public int currentPlayerAmount = 0;


    void Start()
    {
        //characterTypes = new GameObject[10];
        currentPlayers = new GameObject[5];
        currentPlayerCameras = new GameObject[5];

    }

    // Update is called once per frame
    void Update()
    {
        if (StateNameController.readyToSpawnCharacter == true) {
            StateNameController.readyToSpawnCharacter = false;
            currentPlayers[currentPlayerAmount] = Instantiate(characterTypes[StateNameController.characterSelected], transform.position, characterTypes[StateNameController.characterSelected].transform.rotation);
            StateNameController.playerCharacter = currentPlayers[currentPlayerAmount];
            currentPlayerCameras[currentPlayerAmount] = Instantiate(cameraTypes[0], transform.position, cameraTypes[0].transform.rotation);
            currentPlayerCameras[currentPlayerAmount].GetComponent<PlayerCameraFunctionality>().cameraHeight = currentPlayers[currentPlayerAmount].GetComponent<PlayerMovement>().sight;
            currentPlayerCameras[currentPlayerAmount].GetComponent<PlayerCameraFunctionality>().player = currentPlayers[currentPlayerAmount];
            currentPlayers[currentPlayerAmount].GetComponent<PlayerMovement>().playerCamera = currentPlayerCameras[currentPlayerAmount].transform.GetChild(0).gameObject;
            currentPlayerAmount+=1;
        }
    }
}
