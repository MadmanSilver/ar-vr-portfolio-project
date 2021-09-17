using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : MonoBehaviour
{
    public string Name;
    public string[] Properties;
    public int[] PropertyStrength;
    public Color propertyColor;
    public bool isInMortar = false;
    public TextMesh text;
    private float cookTime = 0f;
    public int isCooked = 0;

    // Start is called before the first frame update
    void Start()
    {
        setText();
    }

    // Update is called once per frame
    void Update()
    {
        if (isCooked == 1) {
            cookTime += Time.deltaTime;
        }
        if (cookTime > 6 && isCooked != 2) {
            isCooked = 2;
            int minVal = PropertyStrength.Min();
            for (int i = 0; i < PropertyStrength.Length; i++) {
                PropertyStrength[i] -= minVal;
            }
            Color tmp = Color.Lerp(propertyColor, Color.black, .1f);
            tmp.a = .5f;
            this.GetComponent<MeshRenderer>().material.SetColor("_Color", tmp);
            setText();
        }
    }
    void setText() {
        string statText = "";
        for (int i = 0; i < Properties.Length; i++) {
            statText += $"{Properties[i]}: {PropertyStrength[i]}\n";
        }
        text.text = statText;
    }
}
