using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UFrame.CameraController;

namespace COCSLG_Game
{
    public class HomeBuildingFinger : MonoBehaviour
    {
        int dragFingerIndex = -1;
        void OnDrag(DragGesture gesture)
        {
            //if (gesture.Selection != gameObject)
            //{
            //    return;
            //}

            if (!HomeBuildingManager.GetInstance().Contains(gesture.Selection))
            {
                return;
            }
            //Debug.Log("drag building " + gameObject.name);
            FingerCamera.GetInstance().couldMove = false;
            // first finger
            FingerGestures.Finger finger = gesture.Fingers[0];

            if (gesture.Phase == ContinuousGesturePhase.Started)
            {
                dragFingerIndex = finger.Index;
            }
            else if (finger.Index == dragFingerIndex)  // gesture in progress, make sure that this event comes from the finger that is dragging our dragObject
            {
                if (gesture.Phase == ContinuousGesturePhase.Updated)
                {
                    //transform.position = ScreenPointToWorldPlane(gesture.Position);
                    gesture.Selection.transform.position = ScreenPointToWorldPlane(gesture.Position);
                }
                else
                {
                    dragFingerIndex = -1;
                    FingerCamera.GetInstance().couldMove = true;
                    var gridPos = HomeGridManager.GetInstance().WorldPosToGridPos(gesture.Selection.transform.position);
                    var cellCenter = HomeGridManager.GetInstance().GridPosToCellCenterInWorld(gridPos);
                    //transform.position = cellCenter;
                    gesture.Selection.transform.position = cellCenter;
                }
            }
        }

        /// <summary>
        /// 屏幕坐标转与地平面上的点
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        Vector3 ScreenPointToWorldPlane(Vector2 point)
        {
            Ray ray = Camera.main.ScreenPointToRay(point);

            return GetIntersectWithLineAndPlane(ray.origin, ray.direction, Vector3.up, Vector3.left);
        }

        /// <summary>
        /// 计算直线与平面的交点
        /// </summary>
        /// <param name="point">直线上某一点</param>
        /// <param name="direct">直线的方向</param>
        /// <param name="planeNormal">垂直于平面的的向量</param>
        /// <param name="planePoint">平面上的任意一点</param>
        /// <returns></returns>
        Vector3 GetIntersectWithLineAndPlane(Vector3 point, Vector3 direct, Vector3 planeNormal, Vector3 planePoint)
        {
            float d = Vector3.Dot(planePoint - point, planeNormal) / Vector3.Dot(direct.normalized, planeNormal);
            return d * direct.normalized + point;
        }

    }

}

