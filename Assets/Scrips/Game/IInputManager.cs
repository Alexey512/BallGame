using System;
using UnityEngine;

namespace Assets.Scripts.Game
{
	public interface IInputManager
	{
		event Action<Ray> OnClick;
	}
}
