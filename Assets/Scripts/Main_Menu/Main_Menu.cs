using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Main_Menu : MonoBehaviour 
{
	public static bool GameIsPaused = false;
	public GameObject pasueMenuUI;
	public AudioMixer audioMixer;

	


	void Update() 
	{
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			if(GameIsPaused)
			{
				Resume();
			}else
			{
				Pause();
			}
		}
	}

	public void Resume()
	{
		pasueMenuUI.SetActive(false);
		Time.timeScale = 1f;
		GameIsPaused = false;
	}

	void Pause()
	{
		pasueMenuUI.SetActive(true);
		Time.timeScale = 0f;
		GameIsPaused = true;
	}

	public void SetVolume(float volume)
	{
		audioMixer.SetFloat("volume", volume);
	}

	public void SetQuality(int qualityIndex)
	{
		QualitySettings.SetQualityLevel(qualityIndex);
	}

	public void SetFullScreen (bool isFullsreen)
	{
		Screen.fullScreen = isFullsreen;
	}
	
	public void PlayPlay ()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void LoadMenu()
	{
		SceneManager.LoadScene("MainMenu");
	}

	public void Restart()
    {
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
	
	public void Quit ()
	{
		Debug.Log("Exciting...");
		Application.Quit();
	}



}