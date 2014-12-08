using UnityEngine;
using System.Collections;

public class TreesController : MonoBehaviour {

	public Transform m_snowball;

	void Awake()
	{	CheckTrees();
	}

	public void CheckTrees()
	{
		for(int i=0; i< transform.childCount; i++)
		{	Transform tree = transform.GetChild(i);

			if(!tree.GetComponent<Tree>().m_isDisabled)
			{	if(isTreeWarning(tree))
				{	tree.GetComponent<Tree>().WarningTree();
				}	else
				{	tree.GetComponent<Tree>().ResetTree();
				}
			}
		}
	}
	
	bool isTreeWarning(Transform tree)
	{	
		if(tree.localScale.x <= 0.5f && m_snowball.localScale.x >= 1)
		{	return false;
		}
		
		else if(tree.localScale.x <= 0.7f && m_snowball.localScale.x >= 1.5f)
		{	return false;
		}
		
		else if(tree.localScale.x <= 1 && m_snowball.localScale.x >= 3)
		{	return false;
		}
		
		else if(tree.localScale.x <= 1.5f && m_snowball.localScale.x >= 5)
		{	return false;
		}
		
		else if(tree.localScale.x <= 2 && m_snowball.localScale.x >= 10)
		{	return false;
		}
		
		else
		{	return true;
		}
	}
}
