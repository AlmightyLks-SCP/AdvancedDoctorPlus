using Synapse.Api;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace AdvancedDoctorPlus.Helper
{
    public static class Helper
    {
        public static readonly Vector3 PocketDimensionPosition = new Vector3(0, -1998.67f, 2);
        public static void SendToPocketDimension(this Player player)
            => player.Position = PocketDimensionPosition;
        public static Door GetClosestDoor(this IEnumerable<Door> doors, Door relativeDoor, bool onlyHeavyDoors = false, IEnumerable<Door> ignoreDoors = null)
        {
            ignoreDoors = ignoreDoors ?? Enumerable.Empty<Door>();

            Door result = null;

            float closestDistanceSqr = Mathf.Infinity;
            Vector3 currentPosition = relativeDoor.gameObject.transform.position;

            foreach (Door potentialDoor in doors)
            {
                if (onlyHeavyDoors && potentialDoor.doorType != Door.DoorTypes.HeavyGate)
                    continue;
                if (ignoreDoors.Contains(potentialDoor))
                    continue;
                if (potentialDoor == relativeDoor)
                    continue;

                Vector3 directionToTarget = potentialDoor.gameObject.transform.position - currentPosition;
                float dSqrToTarget = directionToTarget.sqrMagnitude;

                if (dSqrToTarget < closestDistanceSqr)
                {
                    closestDistanceSqr = dSqrToTarget;
                    result = potentialDoor;
                }
            }

            return result;
        }
        public static Door GetClosestDoor(this IEnumerable<Door> doors, Room relativeRoom, bool onlyHeavyDoors = false, IEnumerable<Door> ignoreDoors = null)
        {
            ignoreDoors = ignoreDoors ?? Enumerable.Empty<Door>();

            Door result = null;

            float closestDistanceSqr = Mathf.Infinity;
            Vector3 currentPosition = relativeRoom.GameObject.transform.position;

            foreach (Door potentialDoor in doors)
            {
                if (onlyHeavyDoors && potentialDoor.doorType != Door.DoorTypes.HeavyGate)
                    continue;
                if (ignoreDoors.Contains(potentialDoor))
                    continue;

                Vector3 directionToTarget = potentialDoor.gameObject.transform.position - currentPosition;
                float dSqrToTarget = directionToTarget.sqrMagnitude;

                if (dSqrToTarget < closestDistanceSqr)
                {
                    closestDistanceSqr = dSqrToTarget;
                    result = potentialDoor;
                }
            }

            return result;
        }
        public static List<Player> GetClosestPlayersInRange(this IEnumerable<Player> players, Player relativePlayer, float range, int amountPlayers = 1, List<int> roleIDs = null, IEnumerable<Player> ignorePlayers = null)
        {
            ignorePlayers = ignorePlayers ?? Enumerable.Empty<Player>();
            roleIDs = roleIDs ?? new List<int>() { 10 };

            List<Player> result = new List<Player>();

            for (int i = 0; i < amountPlayers; i++)
            {
                try
                {
                    float closestDistanceSqr = Mathf.Infinity;
                    Vector3 currentPosition = relativePlayer.gameObject.transform.position;

                    foreach (Player potentialPlayer in players)
                    {
                        if (ignorePlayers.Contains(potentialPlayer))
                            continue;
                        if (result.Contains(potentialPlayer))
                            continue;
                        if (!roleIDs.Contains(potentialPlayer.RoleID))
                            continue;

                        Vector3 directionToTarget = potentialPlayer.gameObject.transform.position - currentPosition;
                        float dSqrToTarget = directionToTarget.sqrMagnitude;

                        if (dSqrToTarget < closestDistanceSqr && Vector3.Distance(relativePlayer.Position, potentialPlayer.Position) <= range)
                        {
                            closestDistanceSqr = dSqrToTarget;
                            result.Add(potentialPlayer);
                        }
                    }
                }
                catch
                { }
            }
            return result;
        }
    }
}
