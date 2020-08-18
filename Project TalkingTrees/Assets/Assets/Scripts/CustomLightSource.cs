using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomLightSource : MonoBehaviour
{
    [SerializeField]
    public int RayCount = 90;
    [SerializeField]
    public float FOV = 90f;
    [SerializeField]
    public float ViewDistance = 3;

    private static Vector3 GetVectorFromAngle(float angle)
    {
        float angleRad = angle * (Mathf.PI / 180f);
        return new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
    }

    void Update()
    {
        Mesh mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        Vector3 origin = Vector3.zero;
        Vector3[] vertices = new Vector3[RayCount + 2];
        Vector2[] uv = new Vector2[vertices.Length];
        int[] triangles = new int[RayCount * 3];

        vertices[0] = origin;
        float angle = 0f;
        int vertexIndex = 1, triangleIndex = 0;
        float angleChange = FOV / RayCount;
        for (int i = 0; i <= RayCount; i++)
        {
            Vector3 vecAng = /*(Input.mousePosition - origin).normalized;*/GetVectorFromAngle(angle);
            Vector3 vertex;
            RaycastHit2D rayHit = Physics2D.Raycast(origin, vecAng, ViewDistance);
            if(rayHit.collider == null)
            {
                vertex = origin + vecAng * ViewDistance;
            } else
            {
                vertex = rayHit.point;
            }
            vertices[vertexIndex] = vertex;
            if (i > 0)
            {
                triangles[triangleIndex + 0] = 0;
                triangles[triangleIndex + 1] = vertexIndex - 1;
                triangles[triangleIndex + 2] = vertexIndex;
                triangleIndex += 3;
            }
            vertexIndex++;
            angle -= angleChange;
        }

        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;

    }
    //[SerializeField]
    //private float _width; //Angle in degrees
    //[SerializeField]
    //private float _strength; //Strength of light


    //public float Width
    //{
    //    get => _width;
    //    set => _width = value < 360f ? value : 360f;
    //}
    //public float Strength
    //{
    //    get => _strength;
    //    set => _strength = value;
    //}
}
