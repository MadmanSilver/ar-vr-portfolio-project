using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public GameObject spawn;
    public bool isRestart = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collide) {
        if (collide.gameObject.tag == "Button") {
            if (isRestart)
                SceneManager.LoadScene(0);
            else {
                var newObj = Instantiate(spawn);
                newObj.transform.position = collide.transform.position;
                newObj.transform.Translate(Vector3.up * 1.2f, Space.World);
                newObj.transform.Translate(Vector3.forward * -.5f, Space.World);
            }
        }
    }
}
