using UnityEngine;
using System.Collections;

public class Planet : MonoBehaviour
{
    public Material PlanetMaterial;

    public float hdrExposure = 1.0f;

    private const float kr = 0.0025f;
    private const float km = 0.0010f;
    private const float outerScaleFactor = 1.015f;
    private float innerRadius;
    private float outerRadius;
    private const float scaleDepth = 0.25f;
    private float scale;
    private float gamma = 1.0f;

    private void Start()
    {
        if (QualitySettings.activeColorSpace == ColorSpace.Gamma)
        {
            gamma = 2.2f;
#if UNITY_EDITOR_OSX
				gamma = 1.8f;
#endif
#if UNITY_STANDALONE_OSX
				gamma = 1.8f;
#endif
        }
        innerRadius = transform.localScale.x;
        outerRadius = outerScaleFactor * transform.localScale.x;

        scale = 1.0f / (outerRadius - innerRadius);
        if (PlanetMaterial)
            InitMaterial(PlanetMaterial);
    }

    private void InitMaterial(Material mat)
    {
        mat.SetFloat("_Gamma", gamma);
        mat.SetFloat("fOuterRadius", outerRadius);
        mat.SetFloat("fInnerRadius", innerRadius);
        mat.SetFloat("fKr4PI", kr * 4.0f * Mathf.PI);
        mat.SetFloat("fKm4PI", km * 4.0f * Mathf.PI);
        mat.SetFloat("fScale", scale);
        mat.SetFloat("fScaleDepth", scaleDepth);
        mat.SetFloat("fScaleOverScaleDepth", scale / scaleDepth);
        mat.SetFloat("fHdrExposure", hdrExposure);
        mat.SetVector("v3Translate", transform.position);
    }
}

