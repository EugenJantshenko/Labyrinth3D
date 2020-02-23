using UnityEngine;

public class BallController : MonoBehaviour
{
	#region Private Members
	[SerializeField]
	private PauseMenuManager pauseManager;
	private Rigidbody rigidbody;
	private bool isFlat;
	#endregion

	#region Private Methods
	void Start()
	{
		isFlat = true;
		rigidbody = GetComponent<Rigidbody>();
	}
	
	void Update()
	{
		if (!pauseManager.isPaused)
		{
			Vector3 tilt = Input.acceleration;
			if (isFlat)
				tilt = Quaternion.Euler(90, 0, 0) * tilt;
			rigidbody.AddForce(tilt * (int)pauseManager.sensetivity);
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Exit")
		{
			pauseManager.Win();
			gameObject.SetActive(false);
		}
	}
	#endregion
}
