using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject losePannel;
    public GameObject winPannel;
    public GameObject pausePannel;
    public GameObject joystick;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        EventHandler.onWin.AddListener(Won);
        EventHandler.onFail.AddListener(Failed);
    }
    void Won()
    {
        joystick.SetActive(false);
        Time.timeScale = 0;
        winPannel.SetActive(true);
    }    
    void Failed()
    {
        joystick.SetActive(false);
        Time.timeScale = 0;
        losePannel.SetActive(true);

    }
    
    public void NextLevel()
    {
        if ((SceneManager.GetActiveScene().buildIndex + 1) < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }
        
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void BackHome()
    {
        SceneManager.LoadScene(0);
    }
    
    public void Pause()
    {
        Time.timeScale = 0;
        pausePannel.SetActive(true);
        joystick.SetActive(false);
    }
    public void Continue()
    {
        Time.timeScale = 1;
        pausePannel.SetActive(false);
        joystick.SetActive(true);
    }
}
