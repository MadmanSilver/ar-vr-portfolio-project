using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CauldronLiquid : MonoBehaviour
{
    public Dictionary<string, int> properties;
    public ParticleSystemRenderer particle;
    public GameObject bubbles;
    private Material liquidMat;
    private Material bubbleMat;
    public TextMesh displayText;
    // Start is called before the first frame update
    void Start()
    {
        properties = new Dictionary<string, int>();
        liquidMat = this.GetComponent<MeshRenderer>().material;
        bubbleMat = bubbles.gameObject.GetComponent<ParticleSystemRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y >= .71) {
            transform.position = new Vector3(transform.position.x, (float).7, transform.position.z);
        }
        if (properties.Count > 0) {
            string final = "";
            foreach (KeyValuePair<string, int> property in properties)
            {
                final += $"{property.Key}: {property.Value}\n";
            }
            displayText.text = final;
        }
    }

    void OnParticleCollision(GameObject other)
    {
        if (transform.position.y < .69) {
            this.gameObject.GetComponent<MeshRenderer>().enabled = true;
            transform.Translate(Vector3.up * Time.deltaTime, Space.World);
            liquidMat.CopyPropertiesFromMaterial(particle.material);
            bubbleMat.CopyPropertiesFromMaterial(particle.material);
        }
    }

    void OnCollisionEnter(Collision collide) {
        Debug.Log(transform.position.y);
        if (transform.position.y >= .68) {
            if (collide.gameObject.tag == "Ingredient" || collide.gameObject.tag == "GroundIngredient") {
                var ingredient = collide.gameObject.GetComponent<Ingredient>();
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
                        properties[ingredient.Properties[i]] += ingredient.PropertyStrength[i];
                    } else {
                        properties[ingredient.Properties[i]] = ingredient.PropertyStrength[i];
                    }
                }
                liquidMat.SetColor("_Color", avgColor);
                bubbleMat.SetColor("_Color", avgColor);
                Destroy(collide.gameObject);
            }
        }
    }
}
