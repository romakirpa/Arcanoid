using System;

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
            if (OnDied != null)
            {
                OnDied();
            }
        }

        public void IncrementHealth()
        {
            throw new NotImplementedException();
        }

        public void SetLvl(string lvlName)
        {
            LvlName = lvlName;
        }
    }
}