using flanne;
using flanne.UI;
using UnityEngine.UI;
using HarmonyLib;
using UnityEngine;
using static CompactPowerups.Plugin;
using System.Collections.Generic;

namespace CompactPowerups
{
    internal class PowerupListUIPatch
    {
        [HarmonyPatch(typeof(PowerupListUI), "OnPowerupApplied")]
        [HarmonyPostfix]
        static void OnPowerupAppliedPostfix(PowerupListUI __instance, object sender, object args)
        {
            Dictionary<string, Transform> powerupDict = new Dictionary<string, Transform>();
            foreach (Transform transform in __instance.transform)
            {
                PowerupIcon powerupIcon = transform.GetComponent<PowerupIcon>();
                if(powerupIcon is not null && powerupDict.ContainsKey(powerupIcon.data.name)) {
                    Object.Destroy(transform.gameObject);
                    PowerupCounter powerupCounter = powerupDict[powerupIcon.data.name].gameObject.GetComponent<PowerupCounter>();
                    powerupCounter.updateCount(powerupCounter.getCount() + 1);
                } else {
                    powerupDict.Add(powerupIcon.data.name, transform);
                    if(transform.gameObject.GetComponent<PowerupCounter>() is null) {
                        transform.gameObject.AddComponent<PowerupCounter>();
                    }
                }
            }
        }
    }
}