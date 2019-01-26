using UnityEngine;

public class followCamera : MonoBehaviour
{
	public Transform target;

	public float smoothSpeed = 0.125f;

	public Vector3 offset;

	void LateUpdate ()
	{
      
        Vector3 desiredPosition = new Vector3(target.position.x + offset.x, 0, 0);
        desiredPosition.z = -10;

        Vector3 smoothedPosition = Vector3.Slerp(transform.position, desiredPosition, smoothSpeed);

        transform.position = smoothedPosition;

        //transform.LookAt(target);
    }
}
