using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	[SerializeField] private GarageHandler garageHandler;

	[SerializeField] private Vector3 offset;
	[SerializeField] private float height;

	public bool enableVelocityDirectionIndicator;
	private Rigidbody car;
	
	void Start()
	{
		Application.targetFrameRate = 60;
		car = garageHandler.CurrentCar.GetComponent<Rigidbody>();
	}

	void FixedUpdate()
	{
		transform.LookAt(car.position + Vector3.up * height);
		Vector3 velocityOffset = car.velocity;
		if (velocityOffset.magnitude < 0.05f)
			velocityOffset = car.transform.forward;
		Vector3 followPoint = car.position + velocityOffset.normalized * offset.z + car.transform.up * offset.y;
		transform.position = Vector3.Lerp(transform.position, followPoint , 0.02f + Time.fixedDeltaTime);
	}

}
