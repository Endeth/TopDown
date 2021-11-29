using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TopDown
{
    public class LevelController : MonoBehaviour, Observer<bool>
    {
        [SerializeField] private string nextLevelName;
        private KillSpecificMonsters _levelObjective;
        private Player _player;
        private MonsterManager _monsterManager;
        bool _finished = false;
        void OnEnable()
        {
            _player = FindObjectOfType<Player>();
            _monsterManager = FindObjectOfType<MonsterManager>();
            _levelObjective = GetComponent<KillSpecificMonsters>();
            _levelObjective.Attach( this );
            _monsterManager.Attach( _levelObjective );
        }

        void Start()
        {
            EventManager.TriggerEvent( Events.Type.GameStart );
        }
        public void HandleEvent( bool eventParams )
        {
            int objectivesCount = 1; //Look for objectives count, objectives might be better as children of this
            objectivesCount--;
            if( objectivesCount == 0 )
            {
                FinishLevel();
            }
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
            if( !_player.IsAlive() && !_finished )
            {
                _finished = true;
                StartCoroutine( DelayedDefeat() );
            }
        }
    }
}
