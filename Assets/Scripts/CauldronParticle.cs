using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CauldronParticle : MonoBehaviour
{
    public GameObject liquid;
    public GameObject bubbles;
    public ParticleSystemRenderer particle;
    private Material liquidMat;
    private Material bubbleMat;
    private CauldronLiquid lq;
    // Start is called before the first frame update
    void Start()
    {
        liquidMat = liquid.GetComponent<MeshRenderer>().material;
        bubbleMat = bubbles.gameObject.GetComponent<ParticleSystemRenderer>().material;
        lq = liquid.GetComponent<CauldronLiquid>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnParticleCollision(GameObject other)
    {
        if (transform.position.y < .69) {
            liquid.GetComponent<MeshRenderer>().enabled = true;
            liquid.transform.Translate(Vector3.up * Time.deltaTime, Space.World);
            liquidMat.CopyPropertiesFromMaterial(particle.material);
            bubbleMat.CopyPropertiesFromMaterial(particle.material);
            lq.baseName = particle.material.name;
            lq.baseName = lq.baseName.Substring(0, lq.baseName.Length - 11);
        }
    }
}
