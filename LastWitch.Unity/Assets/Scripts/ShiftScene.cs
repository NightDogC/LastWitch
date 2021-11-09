using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShiftScene : MonoBehaviour
{
    public void ToHome()
    {
        SceneManager.LoadScene("Home");
    }
    public void ToWorld()
    {
        SceneManager.LoadScene("WorldMap");
    }
    public void ToPot()
    {
        SceneManager.LoadScene("Pot");
    }
    public void ToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
