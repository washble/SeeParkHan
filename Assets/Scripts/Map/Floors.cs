using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floors : MonoBehaviour
{
    public delegate void RePosition(GameManager.Floors position);
    public event RePosition RePositionActive;

    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject leftFloor;
    [SerializeField]
    private GameObject rightFloor;

    private Vector3 resetPosition;
    private float limitLeft;
    private float cameraLeftReachStandard;
    private float resetTerm;

    void Awake()
    {
        resetTerm = rightFloor.transform.localScale.x * 0.2f;
        resetPosition = new Vector3(rightFloor.transform.position.x - resetTerm, 0, 0);
        limitLeft = rightFloor.transform.position.x + rightFloor.transform.localScale.x - 0.1f + resetTerm;

        cameraLeftReachStandard = player.transform.localScale.x * 0.05f;
    }

    void Start()
    {
        RePositionActive(GameManager.Floors.right);
    }

    void Update()
    {
        CheckCameraLeftReach();
        FReset();
    }

    void FixedUpdate()
    {
        FMove();
    }

    private void CheckCameraLeftReach()
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(player.transform.position);
        if (pos.x <= cameraLeftReachStandard) GameManager.Instance.ReachCameraLeft = true;
        if (Input.GetAxisRaw("Horizontal") > 0) GameManager.Instance.ReachCameraLeft = false;
    }

    private void FMove()
    {
        if (GameManager.Instance.ReachCameraLeft) return;
        if (GameManager.Instance.GameOverState) return;

        Vector3 moveVelocity = Vector3.zero;

        if (Input.GetAxisRaw("Horizontal") < 0)
            moveVelocity = Vector3.right;
        else if (Input.GetAxisRaw("Horizontal") > 0)
            moveVelocity = Vector3.left;
        leftFloor.transform.position += moveVelocity * GameManager.Instance.MovePower * Time.deltaTime;
        rightFloor.transform.position += moveVelocity * GameManager.Instance.MovePower * Time.deltaTime;
    }

    private void FReset()
    {
        if (leftFloor.transform.position.x <= -limitLeft)
        {
            leftFloor.transform.position = resetPosition;
            RePositionActive(GameManager.Floors.left);
        }
            
        if (rightFloor.transform.position.x <= -limitLeft)
        {
            rightFloor.transform.position = resetPosition;
            RePositionActive(GameManager.Floors.right);
        }
    }
}
