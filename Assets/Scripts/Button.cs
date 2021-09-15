using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public GameObject spawn;
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
            var newObj = Instantiate(spawn);
            newObj.transform.position = collide.transform.position;
            newObj.transform.Translate(Vector3.up * (float)1.5, Space.World);
        }
    }
}
