using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class TweetDAL
    {
        public List<TweetModel> GetTweets()
        {
            List<TweetModel> tweets = new List<TweetModel>();
            try
            {
                using (var tweetentity = new twittercloneEntities1())
                {
                    tweets = tweetentity.Tweets
                        .Where(s=>s.isActive == true)
                                .Select(s => new TweetModel
                                {
                                    Id = s.Id,
                                    UserId = s.UserId,
                                    TweetMessage = s.TweetMessage,
                                    isActive = s.isActive,
                                    CreatedOn = s.CreatedOn,
                                    LastModifiedOn = s.LastModifiedOn
                                }).ToList();
                }
            }
            catch (Exception ex)
            {

            }
            return tweets;
        }
        public List<TweetFollowing> GetTweetFollowings()
        {
            List<TweetFollowing> tweets = new List<TweetFollowing>();
            try
            {
                using (var tweetentity = new twittercloneEntities1())
                {
                    tweets = tweetentity.vw_TweetFollower
                        //s.Where(s => s.isActive == true)
                                .Select(s => new TweetFollowing
                                {
                                    TweetUserId = s.TweetUserId,
                                    TweetUser = s.TweetUser,
                                    TweetId = s.TweetId,
                                    TweetMessage = s.TweetMessage,
                                    FollowerId = s.FollowerId,
                                    Follower = s.Follower,
                                    CreatedOn = s.CreatedOn
                                }).ToList();
                }
            }
            catch (Exception ex)
            {

            }
            return tweets;
        }
        public bool CreateTweet(TweetModel t)
        {
            bool res = false;
            try
            {
                Tweet tw = new Tweet
                {
                    UserId = t.UserId,
                    TweetMessage = t.TweetMessage,                    
                    isActive = t.isActive,
                    CreatedOn = t.CreatedOn,
                    LastModifiedOn = t.LastModifiedOn
                };
                using (var tweetentity = new twittercloneEntities1())
                {
                    tweetentity.Tweets.Add(tw);
                    res = tweetentity.SaveChanges() > 0 ? true : false;
                }
            }
            catch (Exception ex)
            {

            }
            return res;
        }
        public bool UpdateTweet(TweetModel t, int type)
        {
            bool res = false;
            try
            {
                using (var tweetentity = new twittercloneEntities1())
                {
                    var tweet = tweetentity.Tweets.Find(t.Id);
                    if(type==1)
                        tweet.TweetMessage = t.TweetMessage;
                    else if (type==2)
                        tweet.TweetMessage = tweet.TweetMessage;
                    tweet.isActive = t.isActive;
                    tweet.LastModifiedOn = DateTime.Now;
                    res = tweetentity.SaveChanges() > 0 ? true : false;
                }
            }
            catch (Exception ex)
            {

            }
            return res;
        }
        public bool CreateFollowing(FollowingModel f)
        {
            bool res = false;
            try
            {
                Following fw = new Following
                {
                    FollowerId = f.FollowerId,
                    UserId = f.UserId,
                    isActive = f.isActive
                };
                using (var followentity = new twittercloneEntities1())
                {
                    followentity.Followings.Add(fw);
                    res = followentity.SaveChanges() > 0 ? true : false;
                }
            }
            catch (Exception ex)
            {

            }
            return res;
        }
        public List<FollowerModel> GetFollower()
        {
            List<FollowerModel> res = new List<FollowerModel>();
            try
            {                
                using (var followentity = new twittercloneEntities1())
                {
                    res = followentity.vw_Followers.Select(s => new FollowerModel
                    {
                        FollowerId = s.FollowerId,
                        UserId = s.UserId,
                        UserName = s.UserName,
                        FollowingId = s.FollowingId,
                        Following = s.Following
                    }).ToList();
                }
            }
            catch (Exception ex)
            {

            }
            return res;
        }

    }
}
