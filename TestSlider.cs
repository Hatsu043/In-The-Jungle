using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TestSlider : MonoBehaviour
{
    public float TimeOut;

    void Update()
    {
        GetComponent<Slider>().value = 1f - (Time.timeSinceLevelLoad / TimeOut) ;
        if(Time.timeSinceLevelLoad >= TimeOut)
        {
            SceneManager.LoadScene("Lose");
        }

    }
}
