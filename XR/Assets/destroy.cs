using TMPro;
using UnityEngine;

public class destroy : MonoBehaviour
{
    #region Public Variables
    public TextMeshProUGUI scoreText;
    public int score = 0;
    #endregion

    #region Public Methods
    public void Destroy()
    {
        score++;
        scoreText.text = "" + score;
        PlayerPrefs.SetInt("PlayerScore", score);
        PlayerPrefs.Save();
        Destroy(gameObject);
    }
    #endregion

    #region Private Methods
    void Start()
    {
        if (PlayerPrefs.HasKey("PlayerScore"))
        {
            score = PlayerPrefs.GetInt("PlayerScore");
            scoreText.text = "" + score;
        }
    }
    #endregion
}
