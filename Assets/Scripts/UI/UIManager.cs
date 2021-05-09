﻿using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Audio;

namespace UI {

    public class UIManager : MonoBehaviour {

        public static UIManager Instance;

        [SerializeField]
        private Fader _fader;

        [SerializeField]
        private GameObject _menuScreen;

        [SerializeField]
        private GameObject _gameScreen;

        [SerializeField]
        private GameObject _leaderboardScreen;

        [SerializeField]
        private GameObject _settingsScreen;

        [SerializeField]
        private MusicManager _musicManager;

        private void Awake() {
            if (Instance != null) {
                Destroy(gameObject);
                return;
            }

            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        public void LoadMenu() {
            _fader.OnFadeOut += LoadMenuScene;
            _fader.OnFadeOut += _musicManager.PlayMenuMusic;
            _fader.FadeOut();
        }

        public void LoadGameplay() {
            _fader.OnFadeOut += LoadGameplayScene;
            _fader.OnFadeOut += _musicManager.PlayGameplayMusic;
            _fader.FadeOut();
        }

        private void LoadMenuScene() {
            _fader.OnFadeOut -= LoadMenuScene;
            _fader.OnFadeOut -= _musicManager.PlayMenuMusic;
            StartCoroutine(LoadSceneCoroutine("Menu"));
            ShowMenuScreen();
        }

        private void LoadGameplayScene() {
            _fader.OnFadeOut -= LoadGameplayScene;
            _fader.OnFadeOut -= _musicManager.PlayGameplayMusic;
            StartCoroutine(LoadSceneCoroutine("Gameplay"));
            ShowGameScreen();
        }

        private IEnumerator LoadSceneCoroutine(string sceneName) {
            var asyncOperation = SceneManager.LoadSceneAsync(sceneName);
            while (!asyncOperation.isDone) {
                yield return null;
            }
            _fader.FadeIn();
        }

        public void ShowMenuScreen() {
            HideAllScreens();
            _menuScreen.SetActive(true);
            _musicManager.PlayMenuMusic();
        }

        public void ShowGameScreen() {
            HideAllScreens();
            _gameScreen.SetActive(true);
        }

        public void ShowLeaderboardScreen() {
            HideAllScreens();
            _leaderboardScreen.SetActive(true);
        }

        public void ShowSettingsScreen() {
            HideAllScreens();
            _settingsScreen.SetActive(true);
        }

        public void HideAllScreens() {
            _menuScreen.SetActive(false);
            _gameScreen.SetActive(false);
            _leaderboardScreen.SetActive(false);
            _settingsScreen.SetActive(false);
        }

        private void Start() {
            ShowMenuScreen();
        }
    }
}