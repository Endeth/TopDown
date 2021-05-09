using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    private Player _player;
    private Monster[] _monsters;
    [SerializeField] private string nextLevelName;
    void OnEnable()
    {
        _player = FindObjectOfType<Player>();
        _monsters = FindObjectsOfType<Monster>();
    }

    private bool CheckMonsters()
    {
        foreach( var monster in _monsters )
        {
            if( monster.IsAlive )
            {
                return false;
            }
        }
        return true;
    }

    void Start()
    {
        Time.timeScale = 0f;
    }

    IEnumerator DelayedQuit()
    {
        yield return new WaitForSeconds( 2 );

        Application.Quit();
    }

    IEnumerator DelayedDefeat()
    {
        yield return new WaitForSeconds( 2 );

        EventManager.TriggerEvent( Events.Type.Defeat );
        StartCoroutine( DelayedQuit() );
    }

    IEnumerator GoToNextLevel()
    {
        yield return new WaitForSeconds( 3 );

        if( nextLevelName.Length > 0 )
            SceneManager.LoadScene( nextLevelName );
        else
            Application.Quit();
    }

    private void FinishLevel()
    {
        EventManager.TriggerEvent( Events.Type.Victory );
        StartCoroutine( GoToNextLevel() );
    }

    void Update()
    {
        if( Input.GetMouseButtonDown( 0 ) )
            Time.timeScale = 1f;

        if( CheckMonsters() )
        {
            FinishLevel();
        }
        else if( !_player.IsAlive )
        {
            StartCoroutine( DelayedDefeat() );
        }
    }
}
