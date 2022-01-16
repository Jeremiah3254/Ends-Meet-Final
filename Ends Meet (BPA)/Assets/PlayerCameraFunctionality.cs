using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraFunctionality : MonoBehaviour
{
    public GameObject player;
    public float cameraHeight;



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null) {
            followPlayer();
        }
    }

    public void followPlayer() {
        transform.position = new Vector3(player.transform.position.x,(cameraHeight+StateNameController.visionBoost),player.transform.position.z);
    }
}
