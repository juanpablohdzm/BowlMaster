using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
    public float AutoLoadLevelTime;

    private void Start()
    {
        //Delay for splash screen
        if(AutoLoadLevelTime>0)
        Invoke("LoadNextLevel", AutoLoadLevelTime);
       
    }
    public void LoadLevel(string name)
    { 
		SceneManager.LoadScene (name);
	}

	public void QuitRequest()
    {
		Application.Quit ();
	}

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
       
    }

}
