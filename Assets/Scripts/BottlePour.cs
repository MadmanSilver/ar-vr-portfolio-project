using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottlePour : MonoBehaviour
{
    public int PourThreshhold;
    public GameObject Origin;

    private bool Pouring = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float angle = Vector3.Angle(Vector3.up, Origin.transform.forward);
        if (angle > PourThreshhold)
        {
            if (!Pouring)
                StartPour();
        }
        else {
            if (Pouring)
                StopPour();
        }
    }

    private void StartPour() {
        Pouring = true;
        Origin.SetActive(true);
    }

    private void StopPour() {
        Pouring = false;
        Origin.SetActive(false);
    }
}
