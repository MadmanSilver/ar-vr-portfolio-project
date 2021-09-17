using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionBottle : MonoBehaviour
{
    [Range(0.0f, 1.0f)]public float liquidAlpha = 0.75f;
    public MeshRenderer liquid;
    public Dictionary<string, float> properties;
    public string potionName = "Empty Potion";
    public TextMesh nameText;
    public string primaryProp = null;
    public string secondaryProp = null;

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

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.layer == 4 && !filled) {
            Material otherMat = other.gameObject.GetComponent<Renderer>().material;

            liquidColor.a = liquidAlpha;
            liquidColor.r = otherMat.color.r;
            liquidColor.g = otherMat.color.g;
            liquidColor.b = otherMat.color.b;
            liquidMat.color = liquidColor;

            properties = new Dictionary<string, float>(other.gameObject.GetComponent<CauldronLiquid>().properties);

            GenerateName();

            filled = true;
        }
    }

    private void GenerateName() {
        foreach (KeyValuePair<string, float> pair in properties) {
            Debug.Log("Before");

            if (primaryProp == null || primaryProp == "") {
                Debug.Log("if null");
                primaryProp = pair.Key;
                secondaryProp = pair.Key;
            }

            if (properties[primaryProp] <= pair.Value) {
                Debug.Log("if prim");
                secondaryProp = primaryProp;
                primaryProp = pair.Key;
            } else if (properties[secondaryProp] < pair.Value || secondaryProp == primaryProp) {
                Debug.Log("if sec");
                secondaryProp = pair.Key;
            }
        }

        potionName = properties[secondaryProp] >= 10 && primaryProp != secondaryProp ? $"{secondaryProp} Potion of {primaryProp}" : $"Potion of {primaryProp}";
        nameText.text = potionName;
    }
}
