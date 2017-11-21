using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class LoadAssetBundle : MonoBehaviour
{
    GameObject _gameObject = null;
    public string bundleUri = "";
    public string objectName = "";
    public Vector3 position;
    public Vector3 rotation;
    public Vector3 scale;

    void Start()
    {
        StartCoroutine(InstantiateObject());
    }

    IEnumerator InstantiateObject()

    {
        //string uri = "file:///" + "C:/unityprojects/Networking/Assets" + "/AssetBundles/" + "remote";
        //string uri = "http://10.0.0.206:8089/" + "remote";
        UnityEngine.Networking.UnityWebRequest request = UnityEngine.Networking.UnityWebRequest.GetAssetBundle(bundleUri, 0);
        yield return request.SendWebRequest();
        AssetBundle bundle = DownloadHandlerAssetBundle.GetContent(request);
        var gameObject = bundle.LoadAsset<GameObject>(objectName);
        _gameObject = Instantiate(gameObject);
        //_gameObject.transform.position = new Vector3(-2.46f, 0.2f, 3f);
        //_gameObject.transform.eulerAngles = new Vector3(-70, 180, 0);
        //_gameObject.transform.localScale = new Vector3(.001f, .001f, .001f);
        _gameObject.transform.position = position;
        _gameObject.transform.eulerAngles = rotation;
        _gameObject.transform.localScale = scale;
        _gameObject.AddComponent<Spinner>();
    }
}
