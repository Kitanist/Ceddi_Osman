using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSkip : MonoBehaviour
{

float videoSuresi;

void Start()
{
    StartCoroutine(VideoManager());
}

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    IEnumerator VideoManager()
{

     
    yield return new WaitForSeconds(60.5f);

    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
}
}
