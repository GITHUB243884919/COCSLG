using System.IO;
using UnityEngine;
using System.Collections;

namespace UFrame.Util
{
    public class ScreenShot : MonoBehaviour
    {
        void Start()
        {
            StartCoroutine(CoScreenShot());
        }
        IEnumerator CoScreenShot()
        {
            yield return new WaitForEndOfFrame();
            int width = Screen.width;
            int height = Screen.height;
            Texture2D tex = new Texture2D(width, height, TextureFormat.RGB24, false);
            tex.ReadPixels(new Rect(0, 0, width, height), 0, 0);
            tex.Apply();
            byte[] bytes = tex.EncodeToPNG();
            File.WriteAllBytes(Application.dataPath + "/screen_shot.png", bytes);
            //UnityEditor.AssetDatabase.Refresh();
        }
    }
}

