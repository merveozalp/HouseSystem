using Entites.Entitiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingSystem.Entities.Entity
{
    public class Messange:Base
    {
        public string SenderMail { get; set; }
        public string ReceiverMail { get; set; }
        public string MessageContent { get; set; }
        public bool IsRead { get; set; } = false;
    }
}
