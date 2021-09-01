using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
using Photon.Realtime;
using Hashtable = ExitGames.Client.Photon.Hashtable;

namespace com.hash.cwar.network
{
    public class Timer : MonoBehaviourPunCallbacks
    {
        [SerializeField]
        private RoomManager roomManager;

        [SerializeField]
        private TextMeshProUGUI timeText;

        private float Countdown = GameProperties.gameTime;

        private bool isTimerRunning = false;

        private int startTime;

        public void Update()
        {
            if (!isTimerRunning) return;

            float countdown = TimeRemaining();

            int minute = Mathf.FloorToInt(countdown / 60);
            int second = Mathf.FloorToInt(countdown % 60);
            timeText.text = string.Format("{0:00}:{1:00}", minute, second);

            if (countdown >= 0.0f) return;
            isTimerRunning = false;
            roomManager.EndGame();
        }

        public override void OnRoomPropertiesUpdate(Hashtable propertiesThatChanged)
        {
            if(!isTimerRunning)
                Initialize();
        }

        private void Initialize()
        {
            int propStartTime;
            if (TryGetStartTime(out propStartTime))
            {
                startTime = propStartTime;
                isTimerRunning = true;
            }
        }

        private float TimeRemaining()
        {
            int timer = PhotonNetwork.ServerTimestamp - startTime;
            return Countdown - timer / 1000f;
        }

        public bool TryGetStartTime(out int startTimestamp)
        {
            startTimestamp = PhotonNetwork.ServerTimestamp;

            object startTimeFromProps;
            if (PhotonNetwork.CurrentRoom.CustomProperties.TryGetValue(CustomProperties.roomStartTime, out startTimeFromProps))
            {
                startTimestamp = (int)startTimeFromProps;
                return true;
            }

            return false;
        }

        public void SetStartTime()
        {
            Hashtable props = new Hashtable
            {
                {CustomProperties.roomStartTime, (int)PhotonNetwork.ServerTimestamp}
            };
            PhotonNetwork.CurrentRoom.SetCustomProperties(props);
        }
    }

}
