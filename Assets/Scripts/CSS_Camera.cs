using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSS_Camera : MonoBehaviour
{
    private Transform cameraObjTrans;
    private int cameraPos = 0; // (part of an) array!
    [SerializeField] private bool isFollowing;
    public void MoveCamera()
    {
        //CSS_GameManager.Instance.cameraPosRef.GetComponent<CSS_CameraSwitch>().camPosArr;
        if (cameraPos < CSS_GameManager.Instance.cameraPosRef.GetComponent<CSS_CameraSwitch>().camPosArr.Length)
        {
            cameraPos++;
            this.transform.position = CSS_GameManager.Instance.cameraPosRef.GetComponent<CSS_CameraSwitch>().camPosArr[cameraPos].position;
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
}
