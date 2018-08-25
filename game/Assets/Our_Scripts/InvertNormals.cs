using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Original Creator of Script Joachim Ante
//http://wiki.unity3d.com/index.php?title=ReverseNormals

[RequireComponent(typeof(MeshFilter))]
public class InvertNormals : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
	    Mesh mesh = GetComponent<MeshFilter>().mesh;

	    Vector3[] normals = mesh.normals;
	    for (int i = 0; i < normals.Length; i++)
	    {
	        normals[i] = -normals[i];
	    }

	    mesh.normals = normals;

	    for (int i = 0; i < mesh.subMeshCount; i++)
	    {
	        int[] tris = mesh.GetTriangles(i);
	        for (int j = 0; j < tris.Length; j+=3)
	        {
	            int temp = tris[j];
	            tris[j] = tris[j + 1];
	            tris[j + 1] = temp;
	        }

            mesh.SetTriangles(tris, i);
	    }
	}
}
