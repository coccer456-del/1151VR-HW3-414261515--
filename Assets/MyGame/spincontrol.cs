
using UnityEngine;

public class spincontrol : MonoBehaviour
{
    // 要旋轉的轉盤
    public Transform spinner;

    // 轉盤音效
    public AudioSource spinSound;

    // 初始旋轉速度
    public float spinSpeed = 900f;

    // 旋轉時間：6 秒
    public float spinDuration = 6f;

    private bool isSpinning = false;
    private float elapsedTime = 0f;

    void Update()
    {
        if (!isSpinning) return;

        elapsedTime += Time.deltaTime;

        // 旋轉進度：從 0 到 1
        float progress = Mathf.Clamp01(
            elapsedTime / spinDuration
        );

        // 逐漸減速
        float currentSpeed =
            spinSpeed * (1f - progress);

        // 順時針旋轉
        spinner.Rotate(
            0f,
            0f,
            -currentSpeed * Time.deltaTime
        );

        // 6 秒後停止
        if (progress >= 1f)
        {
            isSpinning = false;
        }
    }

    void OnMouseDown()
    {
        // 正在旋轉時，不能再按
        if (isSpinning || spinner == null)
            return;

        elapsedTime = 0f;
        isSpinning = true;

        // 播放音效
        if (spinSound != null)
        {
            spinSound.Stop();
            spinSound.Play();
        }
    }
}
