using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UFrame.Math_F
{
    public class Math
    {
        /// <summary>
        /// 线和平面的交点
        /// 前两个参数是线的参数（线上的点，线的方向）
        /// 后两个参数是平面参数（法向量，平面上的一点）
        /// </summary>
        /// <param name="point"></param>
        /// <param name="direct"></param>
        /// <param name="planeNormal"></param>
        /// <param name="planePoint"></param>
        /// <returns></returns>
        public static Vector3 GetIntersectWithLineAndPlane(Vector3 point, Vector3 direct, Vector3 planeNormal, Vector3 planePoint)
        {
            float d = Vector3.Dot(planePoint - point, planeNormal) / Vector3.Dot(direct.normalized, planeNormal);
            return d * direct.normalized + point;
        }


        /// <summary>
        /// 线和地平面的交点
        /// 地平面：法向量是(0, 1, 0),地平面上点是(1, 0, 0)
        /// </summary>
        /// <param name="point"></param>
        /// <param name="direct"></param>
        /// <returns></returns>
        public static Vector3 GetIntersectWithLineAndGround(Vector3 point, Vector3 direct)
        {
            return GetIntersectWithLineAndPlane(point, direct, Vector3.up, Vector3.right);
        }
    }
}

