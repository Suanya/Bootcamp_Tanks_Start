using System;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Tanks
{
    public class MainMenuController : MonoBehaviourPunCallbacks
    {
        [SerializeField] private Button playButton;
        [SerializeField] private Button lobbyButton;
        [SerializeField] private Button settingsButton;
        [SerializeField] private SettingsController settingsPopup;

        private void Start()
        {
            // TODO: Connect to photon server
            PhotonNetwork.ConnectUsingSettings();

            playButton.onClick.AddListener(JoinRandomRoom);
            lobbyButton.onClick.AddListener(GoToLobbyList);
            settingsButton.onClick.AddListener(OnSettingsButtonClicked);

            settingsPopup.gameObject.SetActive(false);
            settingsPopup.Setup();

            if (!PlayerPrefs.HasKey("PlayerName"))
                PlayerPrefs.SetString("PlayerName", "Player #" + Random.Range(0, 9999));
        }

        public override void OnConnectToMaser()
        {
            base.OnConnectedToMaster();
        }
        
        private void OnSettingsButtonClicked()
        {
            settingsPopup.gameObject.SetActive(true);
        }

        public void JoinRandomRoom()
        {
            // TODO: Connect to a random room
        }

        private void GoToLobbyList()
        {
            SceneManager.LoadSceneAsync("LobbyList");
        }
    }
}