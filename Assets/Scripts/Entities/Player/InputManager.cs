using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class InputManager : MonoBehaviour
{
    private PlayerController playerController;

    public KeyCode Left1;
    public KeyCode Left2;
    public KeyCode Right1;
    public KeyCode Right2;

	void Awake ()
    {
        playerController = GetComponent<PlayerController>();
	}
	
	void Update ()
    {
        CheckForInput();
	}

    void CheckForInput()
    {

#if UNITY_EDITOR
        if (Input.GetKeyDown(Left1) || Input.GetKeyDown(Left2))
        {
            playerController.Move("Left");
        }
        if (Input.GetKeyDown(Right1) || Input.GetKeyDown(Right2))
        {
            playerController.Move("Right");
        }

        //Debug
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }
#endif

#if UNITY_ANDROID

        for (int i = 0; i < Input.touchCount; i++)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Began)
            {
                Vector3 touchVec = Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position);

                if (touchVec.x > 1)
                {
                    playerController.Move("Right");
                }
                else
                {
                    playerController.Move("Left");
                }
            }

        }   
#endif
    }
}
