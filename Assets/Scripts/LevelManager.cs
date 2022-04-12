using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;
    public GameObject player;
    public LineRenderer menuLineRenderer;

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public IEnumerator ResetPlayer()
    {
        while (true)
        {
            string sceneName = SceneManager.GetActiveScene().name;
            Debug.Log(sceneName);
            if (sceneName == "main")
            {
                // TODO: Disable laserpointer
                menuLineRenderer.enabled = false;
                player.transform.position = new Vector3(0, 100, 0);
                yield break;
            }
            yield return new WaitForSeconds(.5f);
        }
    }

}
