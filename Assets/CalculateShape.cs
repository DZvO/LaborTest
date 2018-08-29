using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.UIElements;
using UnityEngine;

public class CalculateShape : MonoBehaviour {
    private double f(double x, double y)
    {
        return Math.Sin(x + y * y);
    }

	// Use this for initialization
	void Start ()
	{

	    MeshFilter m = GetComponent<MeshFilter>();
        Mesh mesh = m.mesh;
        List<Vector3> vertices = new List<Vector3>(100 * 100 * 6);
        List<int> triangles = new List<int>(100 * 100 * 6);
        for (int y = 0; y < 100; y++)
        {
            for (int x = 0; x < 100; x++)
            {
                Vector3 v1 = new Vector3();
                v1.x = x;
                v1.z = y;
                v1.y = (float)f(v1.x, v1.z);
                triangles.Add(vertices.Count);
                vertices.Add(v1);

                Vector3 v2 = new Vector3();
                v2.x = x + 1;
                v2.z = y + 1;
                v2.y = (float)f(v2.x, v2.z);
                triangles.Add(vertices.Count);
                vertices.Add(v2);

                Vector3 v3 = new Vector3();
                v3.x = x + 1;
                v3.z = y;
                v3.y = (float)f(v3.x, v3.z);
                triangles.Add(vertices.Count);
                vertices.Add(v3);

                Vector3 v4 = new Vector3();
                v4.x = x;
                v4.z = y;
                v4.y = (float)f(v4.x, v4.z);
                triangles.Add(vertices.Count);
                vertices.Add(v4);

                Vector3 v5 = new Vector3();
                v5.x = x;
                v5.z = y + 1;
                v5.y = (float)f(v5.x, v5.z);
                triangles.Add(vertices.Count);
                vertices.Add(v5);

                Vector3 v6 = new Vector3();
                v6.x = x + 1;
                v6.z = y + 1;
                v6.y = (float)f(v6.x, v6.z);
                triangles.Add(vertices.Count);
                vertices.Add(v6);
            }
        }

        mesh.vertices = vertices.ToArray();
        mesh.uv = null;
        mesh.normals = null;
        mesh.triangles = triangles.ToArray();



        //var mesh = new Mesh();
        //m.mesh = mesh;

        //var vertices = new Vector3[4];
        //for (int y = 0; y < 100; y++)
        //{
        //    for (int x = 0; x < 100; x++)
        //    {

        //    }
        //}
        //vertices[0] = new Vector3(0, 0, 0);
        //vertices[1] = new Vector3(100, 0, 0);
        //vertices[2] = new Vector3(0, 0, 100);
        //vertices[3] = new Vector3(100, 0, 100);

        //mesh.vertices = vertices;

        //var tri = new int[6];

        //tri[0] = 0;
        //tri[1] = 2;
        //tri[2] = 1;

        //tri[3] = 2;
        //tri[4] = 3;
        //tri[5] = 1;

        //mesh.triangles = tri;

        //var normals = new Vector3[4];

        //normals[0] = -Vector3.forward;
        //normals[1] = -Vector3.forward;
        //normals[2] = -Vector3.forward;
        //normals[3] = -Vector3.forward;

        //mesh.normals = normals;

        //var uv = new Vector2[4];

        //uv[0] = new Vector2(0, 0);
        //uv[1] = new Vector2(1, 0);
        //uv[2] = new Vector2(0, 1);
        //uv[3] = new Vector2(1, 1);

        //mesh.uv = uv;

        // mesh.UploadMeshData(true);
    }
	
	// Update is called once per frame
	void Update () {
	    MeshFilter m = GetComponent<MeshFilter>();
	    Mesh mesh = m.mesh;
	    List<Vector3> vertices = new List<Vector3>(100 * 100 * 6);
	    List<int> triangles = new List<int>(100 * 100 * 6);
	    for (int y = 0; y < 100; y++)
	    {
	        for (int x = 0; x < 100; x++)
	        {
	            Vector3 v1 = new Vector3();
	            v1.x = x;
	            v1.z = y;
	            v1.y = (float)f(v1.x, v1.z);
	            triangles.Add(vertices.Count);
	            vertices.Add(v1);

	            Vector3 v2 = new Vector3();
	            v2.x = x + 1;
	            v2.z = y + 1;
	            v2.y = (float)f(v2.x, v2.z);
	            triangles.Add(vertices.Count);
	            vertices.Add(v2);

	            Vector3 v3 = new Vector3();
	            v3.x = x + 1;
	            v3.z = y;
	            v3.y = (float)f(v3.x, v3.z);
	            triangles.Add(vertices.Count);
	            vertices.Add(v3);

	            Vector3 v4 = new Vector3();
	            v4.x = x;
	            v4.z = y;
	            v4.y = (float)f(v4.x, v4.z);
	            triangles.Add(vertices.Count);
	            vertices.Add(v4);

	            Vector3 v5 = new Vector3();
	            v5.x = x;
	            v5.z = y + 1;
	            v5.y = (float)f(v5.x, v5.z);
	            triangles.Add(vertices.Count);
	            vertices.Add(v5);

	            Vector3 v6 = new Vector3();
	            v6.x = x + 1;
	            v6.z = y + 1;
	            v6.y = (float)f(v6.x, v6.z);
	            triangles.Add(vertices.Count);
	            vertices.Add(v6);
	        }
	    }

	    mesh.vertices = vertices.ToArray();
	    mesh.uv = null;
	    mesh.normals = null;
	    mesh.triangles = triangles.ToArray();
    }
}
