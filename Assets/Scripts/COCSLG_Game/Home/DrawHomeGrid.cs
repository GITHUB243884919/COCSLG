using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace COCSLG_Game
{
    public class DrawHomeGrid : MonoBehaviour
    {
        GL_Grid grid;
        Material lineMaterial;

        void Start()
        {
            grid = new GL_Grid();
            grid.Init(HomeGridManager.GetInstance().center, 
                HomeGridManager.GetInstance().cellSize,
                HomeGridManager.GetInstance().gridSize,
                HomeGridManager.GetInstance().color);

            lineMaterial = new Material(Shader.Find("Custom/Colored_Blended"));
            lineMaterial.hideFlags = HideFlags.HideAndDontSave;
            //lineMaterial.shader.hideFlags = HideFlags.None;
        }

        void OnPostRender()
        {
            lineMaterial.SetPass(0);
            GL.PushMatrix();
            grid.RenderLines();
            GL.PopMatrix();
        }
    }

}
