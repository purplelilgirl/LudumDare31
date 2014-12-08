using UnityEngine;
using System.Collections;

public class TopCameraController : MonoBehaviour {

	public Transform m_target;
	
	void Awake () 
	{	setCameraPosition();
	}
	
	void Update () 
	{	setCameraPosition();
	}
	
	void setCameraPosition()
	{	transform.position = new Vector3(m_target.position.x, m_target.position.y+10, m_target.position.z);
	}
}
