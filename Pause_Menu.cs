using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//References
//www.youtube.com/watch?v=JivuXdrIHK0 - followed this to make the menu
//docs.unity3d.com/ScriptReference/PlayerPrefs.SetFloat.html#:~:text=SetFloat%20as%20an%20identifier%2C%20and,CharacterHealth”%2C%2060.5f)%2F - Player Prefs documentation

public class Pause_Menu : MonoBehaviour
{

    public static bool gameIsPaused = false; //For if the game is cuurently paused or not
    public GameObject pauseMenuUI; //The object for the pause menu UI
    public GameObject settingsMenuUI; //The object for the settings menu UI
    public AudioSource bookClose;
    public AudioSource pageTurn;
    public GameObject playUI;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenuUI.SetActive(false); //Hides the pause UI on scene start
        settingsMenuUI.SetActive(false); //Hides the setting UI on scene start
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) //Always cheching for the escape key
        {
            if (gameIsPaused) //If esc is pressed while gameIsPaused = true Resume() is called
            {
                Resume();
            }
            else //If esc is pressed while gameIsPaused = false Paused() is called
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        bookClose.Play();
        pauseMenuUI.SetActive(false); //Hides the pause UI
        settingsMenuUI.SetActive(false); //Hides the settings UI
        playUI.SetActive(true);
        Time.timeScale = 1.0f; //Should unfreeze all objects and animations
        gameIsPaused = false;
    }

    void Pause()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        bookClose.Play();
        pauseMenuUI.SetActive(true); //Shows the pause UI
        playUI.SetActive(false);
        Time.timeScale = 0f; //Should freeze all objects and animations
        gameIsPaused = true;
    }

    public void MainMenu()
    {
        StartCoroutine(MainMenuSound());
    }

    public void Settings()
    {
        pageTurn.Play();
        pauseMenuUI.SetActive(false); //Hides the pause UI
        settingsMenuUI.SetActive(true); //Shows the setting UI
    }

    public void QuitGame()
    {
        Application.Quit(); //Closes the game, doesn't work outside of a build

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
}