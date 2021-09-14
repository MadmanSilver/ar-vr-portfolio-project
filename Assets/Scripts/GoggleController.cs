using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoggleController : MonoBehaviour
{
    public float tolerance = 5.0f;
    public GameObject goggles;
    public GameObject worldTint;

    private bool equipped = true;

    void Start() {
        foreach (GameObject text in GameObject.FindGameObjectsWithTag("Stats")) {
            text.GetComponent<MeshRenderer>().enabled = false;
        }
    }

    void Update() {
        if (transform.localRotation.eulerAngles.x - 360 >= -tolerance && !equipped) {
            GetComponent<HingeJoint>().useMotor = false;
            equipped = true;

            foreach (GameObject text in GameObject.FindGameObjectsWithTag("Stats")) {
                text.GetComponent<MeshRenderer>().enabled = true;
            }

            goggles.SetActive(false);
            worldTint.SetActive(true);
        } else if (transform.localRotation.eulerAngles.x - 360 < -tolerance && equipped) {
            GetComponent<HingeJoint>().useMotor = true;
            equipped = false;

            foreach (GameObject text in GameObject.FindGameObjectsWithTag("Stats")) {
                text.GetComponent<MeshRenderer>().enabled = false;
            }

            goggles.SetActive(true);
            worldTint.SetActive(false);
        }
    }
}
