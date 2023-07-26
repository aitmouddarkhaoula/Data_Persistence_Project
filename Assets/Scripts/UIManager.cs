using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_InputField _inputField;
    [SerializeField] private Button _submitButton;
    [SerializeField] private TextMeshProUGUI _userNameText;
    // Start is called before the first frame update
    void Start()
    {
        _submitButton.onClick.AddListener(SetUserName);
        UserName.instance._userName = PlayerPrefs.GetString("userName", "Player");
        SetUserInfo();
    }
    public void SetUserInfo()
    {
        _userNameText.text = "Best Score: "+UserName.instance._userName+": "+ScoreSystem.instance.highScore+"";
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetUserName()
    {
        UserName.instance._userName = _inputField.text;
        _userNameText.text =  "Best Score: "+UserName.instance._userName+": "+ScoreSystem.instance.highScore+"";
        PlayerPrefs.SetString("userName", UserName.instance._userName);
        Debug.Log(UserName.instance._userName);
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
}
