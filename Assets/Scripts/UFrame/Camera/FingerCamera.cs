using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UFrame.Common;
using COCSLG_Game;

namespace UFrame.CameraController
{
    /// <summary>
    /// 基于FingerGestures实现相机移动控制
    /// </summary>
    public class FingerCamera : SingletonMono<FingerCamera>
    {
        //滑动
        public bool couldDrag = false;
        public float dragSensitivity = 0.02f;
        public float dragSmoothSpeed;
        public Vector3 minMoveArea;
        public Vector3 maxMoveArea;
        DragGesture dragGesture;
        Vector3 dragMoveTo = Vector3.zero;
        //拉伸
        public bool pinching = false;
        public float pinchSensitivity = 0.6f;

        Transform cachedTransform;
        Camera cacheCam;

        public override void Awake()
        {
            base.Awake();
            cachedTransform = this.transform;
            dragMoveTo = cachedTransform.position;
            cacheCam = GetComponent<Camera>();
        }

        void Start()
        {
            //var go = HomeBuildingManager.GetInstance().buildingLst[0];
            //PointAtScreenCenter(new Vector3(50, 0, -20));
            
        }

        //滑动
        void OnDrag(DragGesture gesture)
        {
            if (gesture.State == GestureRecognitionState.Ended || !couldDrag)
            {
                dragGesture = null;
                return;
            }

            dragGesture = gesture;
        }

        //拉伸
        void OnPinch(PinchGesture gesture)
        {
            if (gesture.Phase == ContinuousGesturePhase.Started)
            {
                couldDrag = false;
                pinching = true;
            }
            else if (gesture.Phase == ContinuousGesturePhase.Updated)
            {
                if (pinching)
                {
                    cacheCam.orthographicSize -= gesture.Delta.Centimeters() * pinchSensitivity;
                }
            }
            else
            {
                if (pinching)
                {
                    pinching = false;
                    couldDrag = true;
                }
                
            }
        }

        void LateUpdate()
        {
            if (dragGesture != null)
            {

                if (dragGesture.DeltaMove.SqrMagnitude() > 0)
                {
                    //Debug.Log(dragGesture.DeltaMove);
                    Vector2 screenSpaceMove = dragSensitivity * dragGesture.DeltaMove;
                    Vector3 worldSpaceMove = screenSpaceMove.x * cachedTransform.right + screenSpaceMove.y * cachedTransform.up;

                    dragMoveTo.x -= worldSpaceMove.x;
                    dragMoveTo.z -= worldSpaceMove.z;

                    dragMoveTo = ConstrainToMoveArea(dragMoveTo);
                }
            }

            cachedTransform.position = Vector3.Lerp(cachedTransform.position, dragMoveTo, Time.deltaTime * dragSmoothSpeed);
        }

        Vector3 ConstrainToMoveArea(Vector3 moveTo)
        {
            moveTo.x = Mathf.Clamp(moveTo.x, minMoveArea.x, maxMoveArea.x);
            moveTo.y = Mathf.Clamp(moveTo.y, minMoveArea.y, maxMoveArea.y);
            moveTo.z = Mathf.Clamp(moveTo.z, minMoveArea.z, maxMoveArea.z);

            return moveTo;
        }

        /// <summary>
        /// 使地面上某一点处于屏幕中间
        /// </summary>
        /// <param name="point"></param>
        public void PointAtScreenCenter(Vector3 point)
        {
            Vector2 screenCenter = Vector2.zero;
            screenCenter.x = Screen.width / 2;
            screenCenter.y = Screen.height / 2;

            Ray ray = Camera.main.ScreenPointToRay(screenCenter);
            Vector3 groundPoint = UFrame.Math_F.Math.GetIntersectWithLineAndGround(ray.origin, ray.direction);

            //GameObject.CreatePrimitive(PrimitiveType.Capsule).transform.position = point;
            transform.position -= (groundPoint - point);

            //防止LateUpdate的拖动
            dragMoveTo = transform.position;
        }
    }

}
