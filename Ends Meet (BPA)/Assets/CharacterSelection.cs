using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelection : MonoBehaviour
{
    public GameObject[] characterCameras;
    public int currentCharacterCamera;
    public bool selectingCharacter;



    void Start()
    {
        if (selectingCharacter == true) {
            setCamera(currentCharacterCamera);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (selectingCharacter == true) {
            setCamera(currentCharacterCamera);
        }
    }

    public void setCamera(int cameraIndex) {
        for (int i = 0; i < characterCameras.Length; i++) {
            if (i == cameraIndex) {
                characterCameras[i].SetActive(true);
            } else {
                characterCameras[i].SetActive(false);
            }
        }
    }
}
