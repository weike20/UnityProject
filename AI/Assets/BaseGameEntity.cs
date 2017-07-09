using UnityEngine;
using System.Collections;
using System.Collections.Generic;


namespace ITGGame.AI
{
    public abstract class BaseGameEntity : MonoBehaviour
    {

        private static Dictionary<string, BaseGameEntity> entitys = new Dictionary<string, BaseGameEntity>();
        public static BaseGameEntity GetEntity(string uid)
        {
            return entitys[uid];
        }
        public static List<BaseGameEntity> GetEntitys(EntityType type)
        {
            List<BaseGameEntity> result = new List<BaseGameEntity>();

            using (var itr = entitys.GetEnumerator())
            {
                while (itr.MoveNext())
                {
                    if (itr.Current.Value.EType == type)
                        result.Add(itr.Current.Value);

                }
            }
            return result;
        }


        private string uid;
        private EntityType entityType = EntityType.Default;

        public string UID { get { return uid; } }
        public EntityType EType
        {
            get { return entityType; }
            set { entityType = value; }
        }

        public virtual void Awake()
        {
            uid = System.Guid.NewGuid().ToString();
            entitys.Add(uid, this);
        }
    }

}
