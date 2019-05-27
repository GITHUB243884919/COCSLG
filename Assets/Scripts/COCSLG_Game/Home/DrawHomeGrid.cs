using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace COCSLG_Game
{
    /// <summary>
    /// 使用的GL画线，必须挂在相机上
    /// </summary>
    [ExecuteInEditMode]
    public class DrawHomeGrid : MonoBehaviour
    {
        GL_Grid grid;
        Material lineMaterial;
        bool isInit = false;
        void Start()
        {
            
            //grid.Init(HomeGridManager.GetInstance().center, 
            //    HomeGridManager.GetInstance().cellSize,
            //    HomeGridManager.GetInstance().gridSize,
            //    HomeGridManager.GetInstance().color);

            lineMaterial = new Material(Shader.Find("Custom/Colored_Blended"));
            lineMaterial.hideFlags = HideFlags.HideAndDontSave;
        }

        void Update()
        {
            if (HomeGridManager.GetInstance().couldDraw && !isInit)
            {
                grid = new GL_Grid();
                grid.Init(HomeGridManager.GetInstance().center,
                    HomeGridManager.GetInstance().cellSize,
                    HomeGridManager.GetInstance().gridSize,
                    HomeGridManager.GetInstance().color);
                isInit = true;
            }
        }

        void OnPostRender()
        {
            if (isInit)
            {
                lineMaterial.SetPass(0);
                GL.PushMatrix();
                grid.RenderLines();
                GL.PopMatrix();
            }

        }
    }

}
