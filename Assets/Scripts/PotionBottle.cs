using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionBottle : MonoBehaviour
{
    [Range(0.0f, 1.0f)]public float liquidAlpha = 0.75f;
    public MeshRenderer liquid;

    private bool filled = false;
    private Material liquidMat;
    private Color liquidColor = new Color();

    // Start is called before the first frame update
    void Start()
    {
        liquidMat = liquid.material;
        liquidColor.a = 0.0f;
        liquidMat.color = liquidColor;
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.layer == 4 && !filled) {
            Material otherMat = collision.gameObject.GetComponent<Renderer>().material;

            liquidColor.a = liquidAlpha;
            liquidColor.r = otherMat.color.r;
            liquidColor.g = otherMat.color.g;
            liquidColor.b = otherMat.color.b;
            liquidMat.color = liquidColor;

            filled = true;
        }
    }
}
