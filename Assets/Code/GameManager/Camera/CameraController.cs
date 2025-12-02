using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera _camera;
    public int moveSpeed; // 카메라 이동속도

    float maxX = 2.4f; // 카메라 최대 이동거리
    float minX = -2.4f; // 카메라 최소 이동거리

    bool moveRight = false;
    bool moveLeft = false;

    void Update()
    {
        Vector3 moveVec = Vector3.zero;

        if(moveRight)
        {
            moveVec = Vector3.right;
        }
        else if(moveLeft)
        {
            moveVec = Vector3.left;
        }

        Vector3 newPos = _camera.transform.position + moveVec * moveSpeed * Time.deltaTime;
        newPos.x = Mathf.Clamp(newPos.x, minX, maxX); // 카메라 이동거리를 -2.4 ~ 2.4로 범위제한
        _camera.transform.position = newPos;
    }
    public void OnRightButtonDown() { moveRight = true; }
    public void OnRighttButtonUp() { moveRight = false;}
    public void OnLeftButtonDown() {moveLeft = true; }
    public void OnLeftButtonUp() { moveLeft = false; }
}
