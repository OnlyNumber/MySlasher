using UnityEngine;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

namespace StarterAssets
{
	public class StarterAssetsInputs : MonoBehaviour
	{
		[Header("Character Input Values")]
		public Vector2 move;
		public Vector2 look;
		public bool jump;
		public bool sprint;
		public bool attack;
		public bool attackSecondSkill;
		public bool attackThirdSkill;
		public bool attackFourthSkill;


		[Header("Movement Settings")]
		public bool analogMovement;

		[Header("Mouse Cursor Settings")]
		public bool cursorLocked = true;
		public bool cursorInputForLook = true;

#if ENABLE_INPUT_SYSTEM
		public void OnMove(InputValue value)
		{
			MoveInput(value.Get<Vector2>());
		}

		public void OnLook(InputValue value)
		{
			if(cursorInputForLook)
			{
				LookInput(value.Get<Vector2>());
			}
		}

		public void OnJump(InputValue value)
		{
			JumpInput(value.isPressed);
		}

		public void OnSprint(InputValue value)
		{
			SprintInput(value.isPressed);
		}

		public void OnAttackLM(InputValue value)
		{
			AttackLMInput(value.isPressed);

		}

		public void OnAttackSecondSkill(InputValue value)
		{
			AttackSecondSkillInput(value.isPressed);
		}

		public void OnAttackThirdSkill(InputValue value)
		{
			AttackThirdSkillInput(value.isPressed);
		}

		public void OnAttackFourthSkill(InputValue value)
		{
			AttackFourthSkillInput(value.isPressed);
		}

#endif


		public void MoveInput(Vector2 newMoveDirection)
		{
			move = newMoveDirection;
		} 

		public void LookInput(Vector2 newLookDirection)
		{
			look = newLookDirection;
		}

		public void JumpInput(bool newJumpState)
		{
			jump = newJumpState;
		}

		public void SprintInput(bool newSprintState)
		{
			sprint = newSprintState;
		}

		public void AttackLMInput(bool newattackState)
		{
			attack = newattackState;
		}

		public void AttackSecondSkillInput(bool newattackState)
		{
			attackSecondSkill = newattackState;
		}

		public void AttackThirdSkillInput(bool newattackState)
		{
			attackThirdSkill = newattackState;
		}

		public void AttackFourthSkillInput(bool newattackState)
		{
			attackFourthSkill = newattackState;
		}

		private void OnApplicationFocus(bool hasFocus)
		{
			SetCursorState(cursorLocked);
		}

		private void SetCursorState(bool newState)
		{
			Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
		}
	}
	
}