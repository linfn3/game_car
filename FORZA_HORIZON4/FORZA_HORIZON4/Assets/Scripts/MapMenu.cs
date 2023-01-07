using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapMenu : MonoBehaviour
{
    public void Track()
    {
        SceneManager.LoadScene(2);

    }

    public void NewYork()
    {
        SceneManager.LoadScene(3);
    }



}
