using MainGame.Script.Common;
using MainGame.Script.Models.Base;
using SimpleJSON;
using Unity.VisualScripting;
using UnityEngine;

namespace MainGame
{
   
    
    public class AirshipVO : BaseVO
    {
        public PlaneInfo GetPlaneInfo(int level)
        {
            JSONArray array = data.AsArray;
            if (level >= array.Count) return JsonUtility.FromJson<PlaneInfo>(array[array.Count - 1].ToString()) ;
            return JsonUtility.FromJson<PlaneInfo>(array[level - 1].ToString());
        }
    }
}