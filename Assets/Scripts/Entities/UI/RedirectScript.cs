using UnityEngine;
using System.Collections;

public class RedirectScript : MonoBehaviour
{
    public void RedirectToWebsite()
    {
        Application.OpenURL ("http://www.chronoblastgames.com/");
        Debug.Log("Opening Website");
    }

    public void RedirectToTwitter()
    {
        Application.OpenURL("https://twitter.com/chronoblast");
        Debug.Log("Opening Twitter");
    }

    public void RedirectToMusic()
    {
        Application.OpenURL("https://ourmusicbox.com/");
        Debug.Log("Opening Music Page");
    }
}
