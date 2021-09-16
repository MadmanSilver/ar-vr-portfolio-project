using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldTint : MonoBehaviour
{
    public float rate = 1;
    private Color startColor;
    private Color endColor;
    private float i = 0;
    // Start is called before the first frame update
    void Start()
    {
        startColor = this.GetComponent<Renderer>().material.GetColor("_Color");
        endColor = startColor;
        startColor.a = 0.2f;
        endColor.a = .7f;
    }

    // Update is called once per frame
    void Update()
    {
        changeTint();
    }
    public void changeTint() {
        i += Time.deltaTime * rate;
        Debug.Log(this.GetComponent<Renderer>().material.color);
        this.GetComponent<Renderer>().material.SetColor("_Color", Color.Lerp(startColor, endColor, i));
        // If we've got to the current target colour, choose a new one
        if(i >= 1) {
            i = 0;
            startColor = endColor;
            endColor.a = endColor.a > .21f ? .2f : .7f;
        }
    }
}
