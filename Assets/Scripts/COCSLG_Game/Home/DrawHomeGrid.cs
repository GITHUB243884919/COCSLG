using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace COCSLG_Game
{
    public class DrawHomeGrid : MonoBehaviour
    {
        //private GL_Circle circle;
        GL_Grid grid;
        Material lineMaterial;

        //public Vector3 center = Vector3.left;
        //public float cellSize = 1f;
        //public int gridSize = 4;

        ////static DrawHomeGrid instance;
        ////public static GL_DrawLine GetInstance()
        ////{
        ////    return instance;
        ////}

        ////void Awake()
        ////{
        ////    instance = this;
        ////}

        ///// <summary>
        ///// 世界坐标转格子坐标
        ///// </summary>
        ///// <param name="worldPos"></param>
        ///// <returns></returns>
        //public Vector3 WorldPosToGridPos(Vector3 worldPos)
        //{
        //    Vector3 result = worldPos;
        //    result.x -= center.x;
        //    result.x /= cellSize;

        //    result.z -= center.z;
        //    result.z /= cellSize;
        //    return result;
        //}

        ///// <summary>
        ///// 格子坐标转到cell的中心的世界坐标
        ///// </summary>
        ///// <param name="gridPos"></param>
        ///// <returns></returns>
        //public Vector3 GridPosToCellCenterInWorld(Vector3 gridPos)
        //{
        //    Vector3 result = gridPos;
        //    Debug.Log("gridPos " + gridPos + Mathf.Floor(1f) + " " + Mathf.Floor(-0.1f) + " " + (int)(-0.1f));
        //    if ((gridSize & 1) == 0)
        //    {
        //        result.x = center.x + Mathf.Floor(result.x) * cellSize + cellSize * 0.5f;
        //        result.z = center.z + Mathf.Floor(result.z) * cellSize + cellSize * 0.5f;
        //    }
        //    else
        //    {
        //        result.x = center.x + Mathf.Round(result.x) * cellSize;
        //        result.z = center.z + Mathf.Round(result.z) * cellSize;
        //    }
        //    return result;
        //}

        void Start()
        {
            //circle = new GL_Circle();
            //circle.Init(Vector3.zero, 4.0f, Color.red);

            grid = new GL_Grid();
            grid.Init(HomeGridManager.GetInstance().center, 
                HomeGridManager.GetInstance().cellSize,
                HomeGridManager.GetInstance().gridSize,
                HomeGridManager.GetInstance().color);

            lineMaterial = new Material(Shader.Find("Custom/Colored_Blended"));
            lineMaterial.hideFlags = HideFlags.HideAndDontSave;
            lineMaterial.shader.hideFlags = HideFlags.HideAndDontSave;
        }

        void OnPostRender()
        {
            lineMaterial.SetPass(0);
            GL.PushMatrix();
            //circle.RenderLines();
            grid.RenderLines();
            GL.PopMatrix();
        }
    }

}
