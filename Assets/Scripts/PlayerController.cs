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
    private Animator m_animator;
    private Animation m_animation;

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
        m_animator = GetComponent<Animator>();
        m_animation = GetComponent<Animation>();
    }

    void Update()
    {
		if (Input.GetKey(KeyCode.A) || Input.GetAxis("HorizontalR") < 0)
		{
			if (m_axisX < 0.00f)
			{
				m_axisX -= 0.02f * Time.deltaTime;
				m_axisX = Mathf.Max(m_axisX, -2.0f);
			}
			else m_axisX = -1.0f;

		}
		else if (Input.GetKey(KeyCode.D) || Input.GetAxis("HorizontalR") > 0)
		{
			if (m_axisX > 0.00f)
			{
				m_axisX += 0.02f * Time.deltaTime;
				m_axisX = Mathf.Min(m_axisX, 2.0f);
			}
			else m_axisX = 1f;
		}

		switch (paddleSideState)
		{
			case PaddleSide.LEFT:
				AnimationLeftSide();
				break;
			case PaddleSide.RIGHT:
				AnimationRightSide();
				break;

			default:
				break;
		}
	}

	void FixedUpdate()
	{
		if (Input.GetButtonDown("Fire2") || Input.GetKeyDown(KeyCode.Space))
		{
            if (!m_animation.isPlaying)
            {
                m_animator.SetTrigger("PaddleForward");
                var rotation = m_axisX * m_forceRotation;

                m_rb.AddForce(transform.forward * m_forceForward, ForceMode.Impulse);
                m_rb.AddTorque(new Vector3(0f, rotation, 0f), ForceMode.Impulse);
            }
		}

		if (m_rb.velocity.magnitude > m_maxVelocity)
		{
			m_rb.velocity = m_rb.velocity.normalized * m_maxVelocity;
		}
	}

	void AnimationLeftSide()
	{

	}

	void AnimationRightSide()
	{

    }
}
