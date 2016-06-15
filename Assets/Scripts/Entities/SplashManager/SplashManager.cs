using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SplashManager : MonoBehaviour
{
    public float splashTime = 10f;	
	
	void Update ()
    {
        splashTime -= Time.deltaTime;

        if (splashTime < 0)
        {
            SceneManager.LoadScene(01);
        }
	}
}
