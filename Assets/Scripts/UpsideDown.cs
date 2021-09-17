using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UpsideDown : MonoBehaviour
{
    void OnCollisionEnter(Collision col) {
        if (col.gameObject.tag == "Mage Light") {
            int index = SceneManager.GetActiveScene().buildIndex;
            if (index == 0) {
                SceneManager.LoadScene(1);
            } else {
                SceneManager.LoadScene(0);
            }
        }
    }
}
