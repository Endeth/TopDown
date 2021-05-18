using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TopDown
{
    public class LevelController : MonoBehaviour
    {
        private Player _player;
        private List<Monster> _monsters = new List<Monster>();
        [SerializeField] private string nextLevelName;
        bool _finished = false;
        void OnEnable()
        {
            _player = FindObjectOfType<Player>();
            _monsters.AddRange( FindObjectsOfType<Monster>() );
        }

        private bool CheckMonsters()
        {
            if( !_monsters.Exists( monster => monster.IsAlive() ) )
                return true;
            return false;
        }

        IEnumerator DelayedQuit()
        {
            yield return new WaitForSeconds( 2 );

            SceneManager.LoadScene( "MainMenu" );
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
                SceneManager.LoadScene( "MainMenu" );
        }

        private void FinishLevel()
        {
            _finished = true;
            EventManager.TriggerEvent( Events.Type.Victory );
            StartCoroutine( GoToNextLevel() );
        }

        void Update()
        {
            if( Input.GetMouseButtonDown( 0 ) )
            {
                EventManager.TriggerEvent( Events.Type.GameStart );
            }

            if( CheckMonsters() && !_finished )
            {
                FinishLevel();
            }
            else if( !_player.IsAlive() && !_finished )
            {
                _finished = true;
                StartCoroutine( DelayedDefeat() );
            }
        }
    }
}
