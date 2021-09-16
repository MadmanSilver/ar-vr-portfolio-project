using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public MeshRenderer[] texts;
    public Transform player;
    public Transform[] items;
    public Transform[] buttons;
    public Transform liqPos;
    public Collider parCol;
    public CauldronLiquid liquid;
    public GameObject worldTint;

    private int stage = 0;
    private List<Vector3> itemsPrev = new List<Vector3>();
    private int prevGround = 0;
    private int prevPot = 0;

    // Update is called once per frame
    void Update()
    {
        switch(stage) {
            case 0:
                if (player.position.z > transform.position.z + 2.5f) {
                    texts[stage].enabled = false;
                    stage++;
                    texts[stage].enabled = true;
                    foreach (Transform item in items) {
                        itemsPrev.Add(item.position);
                    }
                }
                break;
            case 1:
                for (int i = 0; i < items.Length; i++) {
                    if (items[i].position != itemsPrev[i]) {
                        texts[stage].enabled = false;
                        stage++;
                        texts[stage].enabled = true;
                        break;
                    }
                }
                break;
            case 2:
                for (int i = 0; i < buttons.Length; i++) {
                    if (buttons[i].localPosition.y < 0.3f) {
                        texts[stage].enabled = false;
                        stage++;
                        texts[stage].enabled = true;
                        break;
                    }
                }
                break;
            case 3:
                if (player.position.x > transform.position.x + 1.0f) {
                    texts[stage].enabled = false;
                    stage++;
                    texts[stage].enabled = true;
                }
                break;
            case 4:
                if (liqPos.localPosition.y > -0.07) {
                    texts[stage].enabled = false;
                    stage++;
                    texts[stage].enabled = true;
                }
                break;
            case 5:
                if (parCol.enabled == false) {
                    texts[stage].enabled = false;
                    stage++;
                    texts[stage].enabled = true;
                }
                break;
            case 6:
                if (liquid.properties.Count > 0) {
                    texts[stage].enabled = false;
                    stage++;
                    texts[stage].enabled = true;
                }
                break;
            case 7:
                if (worldTint.activeSelf == true) {
                    texts[stage].enabled = false;
                    stage++;
                    texts[stage].enabled = true;
                }
                break;
            case 8:
                if (player.position.x > transform.position.x + 1.0f && player.position.z > transform.position.z + 1.0f) {
                    texts[stage].enabled = false;
                    stage++;
                    texts[stage].enabled = true;
                    prevGround = GameObject.FindGameObjectsWithTag("GroundIngredient").Length;
                }
                break;
            case 9:
                if (GameObject.FindGameObjectsWithTag("GroundIngredient").Length > prevGround) {
                    texts[stage].enabled = false;
                    stage++;
                    texts[stage].enabled = true;
                    prevGround = GameObject.FindGameObjectsWithTag("GroundIngredient").Length;
                }
                break;
            case 10:
                if (GameObject.FindGameObjectsWithTag("GroundIngredient").Length < prevGround) {
                    texts[stage].enabled = false;
                    stage++;
                    texts[stage].enabled = true;
                    foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Potion")) {
                        if (obj.GetComponent<PotionBottle>().potionName != "Empty Potion") {
                            prevPot++;
                        }
                    }
                }
                break;
            case 11:
                int count = 0;
                foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Potion")) {
                    if (obj.GetComponent<PotionBottle>().potionName != "Empty Potion") {
                        count++;
                    }
                }
                if (count > prevPot) {
                    texts[stage].enabled = false;
                    stage++;
                    texts[stage].enabled = true;
                }
                break;
        }
    }
}
