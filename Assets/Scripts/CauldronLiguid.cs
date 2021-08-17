using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CauldronLiguid : MonoBehaviour
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
        // TODO: Change this to /copy/ the material, not match it
        // This will preserve original base material when cauldron
        // starts to change colors
        this.GetComponent<MeshRenderer>().material = particle.material;
        bubbles.GetComponent<MeshRenderer>().material = particle.material;
        if (transform.position.y < -.9)
            transform.Translate(Vector3.up * Time.deltaTime, Space.World);
        if (transform.position.y == -.9)
            bubbles.SetActive(true);
    }

    void OnCollisionEnter(Collision collide) {
        if (transform.position.y == -.9) {
            names.Add(collide.gameObject.name);
            Destroy(collide.gameObject);
            foreach (var n in names) {
                Debug.Log(n);
            }
        }
    }
}
