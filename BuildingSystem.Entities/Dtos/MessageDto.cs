using Entites.Entitiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingSystem.Entities.Dtos
{
    public class MessageDto
    {
        public int Id { get; set; }
        public string SenderMail { get; set; }
        public string ReceiverMail { get; set; }
        public string MessageContent { get; set; }
        public string Body { get; set; }
        public string UserName { get; set; }
        public List<UserDto> Users { get; set; }
        //public bool IsRead { get; set; } = false;
    }
}
