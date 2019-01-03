using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour {

    public Transform targetPlayer;
    Camera playerCam;
    public PlayerMove getActions;
    public float cameraDistance = 5.0f;
    public float sensitivity = 5.0f;
    public float smoothing = 2.0f;

    public Vector2 mouseLook;
    public Vector2 rotateVert;
    public Quaternion camRotateX;
    public Quaternion camRotateXY;

    public Vector3 lookOffset;

    void Start()
    {
        getActions = FindObjectOfType<PlayerMove>();
        playerCam = GetComponent<Camera>();
        lookOffset = playerCam.transform.position - targetPlayer.transform.position;
    }
    
    void Update()
    {

        CameraControl();

    }

    public void CameraControl()
    {
        var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        md = Vector2.Scale(md, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
        rotateVert.x = Mathf.Lerp(rotateVert.x, md.x, 1f / smoothing);
        rotateVert.y = Mathf.Lerp(rotateVert.y, md.y, 1f / smoothing);
        mouseLook += rotateVert;
        mouseLook.y = Mathf.Clamp(mouseLook.y, -40, 40);

        camRotateXY = Quaternion.Euler(-mouseLook.y, mouseLook.x, 0);

        camRotateX = Quaternion.Euler(0, mouseLook.x, 0);

        if (getActions.checkActions == true)
        {
            targetPlayer.eulerAngles = new Vector3(0, camRotateX.eulerAngles.y, 0);
        }
        else
        {
            Vector3 lookPoint = targetPlayer.transform.position;
            playerCam.transform.LookAt(lookPoint + lookOffset);
        }

        Vector3 position = targetPlayer.position - (camRotateXY * Vector3.forward * cameraDistance + new Vector3(0, -lookOffset.y, 0));

        playerCam.transform.rotation = camRotateXY;
        playerCam.transform.position = position;
    }
}
