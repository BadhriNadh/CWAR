using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using Hashtable = ExitGames.Client.Photon.Hashtable;

namespace com.hash.cwar.network
{
    public class Connect : MonoBehaviourPunCallbacks
    {
        bool isConnecting;

        [SerializeField]
        private GameObject networkerror;

        void setLocalPlayerData()
        {
            PhotonNetwork.LocalPlayer.NickName = "Badhri";
        }

        public void OnStartClicked()
        {
            setLocalPlayerData();
            isConnecting = true;

            if (PhotonNetwork.IsConnected)
			{
				PhotonNetwork.JoinRandomRoom();
			}else{
				PhotonNetwork.ConnectUsingSettings();
                PhotonNetwork.GameVersion = GameProperties.gameVersion;
			}
        }

        public override void OnConnectedToMaster()
        {
            if (isConnecting)
            {
                PhotonNetwork.JoinRandomRoom();
            }
        }

        public override void OnJoinRandomFailed(short returnCode, string message)
        {
            CreateRoom();
        }

        void CreateRoom()
        {
            RoomOptions roomOps = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = GameProperties.maxPlayers };

            // This need to be worked on.
            roomOps.PlayerTtl = GameProperties.playerTimeout;

            // Name the room if nneded replace null.
            PhotonNetwork.CreateRoom(null, roomOps);
        }

        public override void OnCreateRoomFailed(short returnCode, string message)
        {
            CreateRoom();
        }

        public override void OnJoinedRoom()
        {
            if (PhotonNetwork.IsMasterClient)
            {
                StartCoroutine(GameSetup());
            }
        }

        public override void OnDisconnected(DisconnectCause cause)
        {
            isConnecting = false;
            if(cause.Equals(DisconnectCause.ClientTimeout) || cause.Equals(DisconnectCause.ServerTimeout) || cause.Equals(DisconnectCause.DnsExceptionOnConnect))
            {
                networkerror.SetActive(true);
            }
        }

        IEnumerator GameSetup()
        {
            yield return new WaitForSeconds(Random.Range(10, 15));
            PhotonNetwork.CurrentRoom.IsVisible = false;
            PhotonNetwork.CurrentRoom.IsOpen = false;
            SetplayersData();

            yield return new WaitForSeconds(3);
            PhotonNetwork.AutomaticallySyncScene = true;
            PhotonNetwork.LoadLevel(GameProperties.gameScene);
        }

        void SetplayersData()
        {
            string nextTeam = Team.A;
            for (int i = 0; i < PhotonNetwork.PlayerList.Length; i++)
            {
                Player player = PhotonNetwork.PlayerList[i];

                Hashtable team = new Hashtable();
                team.Add(CustomProperties.playerTeam, nextTeam);
                player.SetCustomProperties(team);

                if (nextTeam.Equals(Team.A))
                    nextTeam = Team.B;
                else
                    nextTeam = Team.A;
            }
        }
    }
}
