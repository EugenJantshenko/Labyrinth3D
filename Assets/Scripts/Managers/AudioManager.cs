using UnityEngine;

public class AudioManager : MonoBehaviour
{
	#region Private Members
	[SerializeField]
	private AudioClip clicSound;
	[SerializeField]
	private AudioClip winSound;
	[SerializeField]
	private AudioClip loseSound;
	private AudioSource audioSource;
	#endregion

	#region Private Voids
	void Start()
	{
		audioSource = GetComponent<AudioSource>();
		audioSource.volume = 0.5f;
		audioSource.Play();
	}
	#endregion

	#region Public Voids
	public void StopPlayLevelMusic()
	{
		audioSource.Stop();
	}

	public void OnClick()
	{
		audioSource.PlayOneShot(clicSound);
	}

	public void PlaySound(bool win)
	{
		audioSource.volume = 1f;
		if (win)
		{
			audioSource.PlayOneShot(winSound);
		}
		else
		{
			audioSource.PlayOneShot(loseSound);
		}
	}
	#endregion
}
