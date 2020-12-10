using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    public int Level;

    //called OnClick()
    public void ChooseLevel()
    {
        SceneManager.LoadScene(Level);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
