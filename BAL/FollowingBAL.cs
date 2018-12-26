using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public class FollowingBAL
    {
        TweetDAL td;
        public List<TweetModel> GetTweets()
        {
            td = new TweetDAL();
            List<TweetModel> tweets = new List<TweetModel>();
            try
            {
                tweets = td.GetTweets();
            }
            catch (Exception ex)
            {

            }
            return tweets;
        }
        public List<TweetFollowing> GetTweetFollowings()
        {
            td = new TweetDAL();
            List<TweetFollowing> tweets = new List<TweetFollowing>();
            try
            {
                tweets = td.GetTweetFollowings();
            }
            catch (Exception ex)
            {

            }
            return tweets;
        }
        public bool CreateTweet(TweetModel t)
        {
            td = new TweetDAL();
            bool res = false;
            try
            {
                res = td.CreateTweet(t);
            }
            catch (Exception ex)
            {

            }
            return res;
        }
        public bool UpdateTweet(TweetModel t, int type)
        {
            td = new TweetDAL();
            bool res = false;
            try
            {
                res = td.UpdateTweet(t, type);
            }
            catch (Exception ex)
            {

            }
            return res;
        }
        public bool CreateFollowing(FollowingModel f)
        {
            td = new TweetDAL();
            bool res = false;
            try
            {
                res = td.CreateFollowing(f);
            }
            catch (Exception ex)
            {

            }
            return res;
        }
        public List<FollowerModel> GetFollower()
        {
            td = new TweetDAL();
            List<FollowerModel> followers = new List<FollowerModel>();
            try
            {
                followers = td.GetFollower();
            }
            catch (Exception ex)
            {

            }
            return followers;
        }
    }
}
