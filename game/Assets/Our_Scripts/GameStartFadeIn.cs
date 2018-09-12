using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStartFadeIn : MonoBehaviour
{
    public float FadeDuration = 10.0f;
    public Color StartColor = Color.black;
    public Color EndColor = Color.clear;

    public Incriment[] Incriments;
    public float LastIncrimentSpeed = 2.0f;

    [System.Serializable]
    public class Incriment
    {
        [Range(0.0f, 1.0f)]
        public float IncrimentEnd = 0.5f;
        public float IncrimentSpeed = 0.5f;
    }

    private int index;

    private Image panel;
    private float t;

    // Use this for initialization
    void Start()
    {
        panel = GetComponent<Image>();
        panel.enabled = true;
    }

    private void Update()
    {
        panel.color = Color.Lerp(StartColor, EndColor, t);

        if (Incriments.Length <= 0)
        {
            t += Time.deltaTime / FadeDuration;
        }
        else if (t < Incriments[index].IncrimentEnd)
        {
            t += Time.deltaTime / FadeDuration * Incriments[index].IncrimentSpeed;
        }
        else
        {
            if (Incriments.Length - 1 > index)
            {
                index++;
                t += Time.deltaTime / FadeDuration * Incriments[index].IncrimentSpeed;
            }
            else
            {
                t += Time.deltaTime / FadeDuration * LastIncrimentSpeed;
            }
        }
    }
}