using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

namespace com.hash.cwar.network
{
    public class RoomManager : MonoBehaviour
    {
        
        public Timer timer;

        [SerializeField]
        private GameObject DisplayUI;

        [SerializeField]
        private GameObject GamePlayUI;

        [SerializeField]
        private GameObject WaitUI;

        [SerializeField]
        private GameObject EndUI;

        public IEnumerator StartGame()
        {
            yield return new WaitForSeconds(3);
            DisplayUI.SetActive(false);
            GamePlayUI.SetActive(true);
            
            yield return new WaitForSeconds(3);
            if (PhotonNetwork.IsMasterClient)
                timer.SetStartTime();
            WaitUI.SetActive(false);
        }


        public void EndGame()
        {
            GamePlayUI.SetActive(false);
            EndUI.SetActive(true);
            ManualDisconnect();
        }

        public void ManualDisconnect()
        {
            PhotonNetwork.Disconnect();
        }
    }
}
