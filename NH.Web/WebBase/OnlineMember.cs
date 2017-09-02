using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Threading;

namespace NH.Web
{


    public class OnlineMember
    {
        private static List<Model.OnlineMemberModel> _userList;
        public List<Model.OnlineMemberModel> UserList
        {
            get { return _userList; }
            set { _userList = value; }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public OnlineMember()
        {
            if (_userList == null) _userList = new List<Model.OnlineMemberModel>();
        }

        /// <summary>
        /// 添加到在线列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool AddUserToOnline(Model.OnlineMemberModel model)
        {
            Model.OnlineMemberModel temp = _userList.Find(el => el.loginName == model.loginName);
            if (temp != null)
            {
                temp.sessionId = model.sessionId;
                temp.refreshTime = model.refreshTime;
            }
            else
            {
                _userList.Add(model);
            }
            return true;
        }

        /// <summary>
        /// 当前用户是否在线
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool IsUserOnline(Model.OnlineMemberModel model)
        {
            Model.OnlineMemberModel temp = _userList.Find(el => el.loginName == model.loginName);
            if (temp != null)
            {
                if (temp.sessionId == model.sessionId)
                    return true;
                else
                    return false;
            }
            else
            {
                return false;
            }
        }
    }






    //定义了一个结构
    public struct User
    {
        public string name;
        public DateTime lasttime;
        public DateTime curtime;
        public string sessionid;
        public string iswhere;
    }

    //定义在线用户类
    public class OnLineUser
    {
        private static ArrayList _alluser;        //定义用户

        public ArrayList alluser
        {
            get { return _alluser; }
            set { _alluser = value; }
        }

        public OnLineUser()        //构造函数
        {
            if (_alluser == null)
            {
                _alluser = new ArrayList();
            }
        }

        //功能说明：将当前用户加入在线列表
        //如果该用户的数据当前仍然在在线列表中，则暂时先不让该用户登陆,提示用户存在
        public bool AddUserToOnLine(User user)
        {
            //需要先判断用户是否已经在用户列表中了
            if (_alluser == null)
            {
                _alluser.Add(user);
                return (true);
            }
            else
            {
                for (int i = 0; i < _alluser.Count; i++)
                {
                    //循环判断用户是否已经存在
                    User tempuser = (User)_alluser[i];

                    if (tempuser.sessionid.Equals(user.sessionid) && tempuser.name.Equals(user.name))
                    {
                        return (false);    //用户已经存在，则直接退出
                    }
                }
                _alluser.Add(user);
                return (true);
            }
        }

        //功能说明:判断某用户是否在线,本部分暂时不用
        //返回值：TRUE代表在线，FALSE不在
        public Boolean IsUserOnLine(string name)
        {
            //需要先判断用户是否已经在用户列表中了
            if (_alluser == null)
            {
                return (false);
            }
            else
            {
                for (int i = 0; i < _alluser.Count; i++)
                {
                    //循环判断用户是否已经存在
                    User tempuser = (User)_alluser[i];
                    if (tempuser.name.Equals(name))
                    {
                        return (true);
                    }
                }
                return (false);
            }
        }

        //功能说明：更新用户在线时间
        //返回值：最新的在线用户列表
        public Boolean CheckUserOnLine(string name)
        {
            //需要先判断用户是否已经在用户列表中了
            if (_alluser != null)
            {
                for (int i = 0; i < _alluser.Count; i++)
                {
                    User tempuser = (User)_alluser[i];
                    //先判断当前用户是否是自己
                    if (tempuser.name.Equals(name))
                    {
                        //更新用户在线时间
                        tempuser.curtime = DateTime.Now;
                        alluser[i] = tempuser;
                        return (true);
                    }
                }
            }
            return (false);
        }
    }



    /*
    下面开始建立守护线程类：
    （注：此处，开始写的时候本来想做成单件模式的，不过由于以前没有做过这个东西，所以反而发生
    了很多问题，最后决定放弃而使用现有的格式，不过，刚才从开心那里有对单件有个认识，晚上回去
    会再去用用它写另一种模式 ）
    */
    public class CheckOnline
    {
        const int DELAY_TIMES = 5000;                //定义执行的时间间隔为5秒
        const int DELAY_SECONDS = 30;                    //将用户掉线时间设置为30秒

        private Thread thread;                        //定义内部线程
        private static bool _flag = false;                    //定义唯一标志

        public CheckOnline()
        {
            if (!_flag)
            {
                _flag = true;
                this.thread = new Thread(new ThreadStart(ThreadProc));
                thread.Name = "online user";
                thread.Start();
            }
        }


        internal void ThreadProc()
        {
            while (true)
            {
                OnLineUser temp = new OnLineUser();        //定义一个用户对象
                for (int i = 0; i < temp.alluser.Count; i++)
                {
                    User tmpuser = (User)temp.alluser[i];
                    //我是将该用户的最新时间加上80秒，然后和当前时间比较，小与当前时间，
                    //则表示该用户已经吊线，则删除他的记录
                    if (tmpuser.curtime.AddSeconds(DELAY_SECONDS).CompareTo(DateTime.Now) < 0)
                    {
                        temp.alluser.RemoveAt(i);
                    }
                }
                Thread.Sleep(DELAY_TIMES);

            }
        }
    }
}