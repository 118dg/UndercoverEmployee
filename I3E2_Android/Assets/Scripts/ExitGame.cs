using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitGame : MonoBehaviour
{
	public Image image;
	public bool disable;

	public void exitGameOnClick()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }

	float time;

	// Update is called once per frame
	void Update()
	{
        if (!disable)
        {
			if (time < 0.5f)
			{
				image.color = new Color(0, 0, 0, 1);
			}
			else
			{
				image.color = new Color(1, 0, 0, 1);
				if (time > 1f)
				{
					time = 0;
				}
			}
			time += Time.deltaTime;

		}

	}

}
