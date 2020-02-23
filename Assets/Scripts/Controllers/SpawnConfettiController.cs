using UnityEngine;

public class SpawnConfettiController : MonoBehaviour
{
	#region Private Members
	[SerializeField]
	private GameObject confettiFX;
	#endregion

	#region Public Methods
	public void SpawnConfetti()
	{
		confettiFX.SetActive(true);
	}
	#endregion
}
