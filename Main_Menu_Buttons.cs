using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//Refernces
//docs.unity3d.com/ScriptReference/PlayerPrefs.SetFloat.html#:~:text=SetFloat%20as%20an%20identifier%2C%20and,CharacterHealth”%2C%2060.5f)%2F - Player Prefs documentation
//discussions.unity.com/t/how-to-play-a-sound-when-a-prefab-button-that-changes-scene-is-clicked/211760/4 - Get button to play sound before switching scene
public class Main_Menu_Buttons : MonoBehaviour
{

    public static Slider brightnessSlider; //The slider that controls brightness
    public GameObject Slider; //The object for the slider, allows it to be hidden
    public float Brightness; //Used for Player Prefs
    public string playerBrightness; //Used for Player Prefs
    public Light sceneLight; //The scene light
    public AudioSource pageTurn;
    public AudioSource bookClose;
    public bool buttonPressed = false;

    private void Start()
    {
        brightnessSlider = FindObjectOfType<Slider>(); //Finds the slider object
        Slider.SetActive(false); //Hides the slider as the player doesn't need to interact with it on this screen
        float savedBrightness = PlayerPrefs.GetFloat(playerBrightness, 0); // Default value is 0 if not found, retreives the player prefs for brightness
        brightnessSlider.value = savedBrightness / 100.0f; //Changes savedBrightness to a usable value for the slider
        sceneLight.intensity = brightnessSlider.value; //Uses a slider to change the brightness from a range of 0 to 1
    }

    public void StartGame()
    {
        if (buttonPressed == false)
        {
            buttonPressed = true;
            StartCoroutine(StartSound());
        }
        else 
        { 

        }
    }

    public void Speedrun()
    {
        if (buttonPressed == false)
        {
            buttonPressed = true;
            StartCoroutine(SpeedrunSound());

        }
        else
        {

        }
    }


    public void Settings()
    {
        if (buttonPressed ==false)
        {
            buttonPressed = true;
            StartCoroutine(SettingSound());
        }
        else
        {

        }
    }

    public void QuitGame()
    {
        if (buttonPressed == false)
        {
            Application.Quit();
            Debug.Log("Quit"); //Used for testing the quit button
        }
        else
        {

        }
    }


    IEnumerator StartSound()
    {
        //Gets the length of the sound clip then plays the sound
        float pageduration = pageTurn.clip.length;
        pageTurn.PlayOneShot(pageTurn.clip);

        //Starts to load scene in the background 
        AsyncOperation sceneLoading = SceneManager.LoadSceneAsync(2);
        //Stops the scene from loading by keeping it inactive
        sceneLoading.allowSceneActivation = false;

        //Pauses for duration of sound clip before moving to next line
        yield return new WaitForSeconds(pageduration);

        while (sceneLoading.progress < 0.9f) yield return null;

        sceneLoading.allowSceneActivation = true;
    }

    IEnumerator SpeedrunSound()
    {
        //Gets the length of the sound clip then plays the sound
        float pageduration = pageTurn.clip.length;
        pageTurn.PlayOneShot(pageTurn.clip);

        AsyncOperation sceneLoading = SceneManager.LoadSceneAsync(5);
        sceneLoading.allowSceneActivation = false;

        //Pauses for duration of sound clip before moving to next line
        yield return new WaitForSeconds(pageduration);

        while (sceneLoading.progress < 0.9f) yield return null;

        sceneLoading.allowSceneActivation = true;
    }

    IEnumerator SettingSound()
    {
        //Gets the length of the sound clip then plays the sound
        float pageduration = pageTurn.clip.length;
        pageTurn.PlayOneShot(pageTurn.clip);

        AsyncOperation sceneLoading = SceneManager.LoadSceneAsync(1);
        sceneLoading.allowSceneActivation = false;

        //Pauses for duration of sound clip before moving to next line
        yield return new WaitForSeconds(pageduration);

        while (sceneLoading.progress < 0.9f) yield return null;

        sceneLoading.allowSceneActivation = true;
    }

}
