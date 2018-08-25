using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStartFadeIn : MonoBehaviour
{
    public Image Panel;
    public float FadeDuration = 10.0f;

	// Use this for initialization
	void Start ()
	{
	    Panel.enabled = true;
	    Panel.CrossFadeAlpha(0.0f, FadeDuration, true);
	}
}
