using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UFrame.ResourceManagement;
using System.IO;
using UFrame.Common;

namespace COCSLG_Game
{
    public class HomeManager : Singleton<HomeManager>, ISingleton
    {
        Transform homeBuildingRoot;
        public void Init()
        {
            InitHomeGrid();
            InitHomeBuilding();
        }

        void InitHomeGrid()
        {
            HomeGridManager.GetInstance().center = Vector3.zero;
            HomeGridManager.GetInstance().cellSize = 1;
            HomeGridManager.GetInstance().gridSize = 100;
            HomeGridManager.GetInstance().color = Color.green;
            HomeGridManager.GetInstance().couldDraw = true;
        }

        void InitHomeBuilding()
        {
            if (homeBuildingRoot == null)
            {
                homeBuildingRoot = GameObject.Find("home_root/homebuilding_root").transform;

            }
            var getter = ResHelper.LoadGameObject("prefabs/homebuilding/homebuilding");
            var go = getter.Get();
            go.transform.SetParent(homeBuildingRoot);
            go.transform.position = new Vector3(50, 0, -20);

            HomeBuildingManager.GetInstance().Add(go);
        }
    }
}

