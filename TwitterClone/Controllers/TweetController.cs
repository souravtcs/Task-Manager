using BAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TwitterClone.Models;

namespace TwitterClone.Controllers
{
    public class TweetController : Controller
    {
        FollowingBAL t;
        UserBAL u;
        // GET: Tweet
        public ActionResult Index()
        {
            t = new FollowingBAL();
            TweetMasterModel tm = new TweetMasterModel();
            tm.LoggedInUserName = ((UserModel)Session["User"]).UserName;
            tm.TweetFollowed = t.GetTweetFollowings().Where(s=>s.FollowerId == ((UserModel)Session["User"]).UserId)
                .Select(s=>new TweetFollowingViewModel
                {
                    TweetId = s.TweetId,
                    TweetMessage = s.TweetMessage,
                    FollowerId = s.FollowerId,
                    Follower = s.Follower,
                    TweetUserId = s.TweetUserId,
                    TweetUser = s.TweetUser,
                    CreatedOn = s.CreatedOn
                }).ToList();
            tm.MyTweet = new TweetViewModel();
            tm.Follow = new FollowModel();

            tm.Follow.FollowerCount = t.GetFollower().Where(s => s.UserId == ((UserModel)Session["User"]).UserId).Count().ToString();
            tm.Follow.TweetCount = t.GetTweets().Where(s=>s.UserId== ((UserModel)Session["User"]).UserId).Count().ToString();
            tm.Follow.FollowingCount = t.GetFollower().Where(s => s.FollowingId == ((UserModel)Session["User"]).UserId).Count().ToString();
            return View(tm);
        }
        [HttpPost]
        public ActionResult CreateTweet(TweetViewModel tw)
        {
            t = new FollowingBAL();
            TweetModel tweet = new TweetModel
            {
                isActive = true,
                CreatedOn = DateTime.Now,
                LastModifiedOn = DateTime.Now,
                UserId =((UserModel)Session["User"]).UserId,
                TweetMessage = tw.TweetMessage
            };            
            t.CreateTweet(tweet);
            return Json("Success", JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetTweets()
        {
            t = new FollowingBAL();
            var tweets = t.GetTweets().Where(s => s.UserId == ((UserModel)Session["User"]).UserId)
                .Select(s=> new TweetViewModel {
                    Id = s.Id,
                    UserId = s.UserId,
                    TweetMessage = s.TweetMessage,
                    isActive = s.isActive,
                    CreatedOn = s.CreatedOn,
                    LastModifiedOn = s.LastModifiedOn
                }).ToList();
            return PartialView(tweets);
        }
        public ActionResult EditTweet(int id)
        {
            t = new FollowingBAL();
            var tweets = t.GetTweets().Where(s => s.UserId == ((UserModel)Session["User"]).UserId && s.Id == id)
                .Select(s => new TweetViewModel
                {
                    Id = s.Id,
                    UserId = s.UserId,
                    TweetMessage = s.TweetMessage,
                    isActive = s.isActive,
                    CreatedOn = s.CreatedOn,
                    LastModifiedOn = s.LastModifiedOn
                }).FirstOrDefault();
            return View(tweets);
        }
        [HttpPost]
        public ActionResult EditTweet(TweetViewModel tw)
        {
            t = new FollowingBAL();
            var tweet = new TweetModel { Id = tw.Id, TweetMessage = tw.TweetMessage, isActive = true};
            bool res = t.UpdateTweet(tweet,1);
            return RedirectToAction("Index");
        }        
        public ActionResult DeleteTweet(int id)
        {
            t = new FollowingBAL();
            var tweet = new TweetModel { Id = id, isActive = false};
            bool res = t.UpdateTweet(tweet,2);
            return RedirectToAction("Index");
        }
        public ActionResult GetFollowing()
        {
            t = new FollowingBAL();
            var data = t.GetFollower().Where(s => s.UserId == ((UserModel)Session["User"]).UserId).ToList();
            return PartialView(data);
        }
        public ActionResult GetFollowers()
        {
            t = new FollowingBAL();
            var data = t.GetFollower().Where(s => s.FollowingId == ((UserModel)Session["User"]).UserId).ToList();
            return PartialView(data);
        }
        public ActionResult SearchFollowing(string searchText)
        {
            u = new UserBAL();
            var data = u.GetAllUser().Where(s => s.UserId != ((UserModel)Session["User"]).UserId);
            data = string.IsNullOrEmpty(searchText) ? data : data.Where(s => s.UserName.Trim().ToUpper() == searchText.Trim().ToUpper());
            return PartialView(data);
        }
        public ActionResult FollowUser(int id)
        {
            t = new FollowingBAL();
            FollowingModel f = new FollowingModel { UserId = ((UserModel)Session["User"]).UserId , FollowerId = id, isActive = true};
            bool res = t.CreateFollowing(f);
            return RedirectToAction("Index");
        }
    }
}