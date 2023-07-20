using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerAction : MonoBehaviour
{
    public Transform cam;
    public float playerActivateDistance;
    public GameObject rightDoor;
    public GameObject leftDoor;
    public GameObject playerCamera;
    public GameObject zoomCamera;
    bool active = false;
    

    private void Update()
    {
        RaycastHit hit;
        active = Physics.Raycast(cam.position, cam.TransformDirection(Vector3.forward), out hit, playerActivateDistance);

        if(Input.GetKeyDown(KeyCode.F) && active == true)
        {
            try
            {
                if (hit.collider.tag == "MainDoor")
                {
                    
                    rightDoor.GetComponent<Animator>().SetTrigger("Active");
                    leftDoor.GetComponent<Animator>().SetTrigger("Active");
                }
            }
            catch { }
            try
            {
                if( hit.collider.tag == "desk")
                {
                    playerCamera.SetActive(false);
                    zoomCamera.SetActive(true);
                }
            }
            catch { }
        }
    }
}
