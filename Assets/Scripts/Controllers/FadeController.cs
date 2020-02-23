using System.Collections;
using UnityEngine;

public class FadeController : MonoBehaviour
{
	#region Private Members
	private CanvasGroup uiElement;
	#endregion

	#region Public Voids
	public void FadeIn(GameObject panel)
	{
		uiElement = panel.GetComponent<CanvasGroup>();
		StartCoroutine(FadeCanvasGroup(uiElement, 0.2f , 1, 1.5f));
	}

	public void FadeOut(GameObject panel)
	{
		uiElement = panel.GetComponent<CanvasGroup>();
		StartCoroutine(FadeCanvasGroup(uiElement, 1f , 0, 1f));
	}

	public IEnumerator FadeCanvasGroup(CanvasGroup cg, float startVal, float endVal, float lerpTime)
	{
		float timeStartedLerping = Time.time;
		float timeSinceStarted = Time.time - timeStartedLerping;
		float percentComplete = timeSinceStarted / lerpTime;
		while (true)
		{
			timeSinceStarted = Time.time - timeStartedLerping;
			percentComplete = timeSinceStarted / lerpTime;
			float currentValue = Mathf.Lerp(startVal, endVal, percentComplete);

			cg.alpha =currentValue;
			if (percentComplete >= 1)
			{
				break;
			}
			yield return new WaitForEndOfFrame();
		}
		if (cg.alpha < 0.1f)
		{
			cg.gameObject.SetActive(false);
		}
	}
	#endregion
}
