using System.Collections;
using UnityDLL;
using UnityEngine;
using TMPro;

public enum eSceneState
{
    Title,
    Play,
    Result,
}

public abstract class SceneBase : MonoBehaviour
{
    public SceneBase()
    {
    }

    public abstract void Open();
    public abstract void Close();
}

public class ProgressManager : SingletonMonoBehaviour<ProgressManager>
{
    [SerializeField]
    TextMeshPro textMesh = null;
    
    [SerializeField]
    TitleScene titleScene = null;
    
    [SerializeField]
    PlayScene playScene = null;

    [SerializeField]
    ResultScene resultScene = null;

    SceneBase currentScene = null;


    void OnGameResult()
    {
        MoveScene(eSceneState.Result);
    }

    private void Start()
    {
        currentScene = titleScene;
        titleScene.gameObject.SetActive(true);
        playScene.gameObject.SetActive(false);
        resultScene.gameObject.SetActive(false);
    }

    void OnEnable()
    {
        EventManager.OnGameResult += OnGameResult;
    }

    void OnDisable()
    {
        EventManager.OnGameResult -= OnGameResult;
    }

    void UpdateHUD()
    {
    }


    private void Update()
    {
    }

    public void MoveScene(eSceneState sceneState)
    {
        currentScene.Close();

        switch (sceneState)
        {
            case eSceneState.Title:
                currentScene = titleScene;
                    break;
            case eSceneState.Play:
                currentScene = playScene;
                break;
            case eSceneState.Result:
                currentScene = resultScene;
                break;
        }

        currentScene.Open();
    }

}
