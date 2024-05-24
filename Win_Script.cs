using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win_Script : MonoBehaviour
{

    public int targetScene; //Change to the scene number in the build settings, refer to the README for the number
    public GameObject winUI;
    public GameObject playUI;

    // Start is called before the first frame update
    void Start()
    {
        winUI.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        playUI.SetActive(false);
        winUI.SetActive(true);
        Time.timeScale = 0f; //Should freeze all objects and animations
        Cursor.lockState = CursorLockMode.None; //Unlocks the cursor to allow inteacting with the menu
        Cursor.visible = true; //Unhides the cursor
    }

    public void ContinueButton ()
    {
        Time.timeScale = 1.0f; //Should unfreeze all objects and animations
        SceneManager.LoadScene(targetScene); //Loads the next scene when a button is clicked
    }
}
