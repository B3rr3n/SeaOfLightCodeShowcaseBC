using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Speedrun_Scene : MonoBehaviour
{
    public static Slider brightnessSlider; //The slider that controls brightness
    public GameObject Slider; //The object for the slider, allows it to be hidden
    public float Brightness; //Used for Player Prefs
    public string playerBrightness; //Used for Player Prefs
    public Light sceneLight; //The scene light
    public AudioSource pageTurn;
    public AudioSource bookClose;
    public bool buttonPressed = false;

    // Start is called before the first frame update
    void Start()
    {
        brightnessSlider = FindObjectOfType<Slider>(); //Finds the slider object
        Slider.SetActive(false); //Hides the slider as the player doesn't need to interact with it on this screen
        float savedBrightness = PlayerPrefs.GetFloat(playerBrightness, 0); // Default value is 0 if not found, retreives the player prefs for brightness
        brightnessSlider.value = savedBrightness / 100.0f; //Changes savedBrightness to a usable value for the slider
        sceneLight.intensity = brightnessSlider.value; //Uses a slider to change the brightness from a range of 0 to 1
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Level1()
    {
        if (buttonPressed == false)
        {
            buttonPressed = true;
            StartCoroutine(Level1Sound());
        }
        else
        {

        }
    }

    public void Level2()
    {
        if (buttonPressed == false)
        {
            buttonPressed = true;
            StartCoroutine(Level2Sound());
        }
        else
        {

        }
    }

    public void MainMenu()
    {
        if (buttonPressed == false)
        {
            buttonPressed = true;
            StartCoroutine(MainMenuSound());
        }
        else
        {

        }
    }

    IEnumerator MainMenuSound()
    {
        //Gets the length of the sound clip then plays the sound
        float pageduration = pageTurn.clip.length;
        pageTurn.PlayOneShot(pageTurn.clip);

        //Starts to load scene in the background 
        AsyncOperation sceneLoading = SceneManager.LoadSceneAsync(0);
        //Stops the scene from loading by keeping it inactive

        Debug.Log("Waiting");
        yield return new WaitForSeconds(pageduration);

        sceneLoading.allowSceneActivation = false;

        //Pauses for duration of sound clip before moving to next line

        while (sceneLoading.progress < 0.9f) yield return null;
        Debug.Log(sceneLoading.progress);

        sceneLoading.allowSceneActivation = true;
    }

    IEnumerator Level1Sound()
    {
        //Gets the length of the sound clip then plays the sound
        float pageduration = pageTurn.clip.length;
        pageTurn.PlayOneShot(pageTurn.clip);

        //Starts to load scene in the background 
        AsyncOperation sceneLoading = SceneManager.LoadSceneAsync(6);
        //Stops the scene from loading by keeping it inactive

        Debug.Log("Waiting");
        yield return new WaitForSeconds(pageduration);

        sceneLoading.allowSceneActivation = false;

        //Pauses for duration of sound clip before moving to next line

        while (sceneLoading.progress < 0.9f) yield return null;
        Debug.Log(sceneLoading.progress);

        sceneLoading.allowSceneActivation = true;
    }

    IEnumerator Level2Sound()
    {
        //Gets the length of the sound clip then plays the sound
        float pageduration = pageTurn.clip.length;
        pageTurn.PlayOneShot(pageTurn.clip);

        //Starts to load scene in the background 
        AsyncOperation sceneLoading = SceneManager.LoadSceneAsync(7);
        //Stops the scene from loading by keeping it inactive

        Debug.Log("Waiting");
        yield return new WaitForSeconds(pageduration);

        sceneLoading.allowSceneActivation = false;

        //Pauses for duration of sound clip before moving to next line

        while (sceneLoading.progress < 0.9f) yield return null;
        Debug.Log(sceneLoading.progress);

        sceneLoading.allowSceneActivation = true;
    }

}
