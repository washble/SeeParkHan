using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField]
    private GameObject playerObj;
    [SerializeField]
    private GameObject leftFloor;
    [SerializeField]
    private GameObject rightFloor;

    [SerializeField]
    private float movePower = 1f;

    private float resetTerm;

    void Awake()
    {
        resetTerm = rightFloor.transform.localScale.x * 0.4f;
    }

    void FixedUpdate()
    {
        CMove();
        CRePostion();
    }

    private void CRePostion()
    {
        if (leftFloor.transform.position.x >= -resetTerm && rightFloor.transform.position.x >= -resetTerm) return;

        float cameraX = transform.position.x;
        float cameraToPlayerDis = playerObj.transform.position.x - cameraX;
        if (CustomAbs(cameraToPlayerDis) > 0.1f)
            transform.position += Vector3.right * cameraToPlayerDis * movePower * Time.deltaTime;
    }

    private void CMove()
    {
        if (GameManager.Instance.ReachCameraLeft) return;
        if (GameManager.Instance.GameOverState) return;

        Vector3 moveVelocity = Vector3.zero;
            
        if (Input.GetAxisRaw("Horizontal") < 0)
            moveVelocity = Vector3.right;
        else if (Input.GetAxisRaw("Horizontal") > 0)
            moveVelocity = Vector3.left;

        transform.position += moveVelocity * GameManager.Instance.MovePower * Time.deltaTime;   
    }

    private float CustomAbs(float x)
    {
        x = x < 0 ? -x : x;
        return x;
    }
}
