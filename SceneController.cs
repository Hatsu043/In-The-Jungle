using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            SceneManager.LoadScene("L1");
        }
        else if (Input.GetKeyDown("2"))
        {
            SceneManager.LoadScene("Menu");
        }
        else if (Input.GetKeyDown("3"))
        {
            SceneManager.LoadScene("Win");
        }
        else if (Input.GetKeyDown("4"))
        {
            SceneManager.LoadScene("Lose");
        }


        if (Input.GetKeyDown("5"))
        {
            audioSource.PlayOneShot(SoundManager.Instance.GameOver);
        }
        else if (Input.GetKeyDown("6"))
        {
            audioSource.PlayOneShot(SoundManager.Instance.Die);
        }
        else if (Input.GetKeyDown("7"))
        {
            audioSource.PlayOneShot(SoundManager.Instance.Newgame);
        }
    }
}
