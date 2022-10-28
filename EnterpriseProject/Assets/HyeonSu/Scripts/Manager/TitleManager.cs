using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;
public class TitleManager : MonoBehaviour
{
    [SerializeField] private Text StartText;

    private void Start()
    {
        StartCoroutine(BlickText());
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            SceneManager.LoadScene("NeglectTest");
    }
    IEnumerator BlickText()
    {
        StartText.DOColor(new Color(100 / 255f, 100 / 255f, 100 / 255f, 1), 1);
        yield return new WaitForSeconds(1);
        StartText.DOColor(new Color(0, 0, 0, 1), 1);
        yield return new WaitForSeconds(1);
        StartCoroutine(BlickText());
    }
}
