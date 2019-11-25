using UnityEngine;

public class BoatController : MonoBehaviour
{
	public float m_maxVelocity = 1f;
	public float m_forceForward = 5f;
	public float m_forceRotation = 5f;
	private Rigidbody m_rb;

    void Start()
    {
	    m_rb = GetComponent<Rigidbody>();
	    m_rb.maxAngularVelocity = m_maxVelocity;
    }

    void Update()
    {
	    float axisX = Input.GetAxis("HorizontalR");

	    if (Input.GetButton("Horizontal"))
		    axisX = Input.GetAxis("Horizontal");

		var rotation = axisX * m_forceRotation;

		if (Input.GetButtonDown("Fire2"))
	    {
		    m_rb.AddForce(transform.forward * m_forceForward, ForceMode.Impulse);
		    m_rb.AddTorque(new Vector3(0f, rotation, 0f), ForceMode.Impulse);
	    }
	}

	void FixedUpdate()
	{
		if (m_rb.velocity.magnitude > m_maxVelocity)
		{
			m_rb.velocity = m_rb.velocity.normalized * m_maxVelocity;
		}
	}
}
