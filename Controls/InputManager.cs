using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace GameSandbox.Controls
{
    public class InputManager
    {
        private KeyboardState lastKeyboardState;
        private MouseState lastMouseState;

        private GamePadState[] lastControllerState;
        private Vector2 lastMouse = Vector2.Zero;
        private int lastMouseScroll;

        public void Initialize()
        {
            lastControllerState = new GamePadState[4];
        }

        public void RefreshState()
        {
            lastKeyboardState = Keyboard.GetState();
            lastMouseState = Mouse.GetState();
            lastMouse = new Vector2(Mouse.GetState().X, Mouse.GetState().Y);
            lastMouseScroll = Mouse.GetState().ScrollWheelValue;
        }

        public GamePadState GetGamePadState(PlayerIndex playerIndex)
        {
            if (playerIndex == PlayerIndex.One)
                return lastControllerState[0];
            else if (playerIndex == PlayerIndex.Two)
                return lastControllerState[1];
            else if (playerIndex == PlayerIndex.Three)
                return lastControllerState[2];
            else
                return lastControllerState[3];
        }

        public bool IsLeftMouseUp()
        {
            return Mouse.GetState().LeftButton == ButtonState.Released;
        }

        public bool IsRightMouseUp()
        {
            return Mouse.GetState().RightButton == ButtonState.Released;
        }

        public bool IsLeftMouseDown()
        {
            return Mouse.GetState().LeftButton == ButtonState.Pressed;
        }

        public bool IsRightMouseDown()
        {
            return Mouse.GetState().RightButton == ButtonState.Pressed;
        }

        public bool IsLeftMousePressed()
        {
            return IsLeftMouseDown() && (lastMouseState.LeftButton == ButtonState.Released);
        }

        public bool IsRightMousePressed()
        {
            return IsRightMouseDown() && (lastMouseState.RightButton == ButtonState.Released);
        }

        public bool IsLeftMouseReleased()
        {
            return !IsLeftMouseDown() && (lastMouseState.LeftButton == ButtonState.Pressed);
        }

        public bool IsRightMouseReleased()
        {
            return !IsRightMouseDown() && (lastMouseState.RightButton == ButtonState.Pressed);
        }

        public bool ScrolledUp()
        {
            return lastMouseScroll - Mouse.GetState().ScrollWheelValue > 0;
        }

        public bool ScrolledDown()
        {
            return lastMouseScroll - Mouse.GetState().ScrollWheelValue < 0;
        }

        public Vector2 GetMousePosition()
        {
            return new Vector2(Mouse.GetState().X, Mouse.GetState().Y);
        }

        public  Vector2 GetRelativeMouse()
        {
            return GetMousePosition() - lastMouse;
        }

        public bool IsKeyPressed(Keys key)
        {
            return Keyboard.GetState().IsKeyDown(key) && !lastKeyboardState.IsKeyDown(key);
        }

        public bool IsKeyDown(Keys key)
        {
            return Keyboard.GetState().IsKeyDown(key) && lastKeyboardState.IsKeyDown(key);
        }

        public bool IsKeyReleased(Keys key)
        {
            return !Keyboard.GetState().IsKeyDown(key) && lastKeyboardState.IsKeyDown(key);
        }

        public bool IsButtonPressed(Buttons button, PlayerIndex playerIndex)
        {
            return GamePad.GetState(playerIndex).IsButtonDown(button) && !GetGamePadState(playerIndex).IsButtonDown(button);
        }

        public bool IsButtonDown(Buttons button, PlayerIndex playerIndex)
        {
            return GamePad.GetState(playerIndex).IsButtonDown(button) && GetGamePadState(playerIndex).IsButtonDown(button);
        }

        public bool IsButtonReleased(Buttons button, PlayerIndex playerIndex)
        {
            return !GamePad.GetState(playerIndex).IsButtonDown(button) && GetGamePadState(playerIndex).IsButtonDown(button);
        }

        public bool IsLeftAnalogueLeft(PlayerIndex playerIndex)
        {
            return GamePad.GetState(playerIndex).ThumbSticks.Left.X <= -0.5f &&
                   GetGamePadState(playerIndex).ThumbSticks.Left.X > -0.5f;
        }

        public bool IsLeftAnalogueRight(PlayerIndex playerIndex)
        {
            return GamePad.GetState(playerIndex).ThumbSticks.Left.X >= 0.5f &&
                   GetGamePadState(playerIndex).ThumbSticks.Left.X < 0.5f;
        }

        public bool IsLeftTriggerPressed(PlayerIndex playerIndex)
        {
            return GamePad.GetState(playerIndex).Triggers.Left <= 0.5f &&
                   GetGamePadState(playerIndex).Triggers.Left > 0.5f;
        }

        public bool IsRightTriggerPressed(PlayerIndex playerIndex)
        {
            return GamePad.GetState(playerIndex).Triggers.Right <= 0.5f &&
                   GetGamePadState(playerIndex).Triggers.Right > 0.5f;
        }
    }
}
