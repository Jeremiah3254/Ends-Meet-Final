using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterOptions : MonoBehaviour
{
    public GameObject getScriptInside;

    public void NextCharacter () {
        if (GameObject.Find("CharacterSelection").GetComponent<CharacterSelection>().currentCharacterCamera < GameObject.Find("CharacterSelection").GetComponent<CharacterSelection>().characterCameras.Length-1) {
            GameObject.Find("CharacterSelection").GetComponent<CharacterSelection>().currentCharacterCamera = GameObject.Find("CharacterSelection").GetComponent<CharacterSelection>().currentCharacterCamera+1;
        }
    }

    public void PreviousCharacter() {
        if (GameObject.Find("CharacterSelection").GetComponent<CharacterSelection>().currentCharacterCamera > 0) {
            GameObject.Find("CharacterSelection").GetComponent<CharacterSelection>().currentCharacterCamera = GameObject.Find("CharacterSelection").GetComponent<CharacterSelection>().currentCharacterCamera-1;
        }
    }

    public void chooseCharacter() {
        //if (dbManagement.getZombieKills() >= (getScriptInside.GetComponent<CharacterStatsUI>().basecharacterPrice+getScriptInside.GetComponent<CharacterStatsUI>().additiveBoostPrice)) {
        StateNameController.characterSelected = GameObject.Find("CharacterSelection").GetComponent<CharacterSelection>().currentCharacterCamera;
        StateNameController.readyToSpawnCharacter = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //dbManagement.increaseDNA();
        //}
    }
}
