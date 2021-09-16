using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CauldronLiquid : MonoBehaviour
{
    public Dictionary<string, float> properties;
    public GameObject bubbles;
    private Material liquidMat;
    private Material bubbleMat;
    public TextMesh displayText;
    public Collider parCol;
    public string baseName;
    // Start is called before the first frame update
    void Start()
    {
        properties = new Dictionary<string, float>();
        liquidMat = this.GetComponent<MeshRenderer>().material;
        bubbleMat = bubbles.gameObject.GetComponent<ParticleSystemRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y >= .71) {
            transform.position = new Vector3(transform.position.x, (float).7, transform.position.z);
            parCol.enabled = false;
        }
        if (properties.Count > 0) {
            string final = "";
            foreach (KeyValuePair<string, float> property in properties)
            {
                final += $"{property.Key}: {property.Value}\n";
            }
            displayText.text = final;
        }
    }

    void OnTriggerEnter(Collider collide) {
        Debug.Log(transform.position.y);
        if (transform.position.y >= .68) {
            if (collide.gameObject.tag == "Ingredient" || collide.gameObject.transform.parent.tag == "GroundIngredient") {
                Ingredient ingredient;
                if (collide.gameObject.tag == "Ingredient")
                    ingredient = collide.gameObject.GetComponent<Ingredient>();
                else
                    ingredient = collide.gameObject.transform.parent.GetComponent<Ingredient>();
                var avgColor = ingredient.propertyColor;
                if (properties.Count == 0) {
                    Debug.Log("top");
                    avgColor = Color.Lerp(Color.white, ingredient.propertyColor, (float)0.6);
                } else {
                    avgColor = Color.Lerp(liquidMat.GetColor("_Color"), ingredient.propertyColor, (float)0.5);
                }
                bubbles.SetActive(true);
                for (int i = 0; i < ingredient.Properties.Length; i++) {
                    if (properties.ContainsKey(ingredient.Properties[i])) {
                        properties[ingredient.Properties[i]] += baseCheck(baseName, ingredient.Properties[i], ingredient.PropertyStrength[i]);
                    } else {
                        properties[ingredient.Properties[i]] = baseCheck(baseName, ingredient.Properties[i], ingredient.PropertyStrength[i]);
                    }
                    Debug.Log(properties[ingredient.Properties[i]]);
                }
                liquidMat.SetColor("_Color", avgColor);
                bubbleMat.SetColor("_Color", avgColor);
                if (collide.gameObject.tag == "Ingredient")
                    Destroy(collide.gameObject);
                else
                    Destroy(collide.gameObject.transform.parent.gameObject);
            }
        }
    }

    float baseCheck(string bName, string propName, float strength) {
        switch (bName)
        {
            case "Oil":
                if (propName == "Regeneration")
                    return strength * 1.5f;
                else
                    return strength * .9f;
            case "Water":
                return strength;
            case "Whisky":
                return strength * 1.1f;
            case "Wine":
                if (propName == "Healing") {
                    return strength * 2f;
                } else {
                    return strength * .8f;
                }
            default:
                return strength;
        }
    }
}
