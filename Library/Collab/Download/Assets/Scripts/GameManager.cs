using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour {
    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }
    public int minMonsterKill = 10;
    public delegate void WinLoseAction(bool won);
    public static event WinLoseAction OnWinLoseAction;
    public bool noDying = true;
    public bool noEndScreen = false;
    public bool mobileControls = false;

    private void Awake()
    {

        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }

    }

    private void OnEnable()
    {
        //MonsterKillStats.OnMonsterCountChanged += CheckWonGame;
    }
    void CheckWonGame(int monsterkills)
    {
        //if(monsterkills >= minMonsterKill)
        //{
        //    WinGame();
        //}
    }
    public void WinGame()
    {
        if(noEndScreen)
        {

        }
        else
        {
            if (OnWinLoseAction != null)
                OnWinLoseAction(true);
        }

        //Time.timeScale = 0;
        //if(winScreen != null)
        //winScreen.SetActive(true);
        //IEnumerator coroutine = SetWinScreen(1f);
        //StartCoroutine(coroutine);
    }
    IEnumerator SetWinScreen(float waitTime)
    {
      
        yield return new WaitForSeconds(waitTime);
        Time.timeScale = 0;

    }
    public void ResetStats()
    {
        MonsterKillStats.monstersKilled = 0;
        Destroy(this.gameObject);

        //Time.timeScale = 1;
        //Time.fixedDeltaTime = 1;

    }
    public void LoseGame()
    {
        if(noDying || noEndScreen)
        {

        }
        else
        {
            if (OnWinLoseAction != null)
                OnWinLoseAction(false);
        }

    }
	// Use this for initialization
	void Start () {
        Time.timeScale = 1;

    }

    // Update is called once per frame
    void Update () {
		
	}

}
