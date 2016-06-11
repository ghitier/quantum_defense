using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	/* Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}*/

	public void play_game()
	{
		SceneManager.LoadScene("main", LoadSceneMode.Single);
	}

	public void quit_game()
	{
		Application.Quit();
	}
}
