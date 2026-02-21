using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarMiniGame : MonoBehaviour
{
    public Transform needle;
    public Transform targetArea;

    [Header("Settings")]
    public float needleSpeed = 1f;
    public float barWidth = 1f;
    private int successCount = 0;
    private bool isPlaying = true;
    private bool movingRight = true;
    private Vector3 initialTargetScale;

    void Awake()
    {
        initialTargetScale = targetArea.localScale;
        targetArea.localPosition = new Vector3(targetArea.localPosition.x, targetArea.localPosition.y, -1f);
        needle.localPosition = new Vector3(needle.localPosition.x, needle.localPosition.y, -2f);
    }

    void OnEnable()
    {
        ResetMiniGame();
    }

    void Update()
    {
        if (!isPlaying) return;

        MoveNeedle();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            CheckSuccess();
        } // end of if

    } // end of onUpdate

    void MoveNeedle()
    {
        Vector3 pos = needle.localPosition;

        if (movingRight)
            pos.x += needleSpeed * Time.deltaTime;
        else
            pos.x -= needleSpeed * Time.deltaTime;

        float edgeLimit = barWidth * 0.45f;

        // reverse
        if (pos.x >= edgeLimit)
            movingRight = false;
        else if (pos.x <= -edgeLimit)
            movingRight = true;

        pos.z = -2f;
        needle.localPosition = pos;
    } // end of moveNeedle

    void CheckSuccess()
    {
        float targetX = targetArea.localPosition.x;
        float needleX = needle.localPosition.x;

        float halfTargetWidth = targetArea.localScale.x / 2f;

        if (Mathf.Abs(needleX - targetX) <= halfTargetWidth)
        {
            successCount++;
            if (successCount >= 3)
            {
                Debug.Log("Mini-game Completed!");
                HideMiniGame();
            }
            else
            {
                ProgressGame();
            }
        }
        else
        {
            Debug.Log("Try Again!");
            ResetMiniGame();
        }
    }

    void ProgressGame()
    {
        targetArea.localScale = new Vector3(targetArea.localScale.x * 0.6f, targetArea.localScale.y, targetArea.localScale.z);
        float randomX = Random.Range(-0.35f, 0.35f);
        targetArea.localPosition = new Vector3(randomX, targetArea.localPosition.y, -1f);

        needleSpeed += 0.2f;
    }

    public void ResetMiniGame()
    {
        successCount = 0;
        needleSpeed = 1f;
        targetArea.localScale = initialTargetScale;
        targetArea.localPosition = new Vector3(0, 0, -1f);
        needle.localPosition = new Vector3(0, 0, -2f);

        isPlaying = true;
    }

    public void HideMiniGame()
    {
        References.Instance.menuManager.HideInteractPrompt();
        isPlaying = false;
        gameObject.SetActive(false);
    } // end of hideMiniGame

    public void showMiniGame()
    {
        gameObject.SetActive(true);
    }

} // end of BarMiniGame