using System;
using System.Collections.Generic;

namespace IgniteService.Models
{
    [Serializable]
    public class Entity
    {
        public string Name { get; set; }
        public int Number { get; set; }
        public List<SubEntity> SubEntities { get; set; }
    }
}
