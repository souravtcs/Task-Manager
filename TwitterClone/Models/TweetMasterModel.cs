using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TwitterClone.Models
{
    public class TweetMasterModel
    {
        public TweetViewModel MyTweet { get; set; }
        public List<TweetFollowingViewModel> TweetFollowed { get; set; }
        public FollowModel Follow { get; set; }
        public string LoggedInUserName { get; set; }
    }

    public class FollowModel
    {
        public string TweetCount { get; set; }
        public string FollowerCount { get; set; }
        public string FollowingCount { get; set; }
    }

    public class TweetViewModel
    {
        [Display(Name ="Id")]
        public long Id { get; set; }
        [Display(Name = "User Id")]
        public long UserId { get; set; }
        [Display(Name = "Tweet")]
        public string TweetMessage { get; set; }
        [Display(Name = "isActive")]
        public bool isActive { get; set; }
        [Display(Name = "Created On")]
        public DateTime? CreatedOn { get; set; }
        [Display(Name = "Last Modified On")]
        public DateTime? LastModifiedOn { get; set; }
    }
    public class FollowingViewModel
    {
        public long Id { get; set; }
        public long TweetId { get; set; }
        public long FollowerId { get; set; }
        public bool isActive { get; set; }
    }
    public class TweetFollowingViewModel
    {
        public long TweetId { get; set; }
        public string TweetMessage { get; set; }
        public long TweetUserId { get; set; }
        public string TweetUser { get; set; }
        public long? FollowerId { get; set; }
        public string Follower { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}