using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    public void Lv1()
    {
        SceneManager.LoadScene("lvl_1");
    }
    public void Lv2()
    {
        SceneManager.LoadScene("lvl_2");
    }
    public void Lv3()
    {
        SceneManager.LoadScene("lvl_3");
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene("menu");
    }
}
