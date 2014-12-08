using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour 
{
	public Transform m_target;

	void Awake () 
	{	setCameraPosition();
	}
	
	void Update () 
	{	setCameraPosition();
	}

	void setCameraPosition()
	{	
		if(m_target.localScale.x < 1.5f)
		{	transform.position = new Vector3(m_target.position.x, m_target.position.y+1, m_target.position.z-3);
		}	else if(transform.localScale.x < 3)
		{	transform.position = new Vector3(m_target.position.x, m_target.position.y+1.5f, m_target.position.z-3.5f);
		}	else
		{	transform.position = new Vector3(m_target.position.x, m_target.position.y+2, m_target.position.z-4);
		}
	}
}
