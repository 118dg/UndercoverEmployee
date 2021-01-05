using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGame : MonoBehaviour
{
    public void exitGameOnClick()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
