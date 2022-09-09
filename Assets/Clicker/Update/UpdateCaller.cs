using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Clicker.Core.Update
{
    public class UpdateCaller : MonoBehaviour, IUpdater
    {
        [InfoBox("If the value is 0, then Update will call every frame. Call frequency cannot exceed fps.")]
        [SerializeField] private int _callsPerSecond;
        
        private List<IUpdatable> _objects;
        private float _timer;
        private bool _updateIsActive;
        
        private bool CallEveryFrame => _callsPerSecond == 0;
        
        public void Init()
        {
            _objects = new List<IUpdatable>();
        }

        public void AddObject(IUpdatable obj)
        {
            _objects.Add(obj);
        }

        public void RemoveObject(IUpdatable obj)
        {
            _objects.Remove(obj);
        }

        public void RemoveAllObjects()
        {
            _objects.Clear();
        }

        public void StartUpdate()
        {
            _updateIsActive = true;
        }

        public void StopUpdate()
        {
            _updateIsActive = false;
        }

        private void Update()
        {
            if (!_updateIsActive)
            {
                return;
            }

            var deltaTime = Time.deltaTime;
            if (!CallEveryFrame)
            {
                var result = Check(deltaTime);
            
                if (!result)
                {
                    return;
                }
                else
                {
                    _timer = 0f;
                }
            }

            CallUpdateInObjects(deltaTime);
        }

        private bool Check(float delta)
        {
            _timer += delta;
            var result = CallEveryFrame || (1f / _callsPerSecond) < _timer;
            return result;
        }

        private void CallUpdateInObjects(float delta)
        {
            for (int i = 0; i < _objects.Count; i++)
            {
                _objects[i].Update(delta);
            }
        }
    }
}