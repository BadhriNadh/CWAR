using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using com.hash.cwar.network;

namespace com.hash.cwar.game
{
    public class PortManager : MonoBehaviour
    {
        public void loadMainScene()
        {
            SceneManager.LoadScene(GameProperties.mainScene);
        }
    }
}
