using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

namespace com.hash.cwar.network
{
    public class Object : MonoBehaviour
    {
        private void Awake()
        {
            Player myPlayer = PhotonNetwork.LocalPlayer;
        }

    }
}
