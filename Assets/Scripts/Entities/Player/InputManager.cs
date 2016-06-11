using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour
{
    private PlayerController playerController;

    public KeyCode Left;
    public KeyCode Right;

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
        if (Input.GetKeyDown(Left))
        {
            playerController.Move("Left");
        }
        if (Input.GetKeyDown(Right))
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
