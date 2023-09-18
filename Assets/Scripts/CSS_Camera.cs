using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSS_Camera : MonoBehaviour
{
    private Transform cameraObjTrans;
    private int cameraPos = 0; // (part of an) array!
    public float smoothTime = 0.3f;
    private Vector3 velocity = Vector3.zero;
    [SerializeField] private bool isFollowing;
    [SerializeField] Transform target;

    public void MoveCamera()
    {
        //CSS_GameManager.Instance.cameraPosRef.GetComponent<CSS_CameraSwitch>().camPosArr;
        if (cameraPos < CSS_GameManager.Instance.cameraPosRef.GetComponent<CSS_CameraSwitch>().camPosArr.Length)
        {
            cameraPos++;
            this.transform.position = CSS_GameManager.Instance.cameraPosRef.GetComponent<CSS_CameraSwitch>().camPosArr[cameraPos].position;
        }
    }

    private void FixedUpdate()
    {
        if (isFollowing)
        {
            // https://docs.unity3d.com/ScriptReference/Vector3.SmoothDamp.html Smooth damp is used to allow the camera to smoothly
            // move from point a to b, from its current location to the player (with a slight delay effect).
            Vector3 targetPosition = target.TransformPoint(new Vector3(0, 0, -10));
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }
    }

    public Transform GetCameraObjTrans()
    {
        return this.cameraObjTrans;
    }

    public void SetCameraObjTrans(Vector3 _trans)
    {
        cameraObjTrans.position = _trans;
    }

    public bool GetCameraFollowing()
    {
        return this.isFollowing;
    }

    public void SetCameraFollowing(bool _follow)
    {
        isFollowing = _follow;
    }

    public void SetCameraTarget(Transform _target)
    {
        target = _target;
    }
}
