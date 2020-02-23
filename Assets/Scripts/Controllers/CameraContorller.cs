using UnityEngine;

public class CameraContorller : MonoBehaviour
{
	#region Private Members
	[SerializeField]
	private GameObject target;
	#endregion

	#region Private Methods
	void Update () 
	{
		transform.LookAt(target.transform);
		transform.Translate(Vector3.right * Time.deltaTime);
	}
	#endregion
}
