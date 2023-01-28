using System;
using Infrastructure.Services.Interfaces;
using UnityEngine;

namespace Infrastructure.Services
{
    public class ProgressService : IProgressService
    {
        public event Action OnDied;
        public int HealthCount { get; private set; }
        public string LvlName { get; private set; }

        public ProgressService()
        {
            HealthCount = 3;
        }
        
        public void DecrementHealth()
        {
            HealthCount -= 1;
            if(HealthCount <= 0)
            {
                Application.Quit();
            }

            if (OnDied != null)
            {
                OnDied();
            }
        }

        public void IncrementHealth()
        {
            HealthCount++;
        }

        public void SetLvl(string lvlName)
        {
            LvlName = lvlName;
        }
    }
}