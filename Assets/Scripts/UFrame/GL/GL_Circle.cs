using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class GL_Circle
{
    Vector3[] points;
    int pointIdx = 0;
    Vector3 center;
    Color color;
    public void Init(Vector3 center, float r, Color color)
    {
        this.center = center;
        this.color = color;
        points = new Vector3[361];

        CalcAllPoints(r);

    }

    float DegreetoRadians(float x)
    {
        return x * 0.017453292519943295769f;
    }

    float RadianstoDegrees(float x)
    {
        return x * 57.295779513082321f;
    }

    void AddPoint(Vector3 point)
    {
        points[pointIdx++] = point;
    }

    Vector3 GetPoint(int idx)
    {
        if (idx > 360)
            return Vector3.zero;

        return points[idx];
    }

    void CalcAllPoints(float r)
    {
        for (int i = 0; i <= 360; i++)
        {
            float XPos = Mathf.Sin(DegreetoRadians(i)) * r;
            float ZPos = Mathf.Cos(DegreetoRadians(i)) * r;

            Vector3 temp = new Vector3(center.x + XPos, center.y, center.z + ZPos);
            AddPoint(temp);
        }
    }

    public void RenderLines()
    {
        GL.Begin(GL.LINES);
        GL.Color(color);
        for (int i = 0; i < 360; ++i)
        {
            GL.Vertex(GetPoint(i));
            GL.Vertex(GetPoint(i + 1));
        }

        GL.End();
    }

}