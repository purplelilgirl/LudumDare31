using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SnowballController : MonoBehaviour 
{
	public float m_force = 100;
	public Text m_scoreLbl;

	bool m_isShownInstruction2 = false;
	public Text m_instructionsLbl;
	public Text m_loseLbl;

	public AudioClip m_hitSound;
	public AudioClip m_dieSound;

	public Camera m_mainCamera;
	public Camera m_topCamera;

	public TreesController m_treesController;

	public Material m_hitMat;
	public Color m_hitColor;
	public Color m_snowColor;

	public ParticleSystem m_particle;

	int m_score = 0;
	bool m_isDead = false;

	void Awake()
	{	m_scoreLbl.text = "Knock 'Em Trees";

		m_loseLbl.text = "Ouch >.<\nTree is too BIG!";
		m_loseLbl.gameObject.SetActive(false);

		m_mainCamera.gameObject.SetActive(true);
		m_topCamera.gameObject.SetActive(false);
	}

	void Update () 
	{
		if(!m_isDead)
		{
			if(Input.GetKey(KeyCode.A))
			{	showInstruction2();
				rigidbody.AddForce(Vector3.left * m_force);
			}

			if(Input.GetKey(KeyCode.W))
			{	showInstruction2();
				rigidbody.AddForce(Vector3.forward * m_force);
			}

			if(Input.GetKey(KeyCode.S))
			{	showInstruction2();
				rigidbody.AddForce(Vector3.back * m_force);
			}
				
			if(Input.GetKey(KeyCode.D))
			{	showInstruction2();
				rigidbody.AddForce(Vector3.right * m_force);
			}
		}

		if(Input.GetKeyDown(KeyCode.R))
		{	Application.LoadLevel(Application.loadedLevel);
		}

		/**
		if(Input.GetKeyDown(KeyCode.Space))
		{	m_isShownInstruction2 = true;
			hideInstruction2();

			switchCamera();
		}
		**/
	}

	void OnCollisionEnter(Collision collision)
	{	if(collision.transform.tag == "tree")
		{	
			if(!collision.gameObject.GetComponent<Tree>().m_isWarning)
			{	if(!collision.gameObject.GetComponent<Tree>().m_isDisabled)
				{	
					hideInstruction2();

					collision.gameObject.GetComponent<Tree>().DisableTree();

					float newScale;

					if(transform.localScale.x < 1.5f)
					{	newScale = transform.localScale.x+0.05f;
					}	else if(transform.localScale.x < 3)
					{	newScale = transform.localScale.x+0.025f;
					}	else
					{	newScale = transform.localScale.x+0.01f;
					}

					transform.localScale = new Vector3(newScale, newScale, newScale);

					m_treesController.CheckTrees();

					audio.clip = m_hitSound;
					audio.Play();

					m_particle.startColor = m_snowColor;
					m_particle.Play();

					m_score++;

					if(m_score == 1)
					{	m_scoreLbl.text = m_score + " Tree";
					}	else
					{	m_scoreLbl.text = m_score + " Trees";
					}
				}
			}	else
			{	m_instructionsLbl.text = "R to Retry";
				m_instructionsLbl.gameObject.SetActive(true);

				m_loseLbl.gameObject.SetActive(true);

				m_isDead = true;
				transform.renderer.material = m_hitMat;

				Invoke("stopMoving", 0.5f);

				audio.clip = m_dieSound;
				audio.Play();

				m_particle.startColor = m_hitColor;
				m_particle.Play();
			}
		}
	}

	void stopMoving()
	{	rigidbody.isKinematic = true;
	}

	void switchCamera()
	{	m_mainCamera.gameObject.SetActive(!m_mainCamera.gameObject.activeInHierarchy);
		m_topCamera.gameObject.SetActive(!m_topCamera.gameObject.activeInHierarchy);
	}

	void showInstruction2()
	{	
		/**
		if(!m_isShownInstruction2)
		{	m_instructionsLbl.text = "Space to Toggle Camera";
			m_isShownInstruction2 = true;
		}
		**/

		//hideInstruction2();
	}

	void hideInstruction2()
	{	m_instructionsLbl.gameObject.SetActive(false);
	}
}
