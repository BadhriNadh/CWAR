using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;
using TMPro;

namespace com.hash.cwar.network
{
    public class Room : MonoBehaviourPunCallbacks
    {
        [SerializeField]
        private RoomManager roomManager;

        [SerializeField]
        private TextMeshProUGUI[] nameHoldersA;

        [SerializeField]
        private TextMeshProUGUI[] nameHoldersB;

        [SerializeField]
        private GameObject networkError;

        private void Awake()
        {
            int A = 0, B = 0;
            for (int i = 0; i < PhotonNetwork.PlayerList.Length; i++)
            {
                Player player = PhotonNetwork.PlayerList[i];
                object team;
                if (player.CustomProperties.TryGetValue(CustomProperties.playerTeam, out team))
                {
                    if (((string)team).Equals(Team.A))
                    {
                        nameHoldersA[A].text = player.NickName;
                        A++;
                    }

                    if (((string)team).Equals(Team.B))
                    {
                        nameHoldersB[B].text = player.NickName;
                        B++;
                    }
                }
            }
            
        }

        private void Start() 
        {
            PhotonNetwork.Instantiate("NetworkObject", transform.position, Quaternion.identity);
            StartCoroutine(roomManager.StartGame());
        }

        public override void OnDisconnected(DisconnectCause cause)
        {
            if (cause.Equals(DisconnectCause.ClientTimeout) || cause.Equals(DisconnectCause.ServerTimeout) || cause.Equals(DisconnectCause.DnsExceptionOnConnect))
            {
                networkError.SetActive(true);
            }
        }
    }
}