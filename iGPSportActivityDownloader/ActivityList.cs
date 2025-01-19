using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iGPSportActivityDownloader;

public class ActivityList
{
    public int total { get; set; }
    public Activity[] item { get; set; }
}

public class Activity
{
    public int RideId { get; set; }
    public int MemberId { get; set; }
    public string MemberName { get; set; }
    public string MemberImg { get; set; }
    public string Title { get; set; }
    public string StartTime { get; set; }
    public string ThumbPath { get; set; }
    public string RideDistance { get; set; }
    public string TotalAscent { get; set; }
    public string RecordTime { get; set; }
    public int Praise { get; set; }
    public int IsMy { get; set; }
    public string RideTag { get; set; }
    public int Metric { get; set; }
}
