using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TopDown
{
    [CreateAssetMenu( menuName = "TopDown/UI/MainMenu" )]
    public class MainMenu : ScriptableObject
    {
        [SerializeField] private string _firstLevel;
        [SerializeField] private string _previousLevel;
        public void LoadScene()
        {
            SceneManager.LoadScene( _firstLevel );
        }

        public void StartGame( string _levelName )
        {

        }
    }
}
