using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class TweetModel
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string TweetMessage { get; set; }
        public bool isActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime LastModifiedOn { get; set; }
    }
    public class FollowingModel
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public long FollowerId { get; set; }
        public bool isActive { get; set; }
    }
    public class FollowerModel
    {
        public long FollowerId { get; set; }
        public long UserId { get; set; }
        public string UserName { get; set; }
        public long FollowingId { get; set; }
        public string Following { get; set; }
    }
    public class TweetFollowing
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
