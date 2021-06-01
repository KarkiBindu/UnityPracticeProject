using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform Hole;
    public Transform Ball;

    private void Awake()
    {
     
    }
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CameraFollow(Transform objectTofollow)
    {
        #region camera follow     
        if (!objectTofollow)
            return;
        // Calculate the current rotation angles
        var wantedRotationAngle = objectTofollow.eulerAngles.y;
        var wantedHeight = objectTofollow.position.y + 10;
        var currentRotationAngle = transform.eulerAngles.y;
        var currentHeight = transform.position.y;
        // Damp the rotation around the y-axis
        currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, Time.deltaTime);
        // Damp the height
        currentHeight = Mathf.Lerp(currentHeight, wantedHeight, Time.deltaTime);
        // Convert the angle into a rotation
        Quaternion currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);
        // Set the position of the camera on the x-z plane to:
        // distance meters behind the objectTofollow
        transform.position = objectTofollow.position;
        transform.position -= currentRotation * Vector3.forward * 10;

        // Set the height of the camera
        Vector3 pos = transform.position;
        pos.y = currentHeight;
        transform.position = pos;

        // Always look at the objectTofollow
        transform.LookAt(objectTofollow);
        #endregion
    }
}
