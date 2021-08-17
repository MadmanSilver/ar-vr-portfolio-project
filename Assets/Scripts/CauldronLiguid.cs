using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CauldronLiguid : MonoBehaviour
{
    public List<string> names;
    public ParticleSystemRenderer particle;
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
        this.GetComponent<MeshRenderer>().material = particle.material;
        if (transform.position.y < -.9)
            transform.Translate(Vector3.up * Time.deltaTime, Space.World);
    }

    void OnCollisionEnter(Collision collide) {
        names.Add(collide.gameObject.name);
        Destroy(collide.gameObject);
        foreach (var n in names) {
            Debug.Log(n);
        }
    }
}
