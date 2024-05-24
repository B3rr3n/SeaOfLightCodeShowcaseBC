using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Caught_Script : MonoBehaviour
{

    public GameObject playerLocation;
    public GameObject caughtMenu;
    public GameObject playerViewUI;
    public GameObject key;
    public GameObject jailDoor;
    public GameObject keyUI;


    public Transform prisonLocation;

    // Start is called before the first frame update
    void Start()
    {
        caughtMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpottedPlayer()
    {
        caughtMenu.SetActive(false);
        keyUI.SetActive(false);
        playerViewUI.SetActive(true);
        key.SetActive(true);
        jailDoor.SetActive(true);
        Debug.Log("Player Caught");
        playerLocation.transform.position = prisonLocation.transform.position;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1.0f; //Should unfreeze all objects and animations
    }
}
