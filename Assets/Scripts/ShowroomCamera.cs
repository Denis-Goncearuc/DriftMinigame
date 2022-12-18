using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowroomCamera : MonoBehaviour {
	
    [SerializeField] private Transform point;
    [SerializeField] private Joystick input;
	
    [SerializeField] private float height;
    [SerializeField] private float distance;
    [SerializeField] private float rotationSpeed;

    private float targetRightOffset;
    private float rightOffset;
    void FixedUpdate()
    {
	    rightOffset = Mathf.Lerp(rightOffset, targetRightOffset, 0.01f + Time.fixedDeltaTime);
	    
        transform.LookAt(point.position + Vector3.up * height + transform.right * rightOffset);
		
        point.Rotate(0,input.Horizontal * Time.fixedDeltaTime * rotationSpeed, 0);
		
    }

    public void SetOffset(float val)
    {
	    targetRightOffset = val;
    }

}