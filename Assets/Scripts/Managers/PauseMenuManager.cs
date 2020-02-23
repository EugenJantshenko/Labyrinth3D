using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenuManager : MonoBehaviour 
{
	public SensetivityEnum sensetivity;
	public bool isPaused;

	#region Controllers links
	[SerializeField]
	private FadeController fadeController;
	[SerializeField]
	private AudioManager audioManager;
	private SpawnConfettiController confettiController;
	#endregion

	#region UI Elements
	[SerializeField]
	private GameObject loadingPanel;
	[SerializeField]
	private GameObject pauseMenuPanel;
	[SerializeField]
	private GameObject playNextButton;
	[SerializeField]
	private GameObject resumeButton;
	[SerializeField]
	private GameObject pauseButton;
	[SerializeField]
	private Text infoText;
	[SerializeField]
	private Text coutdownText;
	#endregion

	#region Private Members
	[SerializeField]
	float startinTime = 30f;
	float currentTime = 0f;
	#endregion

	#region Private Methods
	void Start()
	{
		confettiController = GetComponent<SpawnConfettiController>();
		currentTime = startinTime;
		sensetivity = SensetivityEnum.Fast;
	}

	private void Update()
	{
		TimerCoutdown();
	}

	private IEnumerator Delay(float time, string levelName)
	{
		yield return new WaitForSeconds(time);
		SceneManager.LoadScene(levelName);
	}	

	private void TimerCoutdown()
	{
		if (currentTime > 0)
		{
			currentTime -= 1 * Time.deltaTime;
		}
		coutdownText.text = "Time left: " + currentTime.ToString("0") + " s.";
		if (currentTime < 0)
		{
			Lose();
			currentTime = 0;
			Debug.Log(currentTime);
		}
		else if (currentTime < 20 && currentTime > 10)
		{
			coutdownText.color = Color.yellow;
		}
		else if (currentTime < 10)
		{
			coutdownText.color = Color.red;
		}
	}

	private void ChangePanels(float timeScale, bool pausePanel,string info, bool playNext, bool pause)
	{
		Time.timeScale = timeScale;
		pauseMenuPanel.SetActive(pausePanel);
		infoText.text = info;
		playNextButton.SetActive(playNext);
		pauseButton.SetActive(pause);
	}

	private void WinOrLoseActions(bool win)
	{
		audioManager.StopPlayLevelMusic();
		audioManager.PlaySound(win);
		resumeButton.SetActive(false);
	}
	#endregion

	#region Public Methods
	public void LoadNextLevel()
	{
		Time.timeScale = 1f;
		int scenesCount = SceneManager.sceneCountInBuildSettings;
		if (SceneManager.GetActiveScene().buildIndex < scenesCount-1)
		{
			pauseMenuPanel.SetActive(false);
		loadingPanel.SetActive(true);
		StartCoroutine(Delay(1.0f, "Level" + (SceneManager.GetActiveScene().buildIndex + 1).ToString()));
	  }
		else
		{
			infoText.text = "No more Scenes";
		}
	}

	public void PausedGame()
	{
		ChangePanels(0f, true, "Pause", false, false);
		isPaused = true;
	}

	public void ResumeGame()
	{
		ChangePanels(1f,false,"", false ,true);
		isPaused = false;
	}

	public void ShowMainMenu()
	{
		ChangePanels(1f, false, "", false, false);
		loadingPanel.SetActive(true);
		StartCoroutine(Delay(1.0f, "MainMenu"));
	}

	public void ReloadLevel()
	{
		ChangePanels(1f, false, "", false, false);
		loadingPanel.SetActive(true);
		StartCoroutine(Delay(1.0f, SceneManager.GetActiveScene().name));
	}

	public void Win()
	{
		ChangePanels(0.8f, true, "Congratulation You Win!!!!", true, false);
		currentTime = 0;
		WinOrLoseActions(true);
		confettiController.SpawnConfetti();		
	}

	public void Lose()
	{
		ChangePanels(0.8f, true, "Sorry You Lose!!!!",false,false);
		WinOrLoseActions(false);		
	}
	#endregion
}
