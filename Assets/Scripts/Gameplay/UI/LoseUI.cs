using Common.StateMachine;
using Gameplay.Scoring;
using Infrastructure.StateMachine.States;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Gameplay.UI
{
    public class LoseUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _loseText;
        [SerializeField] private Button _restartButton;
        
        private IGameStateMachine _gameStateMachine;
        private ScoreService _scoreService;

        [Inject]
        public void Construct(IGameStateMachine gameStateMachine, ScoreService scoreService)
        {
            _gameStateMachine = gameStateMachine;
            _scoreService = scoreService;
        }
        
        private void Awake()
        {
            _restartButton.onClick.AddListener(OnRestartButtonClicked);
        }

        private void Start()
        {
            _loseText.text = $"Поражение!\nОчки: {_scoreService.CurrentScore}";
        }

        private void OnRestartButtonClicked()
        {
            _gameStateMachine.Enter<GameplayState>();
        }

        private void OnDestroy()
        {
            _restartButton.onClick.RemoveListener(OnRestartButtonClicked);
        }
    }
}