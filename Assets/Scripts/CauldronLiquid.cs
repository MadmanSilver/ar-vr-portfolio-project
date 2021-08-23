using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CauldronLiquid : MonoBehaviour
{
    public List<string> names;
    public ParticleSystemRenderer particle;
    public GameObject bubbles;
    private Material liquidMat;
    private Material bubbleMat;
    // Start is called before the first frame update
    void Start()
    {
        names = new List<string>();
        liquidMat = this.GetComponent<MeshRenderer>().material;
        bubbleMat = bubbles.gameObject.GetComponent<ParticleSystemRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y >= -.9) {
            transform.position = new Vector3(transform.position.x, (float)-.89, transform.position.z);
            bubbles.SetActive(true);
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
                names.Add(collide.gameObject.name);
                Debug.Log(collide.gameObject.GetComponent<Ingredient>().Name);
                liquidMat.SetColor("_Color", collide.gameObject.GetComponent<Ingredient>().propertyColor);
                bubbleMat.SetColor("_Color", liquidMat.GetColor("_Color"));
                Destroy(collide.gameObject);
            }
        }
    }
}
