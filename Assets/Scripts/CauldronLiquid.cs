using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CauldronLiquid : MonoBehaviour
{
    public List<string> names;
    public ParticleSystemRenderer particle;
    public GameObject bubbles;
    // Start is called before the first frame update
    void Start()
    {
        names = new List<string>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnParticleCollision(GameObject other)
    {
        this.GetComponent<MeshRenderer>().material.CopyPropertiesFromMaterial(particle.material);
        bubbles.gameObject.GetComponent<ParticleSystemRenderer>().material.CopyPropertiesFromMaterial(particle.material);
        if (transform.position.y < -.9)
            transform.Translate(Vector3.up * Time.deltaTime, Space.World);
        if (transform.position.y >= -.9) {
            transform.position = new Vector3(transform.position.x, (float)-.9, transform.position.z);
            bubbles.SetActive(true);
        }
    }

    void OnCollisionEnter(Collision collide) {
        if (transform.position.y >= -.9) {
            if (collide.gameObject.tag == "Ingredient") {
                names.Add(collide.gameObject.name);
                Destroy(collide.gameObject);
                foreach (var n in names) {
                    Debug.Log(n);
                }
            }
        }
    }
}
