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

    // Start is called before the first frame update
    void Start()
    {
        string statText = "";
        for (int i = 0; i < Properties.Length; i++) {
            statText += $"{Properties[i]}: {PropertyStrength[i]}\n";
        }
        text.text = statText;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
