﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using Sociala_Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sociala_Entities.Concrete.DatabaseFirst
{
    public partial class Notification : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int NotificationSenderIdForNotification { get; set; }
        public int NotificationReceiverIdForNotification { get; set; }

        public virtual NotificationReceiver NotificationReceiverIdForNotificationNavigation { get; set; }
        public virtual NotificationSender NotificationSenderIdForNotificationNavigation { get; set; }
    }
}