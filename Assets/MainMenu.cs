using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Option_Menu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Quit_App()
    {
        Debug.Log("Exiting App!");
        Application.Quit();
    }

    public void Back_action()
    {
        SceneManager.LoadScene(0);
    }

    public void AR_world_scene()
    {
        SceneManager.LoadScene(4);
    }

    public void Arena_scene()
    {
        SceneManager.LoadScene(2);
    }

    public void Bbit_scene()
    {
        SceneManager.LoadScene(5);
    }

    public void Extras_scene()
    {
        SceneManager.LoadScene(3);
    }

    public void Comics_scene()
    {
        SceneManager.LoadScene(6);
    }

    public void Animations_scene()
    {
        SceneManager.LoadScene(7);
    }

    public void Links_scene()
    {
        SceneManager.LoadScene(8);
    }

    public void Play_scene()
    {
        SceneManager.LoadScene(9);
    }

    public void About_scene()
    {
        SceneManager.LoadScene(10);
    }

    public void Game3D_scene()
    {
        SceneManager.LoadScene(11);
    }




}
