using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverBehaviour : MonoBehaviour
{
	public Component Target = null;

	public virtual void OnBehaviourAttached() { }

	public virtual void OnBehaviourDetached() { }
}
