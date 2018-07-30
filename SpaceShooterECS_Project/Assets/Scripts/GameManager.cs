using UnityEngine;

//using ShipManager = ShipManager_Classic;
//using ShipManager = ShipManager_Jobs;
//using ShipManager = ShipManager_HybridECS;
//using ShipManager = ShipManager_ECS;
using ShipManager = ShipManager_ECSJobs;

namespace Shooter
{
    [RequireComponent(typeof(ShipManager))]
    public class GameManager : MonoBehaviour
    {
        [Header("Spawn Settings")]
        public int enemyShipCount = 1000;
        public int enemyShipIncremement = 1000;

        ShipManager shipManager;

        FPS fps;
        int count;

        void Start()
        {
            fps = GetComponent<FPS>();
            shipManager = GetComponent<ShipManager>();
            AddShips(enemyShipCount);
        }


        void Update()
        {
            if (Input.GetKeyDown("space"))
                AddShips(enemyShipIncremement);
        }

        void AddShips(int amount)
        {
            shipManager.AddShips(enemyShipCount);

            count += amount;
            fps.SetElementCount(count);
        }
    }
}
