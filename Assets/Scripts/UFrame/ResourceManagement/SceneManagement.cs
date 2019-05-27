using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UFrame.Common;
using UnityEngine.SceneManagement;

namespace UFrame.ResourceManagement
{
    public class SceneManagement : Singleton<SceneManagement>, ISingleton
    {
        System.Action cb;
        public void Init()
        {
        }

        public void LoadScene(string scenePath, System.Action callback)
        {
            cb = callback;
            SceneManager.sceneLoaded += SceneLoadedCallback;
            ResHelper.LoadScene(scenePath);
        }

        public void UnLoadScene()
        {
            SceneManager.sceneLoaded -= SceneLoadedCallback;
        }

        void SceneLoadedCallback( Scene a , LoadSceneMode b )
        {
            if (cb != null)
            {
                cb();
            }
        }
    }
}

