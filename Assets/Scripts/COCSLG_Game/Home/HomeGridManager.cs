using System.Collections;
using System.Collections.Generic;
using UFrame.Common;
using UnityEngine;

namespace COCSLG_Game
{
    public class HomeGridManager : Singleton<HomeGridManager>, ISingleton
    {
        public void Init()
        {
        }

        public Vector3 center = Vector3.zero;
        public float cellSize = 1f;
        public int gridSize = 4;
        public Color color = Color.green;
        /// <summary>
        /// 世界坐标转格子坐标
        /// </summary>
        /// <param name="worldPos"></param>
        /// <returns></returns>
        public Vector3 WorldPosToGridPos(Vector3 worldPos)
        {
            Vector3 result = worldPos;
            result.x -= center.x;
            result.x /= cellSize;

            result.z -= center.z;
            result.z /= cellSize;
            return result;
        }

        /// <summary>
        /// 格子坐标转到cell的中心的世界坐标
        /// </summary>
        /// <param name="gridPos"></param>
        /// <returns></returns>
        public Vector3 GridPosToCellCenterInWorld(Vector3 gridPos)
        {
            Vector3 result = gridPos;
            Debug.Log("gridPos " + gridPos + Mathf.Floor(1f) + " " + Mathf.Floor(-0.1f) + " " + (int)(-0.1f));
            if ((gridSize & 1) == 0)
            {
                result.x = center.x + Mathf.Floor(result.x) * cellSize + cellSize * 0.5f;
                result.z = center.z + Mathf.Floor(result.z) * cellSize + cellSize * 0.5f;
            }
            else
            {
                result.x = center.x + Mathf.Round(result.x) * cellSize;
                result.z = center.z + Mathf.Round(result.z) * cellSize;
            }
            return result;
        }
    }
}

