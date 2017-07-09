using System;
using System.Collections.Generic;

namespace IgniteService.Models
{
    [Serializable]
    public class SubEntity
    {
        public string Name { get; set; }
        public List<SubEntity> SubEntities { get; set; }

        public SubEntity(string name)
        {
            Name = name;
        }

        public void GenerateSubEntities(int number)
        {
            if (SubEntities == null)
                SubEntities = new List<SubEntity>();
            for (int i = 0; i < number; i++)
            {
                SubEntities.Add(new SubEntity("SubEntity-" + i));
            }
        }
    }
}