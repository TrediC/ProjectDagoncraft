using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float m_maxVelocity = 1f;
	public float m_forceForward = 5f;
	public float m_forceRotation = 5f;
	public GameObject m_paddle;

	private Rigidbody m_rb;
	private float m_axisX = -1f;

	private enum PaddleSide
	{
		LEFT,
		RIGHT
	}

	private PaddleSide paddleSideState = PaddleSide.LEFT;

	void Start()
    {
		m_rb = GetComponent<Rigidbody>();
		m_rb.maxAngularVelocity = m_maxVelocity;
	}

    void Update()
    {
		if (Input.GetAxis("HorizontalR") < 0)
			m_axisX = -1f;
		else if (Input.GetAxis("HorizontalR") > 0)
			m_axisX = 1f;

		else if (Input.GetKeyDown(KeyCode.A))
			m_axisX = m_axisX = -1f;
		else if (Input.GetKeyDown(KeyCode.D))
			m_axisX = 1f;

		switch(paddleSideState)
		{
			case PaddleSide.LEFT:
				break;
			case PaddleSide.RIGHT:
				break;

			default:
				break;
		}
	}

	void FixedUpdate()
	{
		if (Input.GetButtonDown("Fire2") || Input.GetKeyDown(KeyCode.Space))
		{
			var rotation = m_axisX * m_forceRotation;

			m_rb.AddForce(transform.forward * m_forceForward, ForceMode.Impulse);
			m_rb.AddTorque(new Vector3(0f, rotation, 0f), ForceMode.Impulse);

			print(rotation);
		}

		if (m_rb.velocity.magnitude > m_maxVelocity)
		{
			m_rb.velocity = m_rb.velocity.normalized * m_maxVelocity;
		}
	}
}
