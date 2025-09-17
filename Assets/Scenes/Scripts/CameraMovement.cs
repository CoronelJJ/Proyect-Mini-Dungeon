using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    [SerializeField] Transform target;
    [SerializeField] float cameraSpeed = 0.035f;
    [SerializeField] Vector3 offset;


    void LateUpdate()
    {
        Vector3 finalPosition = target.position + offset;

        Vector3 smoothPosition = Vector3.Lerp(transform.position, finalPosition, cameraSpeed);

        transform.position = smoothPosition;
    }
}
