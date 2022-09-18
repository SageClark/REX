using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Light2D _globalLight;
    [SerializeField]
    private GameObject _gameOverText;
    [SerializeField]
    private GameObject _restartButton;
    [SerializeField]
    private GameObject _quitGameButton;

    private GameObject[] _allOtherLights;

    private float _timeToWait;

    private bool _gameOver = false;


    void Start()
    {
        _allOtherLights = GameObject.FindGameObjectsWithTag("Light");
    }

    // Update is called once per frame
    void Update()
    {
        if(_gameOver && _globalLight.intensity > 0)
        {
            if (Time.time > _timeToWait)
            {
                if (_allOtherLights.Length > 0)
                {
                    foreach(GameObject go in _allOtherLights)
                    {
                        Destroy(go);
                    }
                }
                _globalLight.intensity = _globalLight.intensity - 0.12f;
                _timeToWait = Time.time + 1;
            }
        }

        if(_globalLight.intensity <= 0)
        {
            _gameOverText.SetActive(true);
            _restartButton.SetActive(true);
            _quitGameButton.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void GameOver()
    {
        _gameOver = true;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
        
}
