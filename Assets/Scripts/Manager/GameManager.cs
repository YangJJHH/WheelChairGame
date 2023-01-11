using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public enum State
{
    NORMAL = 1,
    NOTMOVE = 2,
}
public class GameManager : SingletonMonobehaviour<GameManager>
{
    
    private State state= State.NORMAL;
    public State CurrentState { get => state; }
 
    // Start is called before the first frame update
    public void Start()
    {
        UIManager.Instance.FadeIn();
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver()
    {
        state = State.NOTMOVE;
    }

    public void GameEnd()
    {
        GameOver();
        UIManager.Instance.FadeOut(() =>
        {
            SceneManager.LoadScene(0);
        });
        ;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UIManager.Instance.ToggleUI();
        }
    }
}
