using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Modules.Common
{
    public sealed class Joystick : MonoBehaviour, IPointerUpHandler, IPointerDownHandler, IDragHandler
    {
        private const float HorizontalLowAngleThreshold = 22.5f;
        private const float HorizontalHighAngleThreshold = 157.5f;
        private const float VerticalLowAngleThreshold = 67.5f;
        private const float VerticalHighAngleThreshold = 112.5f;
        private const float NegativeSnapValue = -1;
        private const float PositiveSnapValue = 1;
        private const float InputMagnitudeThreshold = 1;
        
        [SerializeField] private float _handleRange = 1;
        [SerializeField] private float _deadZone;
        [SerializeField] private AxisOptions _axisOptions = AxisOptions.Both;
        [SerializeField] private bool _snapX;
        [SerializeField] private bool _snapY;
        [SerializeField] private RectTransform _background;
        [SerializeField] private RectTransform _handle;

        private Canvas _canvas;
        private Vector2 _input = Vector2.zero;
        private bool _isPressed;
        
        public float Horizontal => (_snapX) ? SnapFloat(_input.x, AxisOptions.Horizontal) : _input.x;

        public float Vertical => (_snapY) ? SnapFloat(_input.y, AxisOptions.Vertical) : _input.y;
        
        public Vector2 Direction => new(Horizontal, Vertical);

        public float HandleRange
        {
            get => _handleRange;
            set => _handleRange = Mathf.Abs(value);
        }

        public float DeadZone
        {
            get => _deadZone;
            set => _deadZone = Mathf.Abs(value);
        }

        public AxisOptions AxisOptions
        {
            get => _axisOptions;
            set => _axisOptions = value;
        }

        public bool SnapX
        {
            get => _snapX;
            set => _snapX = value;
        }

        public bool SnapY
        {
            get => _snapY;
            set => _snapY = value;
        }

        public bool IsEnable
        {
            get => enabled;
            set
            {
                enabled = value;

                if (value == false)
                {
                    _input = Vector2.zero;
                    _handle.anchoredPosition = Vector2.zero;
                    PointerUp?.Invoke();
                }
            }
        }

        public bool IsPressed => _isPressed;

        public event Action PointerDown;
        
        public event Action PointerUp;

        private void Awake()
        {
            _canvas = GetComponentInParent<Canvas>();
            
            if (_canvas == null)
                Debug.LogError("The Joystick is not placed inside a canvas");
            
            Vector2 center = new Vector2(0.5f, 0.5f);
            _background.pivot = center;
            _handle.anchorMin = center;
            _handle.anchorMax = center;
            _handle.pivot = center;
            _handle.anchoredPosition = Vector2.zero;
            
            HandleRange = _handleRange;
            DeadZone = _deadZone;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            _isPressed = false;
            _input = Vector2.zero;
            _handle.anchoredPosition = Vector2.zero;
            PointerUp?.Invoke();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            _isPressed = true;
            PointerDown?.Invoke();
            OnDrag(eventData);
        }

        public void OnDrag(PointerEventData eventData)
        {
            Camera camera = null;
            
            if (_canvas.renderMode == RenderMode.ScreenSpaceCamera)
                camera = _canvas.worldCamera;

            Vector2 position = RectTransformUtility.WorldToScreenPoint(camera, _background.position);
            Vector2 radius = _background.sizeDelta / 2;
            _input = (eventData.position - position) / (radius * _canvas.scaleFactor);
            
            FormatInput();
            
            HandleInput(_input.magnitude, _input.normalized);
            _handle.anchoredPosition = _input * radius * _handleRange;
        }

        private void FormatInput()
        {
            if (_axisOptions == AxisOptions.Horizontal)
                _input = new Vector2(_input.x, 0f);
            else if (_axisOptions == AxisOptions.Vertical)
                _input = new Vector2(0f, _input.y);
        }

        private void HandleInput(float magnitude, Vector2 normalised)
        {
            if (magnitude > _deadZone)
            {
                if (magnitude > InputMagnitudeThreshold)
                    _input = normalised;
            }
            else
                _input = Vector2.zero;
        }

        private float SnapFloat(float value, AxisOptions snapAxis)
        {
            if (Mathf.Approximately(value, 0))
                return value;

            if (_axisOptions == AxisOptions.Both)
            {
                float angle = Vector2.Angle(_input, Vector2.up);
                
                if (snapAxis == AxisOptions.Horizontal)
                {
                    if (angle < HorizontalLowAngleThreshold || angle > HorizontalHighAngleThreshold)
                        return 0;
                    
                    return (value > 0) ? PositiveSnapValue : NegativeSnapValue;
                }

                if (snapAxis == AxisOptions.Vertical)
                {
                    if (angle > VerticalLowAngleThreshold && angle < VerticalHighAngleThreshold)
                        return 0;

                    return (value > 0) ? PositiveSnapValue : NegativeSnapValue;
                }

                return value;
            }

            if (value > 0)
                return PositiveSnapValue;
            
            if (value < 0)
                return NegativeSnapValue;

            return 0;
        }
    }
}