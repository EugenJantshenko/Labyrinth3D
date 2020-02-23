using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour 
{
	#region Private Members
	[SerializeField]
	private FadeController fadeController;
	[SerializeField]
	private GameObject mainMenuPanel;
	[SerializeField]
	private GameObject confirmPanel;
	[SerializeField]
	private GameObject creditsPanel;
	[SerializeField]
	private GameObject loadingPanel;
	#endregion

	#region Private Methods
	void Start()
	{
		ShowMainMenu();
		confirmPanel.SetActive (false);
		creditsPanel.SetActive (false);
		loadingPanel.SetActive(false);
	}

	private IEnumerator Delay(float time,string levelName)
	{
		yield return new WaitForSeconds(time);
		SceneManager.LoadScene(levelName);
	}
	#endregion

	#region Public Methods
	public void ShowMainMenu()
	{
		mainMenuPanel.SetActive(true);
		fadeController.FadeIn(mainMenuPanel);
	}

	public void PlayOption(string levelName)
	{
		mainMenuPanel.SetActive(false);
		loadingPanel.SetActive(true);
		StartCoroutine(Delay(1.0f, levelName));
	}

	public void ShowCredits()
	{
		creditsPanel.SetActive (true);
		fadeController.FadeIn(creditsPanel);
		fadeController.FadeOut(mainMenuPanel);
	}

	public void CloseCredits()
	{
		ShowMainMenu();
		fadeController.FadeOut(creditsPanel);
	}

	public void ShowQuitPanel()
	{
		confirmPanel.SetActive (true);
		fadeController.FadeIn(confirmPanel);
		fadeController.FadeOut(mainMenuPanel);
	}

	public void QuitGame()
	{
		Application.Quit ();
	}

	public void ReturnToMainMenu()
	{
		ShowMainMenu();
		fadeController.FadeOut(confirmPanel);
	}
	#endregion
}
