using System.Collections;
using System.Collections.Generic;
using UFrame.Common;
using UnityEngine;

namespace COCSLG_Game
{
    public class HomeBuildingManager : Singleton<HomeBuildingManager>, ISingleton
    {
        public List<GameObject> buildingLst = new List<GameObject>();

        public void Init()
        {
        }

        public void Add(GameObject go)
        {
            buildingLst.Add(go);
        }

        public bool Contains(GameObject go)
        {
            return buildingLst.Contains(go);
        }
    }
}

