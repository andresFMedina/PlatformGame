using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public GameObject[] SystemPrefabs;

    private List<GameObject> _instacedSystemPrefabs = new List<GameObject>();    

    private string _currentLevelName = string.Empty;
    private List<AsyncOperation> _loadOperations;   

    private void Start()
    {
        DontDestroyOnLoad(gameObject);

        _loadOperations = new List<AsyncOperation>();

        InstaciateSystemPrefabs();

        LoadLevel("MainScene");
    }

    void OnLoadOperationComplete(AsyncOperation ao)
    {
        if (_loadOperations.Contains(ao))
        {
            _loadOperations.Remove(ao);
        }

        Debug.Log("Load Complete");
    }

    void OnUnloadOperationComplete(AsyncOperation ao)
    {
        Debug.Log("Unload Complete");
    }

    void InstaciateSystemPrefabs()
    {
        GameObject prefabInstance;
        for (int i = 0; i < SystemPrefabs.Length; i++)
        {
            prefabInstance = Instantiate(SystemPrefabs[i]);
            _instacedSystemPrefabs.Add(prefabInstance);
        }
    }

    public void LoadLevel(string levelName)
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(levelName, LoadSceneMode.Additive);
        if(asyncOperation == null)
        {
            Debug.LogError("Unable to load level" + _currentLevelName);
            return;
        }
        asyncOperation.completed += OnLoadOperationComplete;
        _loadOperations.Add(asyncOperation);
        _currentLevelName = levelName;
    }

    public void UnloadLevel(string levelName)
    {
        AsyncOperation asyncOperation = SceneManager.UnloadSceneAsync(levelName);
        if (asyncOperation == null)
        {
            Debug.LogError("Unable to unload level" + _currentLevelName);
            return;
        }
        asyncOperation.completed += OnUnloadOperationComplete;
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();

        foreach (GameObject prefab in _instacedSystemPrefabs)
        {
            Destroy(prefab);
        }
        _instacedSystemPrefabs.Clear();
    }
}
