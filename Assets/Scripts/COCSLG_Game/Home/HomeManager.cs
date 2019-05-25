﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UFrame.ResourceManagement;

namespace COCSLG_Game
{
    public class HomeManager : MonoBehaviour
    {
        Transform homeBuildingRoot;
        void Awake()
        {
            InitHomeGrid();
            InitHomeBuilding();
        }

        void Update()
        {

        }

        void InitHomeGrid()
        {
            HomeGridManager.GetInstance().center = Vector3.zero;
            HomeGridManager.GetInstance().cellSize = 1;
            HomeGridManager.GetInstance().gridSize = 100;
            HomeGridManager.GetInstance().color = Color.green;
        }

        void InitHomeBuilding()
        {
            if (homeBuildingRoot == null)
            {
                homeBuildingRoot = GameObject.Find("home_root/homebuilding_root").transform;

            }
            var getter = ResHelper.LoadGameObject("prefabs/homebuilding/homebuilding");
            var go = getter.Get();
            go.transform.SetParent(homeBuildingRoot, false);

            HomeBuildingManager.GetInstance().Add(go);
        }
    }
}
