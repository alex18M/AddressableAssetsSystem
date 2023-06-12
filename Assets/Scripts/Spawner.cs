using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{

    [SerializeField] private Button _spawnButton;
    [SerializeField] private Button _releaseButton;
    [SerializeField] private Button _loadNextSceneButton;
    // [SerializeField] private GameObject _prefab;
    [SerializeField] private AssetReference _assetReference;
    
    
    // Start is called before the first frame update
    void Start()
    {
        _spawnButton.onClick.AddListener(SpawnObject);
        _releaseButton.onClick.AddListener(ReleaseAssetReference);
        _loadNextSceneButton.onClick.AddListener(LoadNextScene);

        var asyncOperantionHandle = _assetReference.LoadAssetAsync<GameObject>(); //cargar de disco a memoria el objeto que le indiquemos
        asyncOperantionHandle.Completed += OnCompleted;
    }

    private void LoadNextScene()
    {
        SceneManager.LoadSceneAsync("SecondScene");
    }

    private void ReleaseAssetReference()
    {
      _assetReference.ReleaseAsset();
    }

    private void OnCompleted(AsyncOperationHandle<GameObject> obj)
    {
        Debug.Log("Completed");
    }

    // Update is called once per frame
    private void SpawnObject()
    {
        // Instantiate(_prefab);
        _assetReference.InstantiateAsync();
    }
}
