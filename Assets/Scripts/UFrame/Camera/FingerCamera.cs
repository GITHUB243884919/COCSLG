using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UFrame.CameraController
{
    public class FingerCamera : MonoBehaviour
    {
        public float sensitivity;
        public float smoothSpeed;
        public Vector3 minMoveArea;
        public Vector3 maxMoveArea;

        DragGesture dragGesture;
        Transform cachedTransform;
        Vector3 moveTo = Vector3.zero;

        public bool couldMove = true;
        static FingerCamera instance;
        public static FingerCamera GetInstance()
        {
            return instance;
        }
        void Awake()
        {
            cachedTransform = this.transform;
            moveTo = cachedTransform.position;
            instance = this;
        }

        void OnDrag(DragGesture gesture)
        {
            //dragGesture = (gesture.State == GestureRecognitionState.Ended || gesture.Selection != null) ? null : gesture;
            if (gesture.State == GestureRecognitionState.Ended || !couldMove)
            {
                dragGesture = null;
                return;
            }

            dragGesture = gesture;

        }


        void LateUpdate()
        {
            if (dragGesture != null)
            {

                if (dragGesture.DeltaMove.SqrMagnitude() > 0)
                {
                    //Debug.Log(dragGesture.DeltaMove);
                    Vector2 screenSpaceMove = sensitivity * dragGesture.DeltaMove;
                    Vector3 worldSpaceMove = screenSpaceMove.x * cachedTransform.right + screenSpaceMove.y * cachedTransform.up;

                    moveTo.x -= worldSpaceMove.x;
                    moveTo.z -= worldSpaceMove.z;

                    moveTo = ConstrainToMoveArea(moveTo);
                }
            }

            cachedTransform.position = Vector3.Lerp(cachedTransform.position, moveTo, Time.deltaTime * smoothSpeed);


        }


        public Vector3 ConstrainToMoveArea(Vector3 moveTo)
        {
            moveTo.x = Mathf.Clamp(moveTo.x, minMoveArea.x, maxMoveArea.x);
            moveTo.y = Mathf.Clamp(moveTo.y, minMoveArea.y, maxMoveArea.y);
            moveTo.z = Mathf.Clamp(moveTo.z, minMoveArea.z, maxMoveArea.z);

            return moveTo;
        }
    }

}
