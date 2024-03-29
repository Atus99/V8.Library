﻿using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace V8Hangfire.Domain.Models.V8Hangfire
{
    [Description("Bảng cài đặt job")]
    public class JobSchedule
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Description("Khóa chính")]
        public int ID { get; set; }
        public int JobTypeID { get; set; } = 3; //EnumJobType.Type

        [Required]
        public string JobName { get; set; }
        public string CronString { get; set; } //https://www.freeformatter.com/cron-expression-generator-quartz.html
        public string Service { get; set; } = "DASDomain";
        public string ApiUrl { get; set; }
        public int Interval { get; set; } = 0; //s: giây
        public DateTime? StartDate { get; set; } = DateTime.Now;
        public DateTime? EndDate { get; set; } = DateTime.Now;
        public int Status { get; set; } = 1;
    }
}
