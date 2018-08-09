using System.Web;

namespace Tasklist.Web.Helpers
{
    public static class TasklistSessionFacade
    {
        private const string joinGroupOrGoal = "JoinGroupOrGoal";


        public static string JoinGroupOrGoal
        {
            get
            {
                return (string)HttpContext.Current.Session[joinGroupOrGoal];
            }

            set
            {
                HttpContext.Current.Session[joinGroupOrGoal] = value;
            }
        }

        public static void Remove(string sessionVariable)
        {
            HttpContext.Current.Session.Remove(sessionVariable);
        }

        public static void Clear()
        {
            HttpContext.Current.Session.Clear();
        }
    }
}