using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NavigateUI : MonoBehaviour
{
    [Header("Menus")]
    [SerializeField] GameObject gameMenu;
    [SerializeField] GameObject optionsMenu;
    [SerializeField] GameObject gameOverMenu;
    [Header("Audio Sources")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource[] tattieSources;
    GameObject[] fxSources;
    [Header("Sliders")]
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider fxSlider;
    [Header("Texts")]
    [SerializeField] Text musicVolumeText;
    [SerializeField] Text fxVolumeText;
    AudioSource[] enemySounds;
    // Start is called before the first frame update
    void Start()
    {
        fxSources = GameObject.FindGameObjectsWithTag("Enemy");

        gameMenu.SetActive(false);
        optionsMenu.SetActive(false);
        gameOverMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        CursorBehavior();
        if (Input.GetKeyDown(KeyCode.P) && gameMenu.activeSelf == false)
        {
            gameMenu.SetActive(true);

        }
        else if (Input.GetKeyDown(KeyCode.P) && gameMenu.activeSelf == true)
        {
            gameMenu.SetActive(false);

        }
        AdjustVolumeSliders();

    }

    private void AdjustVolumeSliders()
    {
        musicSource.volume = musicSlider.value / 100;
        musicVolumeText.text = string.Format("{0}/{1}", musicSlider.value, musicSlider.maxValue);

        foreach (GameObject e in fxSources)
        {
            if (e != null)
            {
                e.GetComponent<AudioSource>().volume = fxSlider.value / 100;
            }

        }
        tattieSources[0].volume = fxSlider.value / 100;
        tattieSources[1].volume = fxSlider.value / 400;
        fxVolumeText.text = string.Format("{0}/{1}", fxSlider.value, fxSlider.maxValue);


    }

    public void CursorBehavior()
    {
        if (gameMenu.activeSelf == true)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(0);
    }

    public void ShowOptionsMenu()
    {
        optionsMenu.gameObject.SetActive(true);
    }
    public void ShowGameOverMenu()
    {
        gameOverMenu.gameObject.SetActive(true);
    }

    public void ExitOptionsMenu()
    {
        optionsMenu.gameObject.SetActive(false);
    }
    public void ExitGameMenu()
    {
        gameMenu.gameObject.SetActive(false);
    }
}
