using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pause_Settings_Menu : MonoBehaviour
{

    public AudioSource bookClose;
    public AudioSource pageTurn;

    public Slider brightnessSlider; //The slider that controls brightness
    public float Brightness; //Used for Player Prefs
    public string playerBrightness; //Used for Player Prefs
    public Light sceneLight; //The scene light
    public static bool fullScreen = true; //checks if application is fullscreen or not

    public GameObject pauseMenuUI; //The object for the pause menu UI
    public GameObject settingsMenuUI; //The object for the settings menu UI
    public GameObject Slider; //The object for the slider, allows it to be hidden

    // Start is called before the first frame update
    void Start()
    {
        float savedBrightness = PlayerPrefs.GetFloat(playerBrightness, 0); // Default value is 0 if not found, retreives the player prefs for brightness
        brightnessSlider.value = savedBrightness / 100.0f; //Changes savedBrightness to a usable value for the slider
        sceneLight.intensity = brightnessSlider.value; //Uses a slider to change the brightness from a range of 0 to 1
    }

    // Update is called once per frame
    void Update()
    {
        sceneLight.intensity = brightnessSlider.value; //Uses a slider to change the brightness from a range of 0 to 1
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

    public void Back()
    {
        StartCoroutine(BackSound());
    }

    IEnumerator BackSound()
    {
        //Gets the length of the sound clip then plays the sound
        float pageduration = pageTurn.clip.length;
        pageTurn.PlayOneShot(pageTurn.clip);

        Brightness = Mathf.RoundToInt(brightnessSlider.value * 100); //Easier to save a number with no decimal points
        SetFloat((int)Brightness); //Calls the SetFloat fucntion
        sceneLight.intensity = brightnessSlider.value; //Uses a slider to change the brightness from a range of 0 to 1

        pauseMenuUI.SetActive(true);
        settingsMenuUI.SetActive(false);

        //Pauses for duration of sound clip before moving to next line
        yield return new WaitForSeconds(pageduration);
    }
}
