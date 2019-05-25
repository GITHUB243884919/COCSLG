using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UFrame.Common;
namespace UFrame.CameraController
{
    /// <summary>
    /// 基于FingerGestures实现相机移动控制
    /// </summary>
    public class FingerCamera : SingletonMono<FingerCamera>
    {
        //滑动
        public bool couldDrag = true;
        public float dragSensitivity = 0.02f;
        public float dragSmoothSpeed;
        public Vector3 minMoveArea;
        public Vector3 maxMoveArea;
        //拉伸
        public bool pinching = false;
        public float pinchSensitivity = 0.6f;

        DragGesture dragGesture;
        Transform cachedTransform;
        Vector3 moveTo = Vector3.zero;
        Camera cam;
        public override void Awake()
        {
            base.Awake();
            cachedTransform = this.transform;
            moveTo = cachedTransform.position;
            cam = GetComponent<Camera>();

            //PointAtScreenCenter(Vector3.zero);

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
                    // change the scale of the target based on the pinch delta value
                    //target.transform.localScale += gesture.Delta.Centimeters() * pinchScaleFactor * Vector3.one;
                    cam.orthographicSize -= gesture.Delta.Centimeters() * pinchSensitivity;
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

                    moveTo.x -= worldSpaceMove.x;
                    moveTo.z -= worldSpaceMove.z;

                    moveTo = ConstrainToMoveArea(moveTo);
                }
            }

            cachedTransform.position = Vector3.Lerp(cachedTransform.position, moveTo, Time.deltaTime * dragSmoothSpeed);


        }

        Vector3 ConstrainToMoveArea(Vector3 moveTo)
        {
            moveTo.x = Mathf.Clamp(moveTo.x, minMoveArea.x, maxMoveArea.x);
            moveTo.y = Mathf.Clamp(moveTo.y, minMoveArea.y, maxMoveArea.y);
            moveTo.z = Mathf.Clamp(moveTo.z, minMoveArea.z, maxMoveArea.z);

            return moveTo;
        }

        public void PointAtScreenCenter(Vector3 point)
        {
            Vector2 p = Vector2.zero;
            p.x = Screen.width / 2;
            p.y = Screen.height / 2;

            Ray ray = Camera.main.ScreenPointToRay(point);

            Vector3 p2 =  GetIntersectWithLineAndPlane(ray.origin, ray.direction, Vector3.up, Vector3.left);

            transform.position -= (p2 - point);
        }

        Vector3 GetIntersectWithLineAndPlane(Vector3 point, Vector3 direct, Vector3 planeNormal, Vector3 planePoint)
        {
            float d = Vector3.Dot(planePoint - point, planeNormal) / Vector3.Dot(direct.normalized, planeNormal);
            return d * direct.normalized + point;
        }
    }

}
