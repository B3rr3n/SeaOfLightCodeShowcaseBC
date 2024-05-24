using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Item_Pick_Up : MonoBehaviour
{
    public GameObject key;
    public GameObject player;
    public GameObject door;
    public GameObject keyUI;
    public float distx;
    public float distz;
    private float maxDist = 3;
    private float minDist = -3;
    public TextMeshProUGUI text;


    void Start()
    {
        keyUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "";
        
        //Works out the distance between two objects on the x axis and z axis
        distx = player.transform.position.x - key.transform.position.x;
        distz = player.transform.position.z - key.transform.position.z;

        //Removes the door and key when all conditions are met
        if (Input.GetKeyDown(KeyCode.E) && distx < maxDist && distz < maxDist && distx > minDist && distz > minDist)
        {
            text.text = ""; //Used to remove any text on the screen
            keyUI.SetActive(true);
            key.SetActive(false);
            door.SetActive(false);
        }

        //Display text on screen when player can pick up the key
        if (distx < maxDist && distz < maxDist && distx > minDist && distz > minDist)
        {
            text.text = "Press E to press the pick up the item";
            Debug.Log("Text Display");
        }
    }
}
