using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UFrame.CameraController;
using UFrame.Sound;
namespace COCSLG_Game
{
    /// <summary>
    /// 基于FingerGestures实现的拖拽
    /// </summary>
    public class HomeBuildingFinger : MonoBehaviour
    {
        int dragFingerIndex = -1;
        void OnDrag(DragGesture gesture)
        {
            if (!HomeBuildingManager.GetInstance().Contains(gesture.Selection))
            {
                return;
            }

            //相机停止移动
            FingerCamera.GetInstance().couldDrag = false;
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
                    FingerCamera.GetInstance().couldDrag = true;
                    var gridPos = HomeGridManager.GetInstance().WorldPosToGridPos(gesture.Selection.transform.position);
                    var cellCenter = HomeGridManager.GetInstance().GridPosToCellCenterInWorld(gridPos);
                    //transform.position = cellCenter;
                    gesture.Selection.transform.position = cellCenter;
                    SoundManager.GetInstance().PlaySound("sound/build_pickup_05");
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
            //todo 增加相机管理，不要使用Camera.main这种低效的方式
            Ray ray = Camera.main.ScreenPointToRay(point);

            return UFrame.Math_F.Math.GetIntersectWithLineAndGround(ray.origin, ray.direction);
        }


    }

}

