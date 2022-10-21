using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    private int[] levels;
    // Start is called before the first frame update
    void Start()
    {
        levels = new int[SceneManager.sceneCountInBuildSettings - 1];
        for (int i = 0; i < levels.Length; i++)       
        {
         
        }
    }



}
