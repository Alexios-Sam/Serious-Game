using UnityEngine;
using System.Collections;

public class FpsDisplay : MonoBehaviour
{
    public float FrameCountPerSecond = 10.0f;

    private float deltaTime;

    private void Start()
    {
        InvokeRepeating("FCPS", 0.0f, 1/FrameCountPerSecond);
    }

    void FCPS()
    {
        deltaTime = Time.deltaTime;
    }
	
	void OnGUI()
	{
		int w = Screen.width, h = Screen.height;
		
		GUIStyle style = new GUIStyle();
		
		Rect rect = new Rect(0, 0, w, h * 2 / 100);
		style.alignment = TextAnchor.UpperLeft;
		style.fontSize = h * 2 / 100;
		style.normal.textColor = new Color (1, 1, 1, 1);
		float msec = deltaTime * 1000.0f;
		float fps = 1.0f / deltaTime;
		string text = string.Format("{0:0.0} ms ({1:0.} fps)", msec, fps);
		GUI.Label(rect, text, style);
	}
}