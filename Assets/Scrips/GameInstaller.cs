using Assets.Scrips.Game;
using Assets.Scrips.Settings;
using Assets.Scripts.Game;
using UnityEngine;
using Zenject;

namespace Assets.Scrips
{
    public class GameInstaller : MonoInstaller
	{
		[SerializeField]
		private GameSettings _settings;

        [SerializeField]
		private SceneRoot _sceneRoot;

		[SerializeField]
		private InputManager _inputManager;

		public override void InstallBindings()
		{
			Container.Bind<GameScene>().AsSingle();
            Container.Bind<IInputManager>().To<InputManager>().FromInstance(_inputManager);
            Container.Bind<IGameSettings>().To<GameSettings>().FromInstance(_settings);
            Container.Bind<SceneRoot>().FromInstance(_sceneRoot);

            Container.Resolve<GameScene>();
		}
		
	}
}
