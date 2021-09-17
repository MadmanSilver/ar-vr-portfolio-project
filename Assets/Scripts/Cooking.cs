using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cooking : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Ingredient") {
            var ingredient = other.gameObject.GetComponent<Ingredient>();
            ingredient.isCooked = 1;
        }
    }
    void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == "Ingredient") {
            var ingredient = other.gameObject.GetComponent<Ingredient>();
            if (ingredient.isCooked != 2)
                ingredient.isCooked = 0;
        }
    }
}
