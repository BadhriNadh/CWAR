using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using com.hash.cwar.network;

namespace com.hash.cwar.game
{
    public class MainManager : MonoBehaviour
    {
        public void reloadMainScene()
        {
            SceneManager.LoadScene(GameProperties.mainScene);
        }
    }
}
