using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerAction : MonoBehaviour
{
    public Transform cam;
    public float playerActivateDistance;
    public GameObject mainDoor;
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
                    // hit.collider.gameObject.GetComponentInChildren<Animator>()?.SetTrigger("openLeftDoor");
                    // SceneManager.LoadScene(1);
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
            
            //  && hit.transform.GetComponent<Animator>() == Maindoor.GetComponent<Animator>()
            // hit.transform.GetComponent<Animator>()?.SetTrigger("Activate");
        }
    }
}
