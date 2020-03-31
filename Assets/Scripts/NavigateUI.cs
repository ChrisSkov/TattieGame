using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NavigateUI : MonoBehaviour
{
    [SerializeField] GameObject gameMenu;
    // Start is called before the first frame update
    void Start()
    {
        
        gameMenu.SetActive(false);
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
    }
    void CursorBehavior()
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
}
