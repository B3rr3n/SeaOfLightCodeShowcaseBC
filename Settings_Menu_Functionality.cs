using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//Refernces
//www.youtube.com/watch?v=T2tyoB5iwT8 - followed this for Brightness
//forum.unity.com/threads/beginner-question-about-toggle-fullscreen-and-window-mode.484632/ - followed this for Full Screen Toggle
//docs.unity3d.com/ScriptReference/PlayerPrefs.SetFloat.html#:~:text=SetFloat%20as%20an%20identifier%2C%20and,CharacterHealth”%2C%2060.5f)%2F - Player Prefs documentation

public class Settings_Menu_Functionality : MonoBehaviour
{
    public static Slider brightnessSlider; //The slider that controls brightness
    public Light sceneLight; //The scene light
    public static bool fullScreen = true; //checks if application is fullscreen or not
    public int Brightness; //Used for Player Prefs
    public string playerBrightness; //Used for Player Prefs
    public AudioSource pageTurn;

    void Start()
    {
        brightnessSlider = Component.FindObjectOfType<Slider>(); //Finds the slider object
        float savedBrightness = PlayerPrefs.GetFloat(playerBrightness, 0); // Default value is 0 if not found, retreives the player prefs for brightness
        brightnessSlider.value = savedBrightness / 100.0f; //Changes savedBrightness to a usable value for the slider
        sceneLight.intensity = brightnessSlider.value; //Uses a slider to change the brightness from a range of 0 to 1
    }

    void Update()
    {
        sceneLight.intensity = brightnessSlider.value; //Uses a slider to change the brightness from a range of 0 to 1
        //Is called each frame for player feedback
    }

    public void MainMenu()
    {
        StartCoroutine(MainMenuSound());
        //Brightness = Mathf.RoundToInt(brightnessSlider.value * 100); //Easier to save a number with no decimal points
        //SetFloat(Brightness); //Calls the SetFloat fucntion
        //SceneManager.LoadScene(0); //Scene 0 should be the main menu in the build settings
    }

    public void ToggleFullScreen()
    {
        Screen.fullScreen = !Screen.fullScreen; //Inverses the screen state when activated
        fullScreen = !fullScreen; //Inverse the tick state when activated
    }

    public void SetFloat(int Brightness)
    {
        PlayerPrefs.SetFloat(playerBrightness, Brightness); //Sets the brightness value externally before loading the next scene so it carries over
        PlayerPrefs.Save(); //Saves the value
        Debug.Log("Settings Saved"); //Used for testing
    }

    IEnumerator MainMenuSound()
    {
        //Gets the length of the sound clip then plays the sound
        float pageduration = pageTurn.clip.length;
        pageTurn.PlayOneShot(pageTurn.clip);
        Brightness = Mathf.RoundToInt(brightnessSlider.value * 100); //Easier to save a number with no decimal points
        SetFloat(Brightness); //Calls the SetFloat fucntion

        //Starts to load scene in the background 
        AsyncOperation sceneLoading = SceneManager.LoadSceneAsync("main menu");
        //Stops the scene from loading by keeping it inactive
        sceneLoading.allowSceneActivation = false;

        //Pauses for duration of sound clip before moving to next line
        yield return new WaitForSeconds(pageduration);

        while (sceneLoading.progress < 0.9f) yield return null;

        sceneLoading.allowSceneActivation = true;
    }

}
