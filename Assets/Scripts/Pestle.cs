using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pestle : MonoBehaviour
{
    public GameObject newIngredient;
    private GameObject tmp;
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
            if (ingredient.isInMortar == true)
            {
                tmp = Instantiate(newIngredient);
                tmp.GetComponent<Ingredient>().Properties = new string[ingredient.Properties.Length];
                System.Array.Copy(ingredient.Properties, tmp.GetComponent<Ingredient>().Properties, ingredient.Properties.Length);
                tmp.GetComponent<Ingredient>().PropertyStrength = new int[ingredient.PropertyStrength.Length];
                System.Array.Copy(ingredient.PropertyStrength, tmp.GetComponent<Ingredient>().PropertyStrength, ingredient.PropertyStrength.Length);
                tmp.GetComponent<Ingredient>().propertyColor = ingredient.propertyColor;
                tmp.transform.Find("Capsule").GetComponent<Renderer>().material.SetColor("_Color", ingredient.propertyColor);
                for (var i = 0; i < tmp.GetComponent<Ingredient>().PropertyStrength.Length; i++) {
                    tmp.GetComponent<Ingredient>().PropertyStrength[i] *= 2;
                }
                tmp.transform.position = other.transform.position;
                Destroy(other.gameObject);
            }
        }
    }
}
