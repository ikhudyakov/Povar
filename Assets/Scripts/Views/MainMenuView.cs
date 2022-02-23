using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Utils;

namespace Views
{
    class MainMenuView : BaseView
    {
        [SerializeField] Button _startButton;
        [SerializeField] Button _rewardButton;
        [SerializeField] Button _shopButton;
        [SerializeField] Button _settingsButton;

        public void Init(UnityAction StartGame, UnityAction Reward, UnityAction Shop, UnityAction Settings)
        {
            base.Init();
            _startButton.AddListener(StartGame);
            _rewardButton.AddListener(Reward);
            _shopButton.AddListener(Shop);
            _settingsButton.AddListener(Settings);

        }

        private void OnDestroy()
        {
            _startButton.RemoveAllListeners();
            _rewardButton.RemoveAllListeners();
            _shopButton.RemoveAllListeners();
            _settingsButton.RemoveAllListeners();
        }
    }
}
