using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    public Transform cam;
    public float playerActivateDistance;
    bool active = false;

    private void Update()
    {
        RaycastHit hit;
        active = Physics.Raycast(cam.position, cam.TransformDirection(Vector3.forward), out hit, playerActivateDistance);

        if(Input.GetKeyDown(KeyCode.F) && active == true)
        {
            Debug.Log("animation done");
             // hit.transform.GetComponent<Animator>()?.SetTrigger("Activate");
        }
    }
}
