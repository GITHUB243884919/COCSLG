using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class GL_Grid
{
    Vector3 center;
    Color color;
    float cellSize;
    int gridSize;

    float size;
    Vector3 deltaZ, deltaX;
    Vector3 dirZ, dirX, orgDir;
    Vector3 forwardSize, rightSize;
    public void Init(Vector3 center, float cellSize, int gridSize, Color color)
    {
        this.center = center;
        this.cellSize = cellSize;
        this.gridSize = gridSize;
        this.color = color;

        size = cellSize * gridSize;
        float halfSize = size * 0.5f;
        deltaZ = Vector3.right * cellSize;
        deltaX = Vector3.forward * cellSize;

        forwardSize = Vector3.forward * size;
        rightSize = Vector3.right * size;

        dirZ = center;
        dirZ.z -= halfSize;
        dirZ.x -= halfSize;
        dirX = dirZ;
        orgDir = dirZ;
    }

    public void RenderLines()
    {
        GL.Begin(GL.LINES);
        GL.Color(color);

        dirZ = orgDir;
        dirX = orgDir;

        for (int i = 0; i <= gridSize; i++)
        {
            GL.Vertex(dirZ);
            GL.Vertex(dirZ + forwardSize);
            dirZ += deltaZ;

            GL.Vertex(dirX);
            GL.Vertex(dirX + rightSize);
            dirX += deltaX;
        }

        GL.End();
    }

}