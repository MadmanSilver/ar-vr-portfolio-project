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
        if (transform.position.y >= -.9) {
            transform.position = new Vector3(transform.position.x, (float)-.89, transform.position.z);
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
         if (transform.position.y < -.9) {
            transform.Translate(Vector3.up * Time.deltaTime, Space.World);
            liquidMat.CopyPropertiesFromMaterial(particle.material);
            bubbleMat.CopyPropertiesFromMaterial(particle.material);
        }
    }

    void OnCollisionEnter(Collision collide) {
        if (transform.position.y >= -.99) {
            if (collide.gameObject.tag == "Ingredient") {
                var ingredient = collide.gameObject.GetComponent<Ingredient>();
                bubbles.SetActive(true);
                for (int i = 0; i < ingredient.Properties.Length; i++) {
                    if (properties.ContainsKey(ingredient.Properties[i])) {
                        properties[ingredient.Properties[i]] += ingredient.PropertyStrength[i];
                    } else {
                        properties[ingredient.Properties[i]] = ingredient.PropertyStrength[i];
                    }
                }
                liquidMat.SetColor("_Color", ingredient.propertyColor);
                bubbleMat.SetColor("_Color", liquidMat.GetColor("_Color"));
                Destroy(collide.gameObject);
            }
        }
    }
}
