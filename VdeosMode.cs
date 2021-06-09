using System;
using System.Collections.Generic;
using System.Text;

namespace Blibli
{
    public class VdeosMode
    {
        public int Type { get; set; }
        public string Aid { get; set; }
        public string Bid { get; set; }
        public string Cid { get; set; }
        public object SeasonId { get; set; }
        public object EpisodeId { get; set; }
        public string Title { get; set; }
        public string Uploader { get; set; }
        public string Description { get; set; }
        public string CoverURL { get; set; }
        public object Tag { get; set; }
        public string From { get; set; }
        public string PartNo { get; set; }
        public string PartName { get; set; }
        public int Format { get; set; }
        public int TotalParts { get; set; }
        public int DownloadTimeRelative { get; set; }
        public string CreateDate { get; set; }
        public string TotalTime { get; set; }
        public int[] PartTime { get; set; }
        public int TotalSizeByte { get; set; }
        public object TotalSizeString { get; set; }
        public bool IsSinglePart { get; set; }
        public bool IsDash { get; set; }
        public bool IsMerged { get; set; }
        public Videoinfo VideoInfo { get; set; }
        public Audioinfo[] AudioInfo { get; set; }
    }

    public class Videoinfo
    {
        public int MediaType { get; set; }
        public int CodecId { get; set; }
        public string CodecName { get; set; }
        public int VideoWidth { get; set; }
        public int VideoHeight { get; set; }
        public int Bandwidth { get; set; }
        public float FrameRate { get; set; }
    }

    public class Audioinfo
    {
        public int MediaType { get; set; }
        public int CodecId { get; set; }
        public string CodecName { get; set; }
        public int VideoWidth { get; set; }
        public int VideoHeight { get; set; }
        public int Bandwidth { get; set; }
        public float FrameRate { get; set; }
    }

  
}
