using UnityEngine;
using System.Collections;

public class Tree : MonoBehaviour 
{
	public Renderer m_cone1;
	public Renderer m_cone2;
	public Renderer m_cone3;
	public Renderer m_trunk;

	public Material m_coneMat;
	public Material m_trunkMat;

	public Material m_disableMat;
	public Material m_warningMat;

	[HideInInspector] public bool m_isDisabled = false;
	[HideInInspector] public bool m_isWarning = false;

	public void ResetTree()
	{	m_isWarning = false; 

		m_cone1.material = m_coneMat;
		m_cone2.material = m_coneMat;
		m_cone3.material = m_coneMat;
		m_trunk.material = m_trunkMat;
	}

	public void DisableTree()
	{	m_isDisabled = true;
		m_isWarning = false; 

		gameObject.AddComponent<Rigidbody>();

		m_cone1.material = m_disableMat;
		m_cone2.material = m_disableMat;
		m_cone3.material = m_disableMat;
		m_trunk.material = m_disableMat;
	}

	public void WarningTree()
	{	m_isWarning = true;

		m_cone1.material = m_warningMat;
		m_cone2.material = m_warningMat;
		m_cone3.material = m_warningMat;
		m_trunk.material = m_warningMat;
	}
}
