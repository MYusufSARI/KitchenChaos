using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class OptionsUI : MonoBehaviour
{
    public static OptionsUI Instance { get; private set; }


    [SerializeField]
    private Button musicButton;

    [SerializeField]
    private Button soundEffectsButton;

    [SerializeField]
    private Button closeButton;

    [SerializeField]
    private TextMeshProUGUI soundsEffectsText;

    [SerializeField]
    private TextMeshProUGUI musicText;



    [SerializeField]
    private Button moveUpButton;

    [SerializeField]
    private Button moveDownButton;

    [SerializeField]
    private Button moveLeftButton;

    [SerializeField]
    private Button moveRightButton;

    [SerializeField]
    private Button interactButton;

    [SerializeField]
    private Button interactAlternateButton;

    [SerializeField]
    private Button pauseButton;


   


    [SerializeField]
    private TextMeshProUGUI moveUpText;

    [SerializeField]
    private TextMeshProUGUI movedownText;

    [SerializeField]
    private TextMeshProUGUI moveLeftText;

    [SerializeField]
    private TextMeshProUGUI moveRightText;

    [SerializeField]
    private TextMeshProUGUI interactText;

    [SerializeField]
    private TextMeshProUGUI interactAlternateText;

    [SerializeField]
    private TextMeshProUGUI pauseText;





    private void Awake()
    {
        Instance = this;

        soundEffectsButton.onClick.AddListener(() =>
        {
            SoundManager.Instance.ChangeVolume();
            UpdateVisual();
        });

        musicButton.onClick.AddListener(() =>
        {
            MusicManager.Instance.ChangeVolume();
            UpdateVisual();
        });

        closeButton.onClick.AddListener(() =>
        {
            Hide();
        });

        moveUpButton.onClick.AddListener(() =>
        {
            GameInput.Instance.ReBindBinding(GameInput.Binding.Move_Up);
        });
    }


    private void Start()
    {
        KitchenGameManager.Instance.OnGameUnpaused += KitchenGameManager_OnGameUnpaused;

        UpdateVisual();

        Hide();
    }

    private void KitchenGameManager_OnGameUnpaused(object sender, System.EventArgs e)
    {
        Hide();
    }

    private void UpdateVisual()
    {
        soundsEffectsText.text = "Sound Effects:" + Mathf.Round(SoundManager.Instance.GetVolume() * 10f);
        musicText.text = "Music:" + Mathf.Round(MusicManager.Instance.GetVolume() * 10f);

        moveUpText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Move_Up);
        movedownText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Move_Down);
        moveLeftText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Move_Left);
        moveRightText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Move_Right);
        interactText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Interact);
        interactAlternateText.text = GameInput.Instance.GetBindingText(GameInput.Binding.InteractAlternate);
        pauseText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Pause);
    }


    public void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
