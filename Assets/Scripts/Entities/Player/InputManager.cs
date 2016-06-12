using UnityEngine;
using System.Collections;

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
#endif

#if UNITY_ANDROID

#endif

#if UNITY_IOS

#endif
    }
}
