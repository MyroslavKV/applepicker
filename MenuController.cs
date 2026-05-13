using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuController : MonoBehaviour
{
    public GameObject PanelSettings;
    public GameObject BT_Song;
    public Sprite SongOn;
    public Sprite SongOff;
    public TMP_Text bestScoreText;

    public int PlaySongId = 1;

    private void Start()
    {
        PanelSettings.SetActive(false);

        if (PlaySongId == 1)
        {
            BT_Song.GetComponent<Image>().sprite = SongOn;
        }
        else if (PlaySongId == 0)
        {
            BT_Song.GetComponent<Image>().sprite = SongOff;
        }

        bestScoreText.text = "Best Score: " + PlayerPrefs.GetInt("BestScore", 0);
    }

    public void OnClickBT_Start()
    {
        SceneManager.LoadScene("Game");
    }

    public void OnClickBT_Settings_On()
    {
        PanelSettings.SetActive(true);
    }

    public void OnClickBT_Settings_Off()
    {
        PanelSettings.SetActive(false);
    }

    public void OnClickButt_Soung()
    {
        if (PlaySongId == 0)
        {
            PlaySongId = 1;
            BT_Song.GetComponent<Image>().sprite = SongOn;
        }
        else if (PlaySongId == 1)
        {
            PlaySongId = 0;
            BT_Song.GetComponent<Image>().sprite = SongOff;
        }
    }
}
