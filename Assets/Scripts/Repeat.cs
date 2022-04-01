using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
public class Repeat : MonoBehaviour
{
    Levels levels;
    public Button repeatButton;
    public GameObject background;
    DoGraphics graphics;
    private void Start()
    {
        levels = GameObject.Find("SpawnManager").GetComponent<Levels>();
        graphics = GameObject.Find("SpawnManager").GetComponent<DoGraphics>();
        background.GetComponent<SpriteRenderer>().DOFade(0, 0);

    }
    private void Update()
    {
        if (levels.isGameEnd)
        {
            repeatButton.gameObject.SetActive(true);
            graphics.BackGroundFade(background.GetComponent<SpriteRenderer>());

        }
    }
    public void RepeatGame()
    {
        SceneManager.LoadScene(0);
    }
}
