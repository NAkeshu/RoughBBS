using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;

namespace connectSQL
{
    public class BBSSQL
    {
        MySqlConnection Conn;

        public BBSSQL()
        {
            string connection = "server=localhost; user id=root; password=zjs980625;";
            this.Conn = new MySqlConnection(connection);
            this.Conn.ConnectionString = "server=localhost; user id=root; password=zjs980625; database=bbs;";
        }

        public string getSQLData(string SqlCommand)
        {
            this.Conn.Open();
            MySqlCommand Comm = new MySqlCommand(SqlCommand, this.Conn);
            string a = Comm.ExecuteScalar().ToString();
            this.Conn.Close();
            return a;
        }

        public bool isRegistered(string id)
        {
            string SqlCommand = "SELECT count(*) FROM users WHERE userid = '" + id + "';";
            this.Conn.Open();
            MySqlCommand Comm = new MySqlCommand(SqlCommand, this.Conn);
            string a = Comm.ExecuteScalar().ToString();
            this.Conn.Close();
            if (a == "1")
                return true;
            else
                return false;
        }

        public int signupUsertoSQL(string ID, string name, string password, string email)
        {
            string SqlCommand = "INSERT INTO `bbs`.`users` (`userid`, `username`, `password`, `email`, `isAdmin`) VALUES('" + ID + "', '" + name + "', '" + password + "', '" + email + "', '0');";
            this.Conn.Open();
            MySqlCommand Comm = new MySqlCommand(SqlCommand, this.Conn);
            Comm.ExecuteNonQuery();
            this.Conn.Close();
            return 1;
        }

        public DataSet getSectionsList()
        {
            string SqlCommand = "SELECT * FROM section, users WHERE section.ownerid=users.userid";
            MySqlDataAdapter myda = new MySqlDataAdapter();
            this.Conn.Open();
            MySqlCommand Comm = new MySqlCommand(SqlCommand, this.Conn);
            myda.SelectCommand = Comm;
            DataSet ds = new DataSet();
            myda.Fill(ds, "sectionslist");
            this.Conn.Close();
            return ds;
        }

        public DataSet getPostsList(string Sectionname)
        {
            MySqlDataAdapter myda = new MySqlDataAdapter();
            string sqlstr = "select * from post, users where post.sectionname='" + Sectionname + "' and users.userid=post.authorid";
            this.Conn.Open();
            MySqlCommand Comm = new MySqlCommand(sqlstr, this.Conn);
            myda.SelectCommand = Comm;
            DataSet ds = new DataSet();
            myda.Fill(ds, "postslist");
            this.Conn.Close();
            return ds;
        }

        public string getSectionDetail(string SectionName)
        {
            string SectionDetail;
            string Sqlstr = "select sectiondetail from section where sectionname='" + SectionName + "';";
            this.Conn.Open();
            MySqlCommand Comm = new MySqlCommand(Sqlstr, this.Conn);
            SectionDetail = Comm.ExecuteScalar().ToString();
            this.Conn.Close();
            return SectionDetail;
        }

        public DataSet getPostDetail(String postid)
        {
            DataSet ds = new DataSet();
            MySqlDataAdapter myda = new MySqlDataAdapter();
            string sqlstr = "select username, text, posttime from users, post where postid='" + postid + "' and users.userid=post.authorid";
            this.Conn.Open();
            MySqlCommand Comm = new MySqlCommand(sqlstr, this.Conn);
            myda.SelectCommand = Comm;
            myda.Fill(ds, "postdetail");
            this.Conn.Close();
            return ds;
        }

        public int getCommentNum(string id)
        {
            int num;
            string sqlstr = "select count(*) from comment where postid='" + id + "'";
            MySqlCommand Comm = new MySqlCommand(sqlstr, this.Conn);
            this.Conn.Open();
            num = int.Parse(Comm.ExecuteScalar().ToString());
            this.Conn.Close();
            return num;
        }

        public DataSet getComemnts(string id)
        {
            DataSet ds = new DataSet();
            MySqlDataAdapter myda = new MySqlDataAdapter();
            string sqlstr = "select floor, username, text, commenttime from users, comment where users.userid=comment.authorid and postid='" + id + "' order by floor";
            this.Conn.Open();
            MySqlCommand Comm = new MySqlCommand(sqlstr, this.Conn);
            myda.SelectCommand = Comm;
            myda.Fill(ds, "comments");
            this.Conn.Close();
            return ds;
        }

        public int updateSQLData(string sqlstr)
        {
            MySqlCommand Comm = new MySqlCommand(sqlstr, this.Conn);
            try
            {
                this.Conn.Open();
                Comm.ExecuteNonQuery();
            }
            catch
            {
                return 0;
            }
            finally
            {
                this.Conn.Close();
            }
            return 1;
        }

        public int insertComment(int floor, string postid, string userid, string text, string commenttime, int tofloor)
        {
            string sqlstr = "INSERT INTO `bbs`.`comment` (`floor`, `postid`, `authorid`, `text`, `commenttime`, `tofloor`) VALUES ('" + floor + "', '" + postid + "', '" + userid + "', '" + text + "', '" + commenttime + "', '" + tofloor + "');";
            int i = updateSQLData(sqlstr);
            return i;
        }

        public int updatePostforComment(string commenttime, int floor, string postid)
        {
            string sqlstr = "UPDATE `bbs`.`post` SET `lastcommenttime` = '"+commenttime+"', `commentnum` = '"+floor+"' WHERE (`postid` = '"+postid+"');";
            int i = updateSQLData(sqlstr);
            return i;
        }

        public int insertPost(string section, string authorid, string topic, string text, string posttime)
        {
            string sqlstr = "INSERT INTO `bbs`.`post` (`sectionname`, `authorid`, `topic`, `text`, `posttime`) VALUES ('" + section + "', '" + authorid + "', '" + topic + "', '" + text + "', '" + posttime + "');";
            int i = updateSQLData(sqlstr);
            return i;
        }

        public int updateSectionforPost(string section, string posttime)
        {
            string sqlstr = "UPDATE `bbs`.`section` SET `lastposttime` = '" + posttime + "' WHERE (`sectionname` = '" + section + "');";
            int i = updateSQLData(sqlstr);
            return i;
        }

        public DataSet getUserPostsList(string userid)
        {
            DataSet ds = new DataSet();
            string sqlstr = "select * from post where authorid='" + userid + "'";
            MySqlDataAdapter myda = new MySqlDataAdapter();
            this.Conn.Open();
            MySqlCommand Comm = new MySqlCommand(sqlstr, this.Conn);
            myda.SelectCommand = Comm;
            myda.Fill(ds, "userposts");
            this.Conn.Close();
            return ds;
        }

        public DataSet getUserCommentsList(string userid)
        {
            DataSet ds = new DataSet();
            string sqlstr = "select comment.postid, topic, floor, comment.text, comment.commenttime from comment, post where comment.authorid='" + userid + "' and comment.postid=post.postid";
            MySqlDataAdapter myda = new MySqlDataAdapter();
            this.Conn.Open();
            MySqlCommand Comm = new MySqlCommand(sqlstr, this.Conn);
            myda.SelectCommand = Comm;
            myda.Fill(ds, "usercomments");
            this.Conn.Close();
            return ds;
        }

        public int updateUsername(string userid, string newname)
        {
            string sqlstr = "UPDATE `bbs`.`users` SET `username` = '" + newname + "' WHERE (`userid` = '" + userid + "');";
            int i = updateSQLData(sqlstr);
            return i;
        }

        public int updateEmail(string userid, string newemail)
        {
            string sqlstr = "UPDATE `bbs`.`users` SET `email` = '" + newemail + "' WHERE (`userid` = '" + userid + "');";
            int i = updateSQLData(sqlstr);
            return i;
        }

        public int updateUserPassword(string userid, string newpassword)
        {
            string sqlstr = "UPDATE `bbs`.`users` SET `password` = '" + newpassword + "' WHERE (`userid` = '" + userid + "');";
            int i = updateSQLData(sqlstr);
            return i;
        }

        public int insertNewSection(string sectionname, string sectiondetail, string ownerid)
        {
            string sqlstr = "INSERT INTO `bbs`.`section` (`sectionname`, `sectiondetail`, `ownerid`) VALUES ('" + sectionname + "', '" + sectiondetail + "', '" + ownerid + "');";
            int i = updateSQLData(sqlstr);
            return i;
        }

        public int deletesectionfromDB(string section)
        {
            string sqlstr1 = "delete from comment where postid in (select postid from post where sectionname='" + section + "')";
            int i = updateSQLData(sqlstr1);
            if (i == 0)
                return 2;
            string sqlstr2 = "delete from post where sectionname='" + section + "'";
            i = updateSQLData(sqlstr2);
            if (i == 0)
                return 3;
            string sqlstr3 = "delete from section where sectionname='" + section + "'";
            i = updateSQLData(sqlstr3);
            if (i == 0)
                return 4;
            return 1;
        }

        public int updatesectionname(string section, string newname)
        {
            string sqlstr = "UPDATE `bbs`.`section` SET `sectionname` = '" + newname + "' WHERE (`sectionname` = '" + section + "');";
            int i = updateSQLData(sqlstr);
            return i;
        }

        public int updatesectiondetail(string section, string detail)
        {
            string sqlstr = "UPDATE `bbs`.`section` SET `sectiondetail` = '" + detail + "' WHERE (`sectionname` = '" + section + "');";
            int i = updateSQLData(sqlstr);
            return i;
        }

        public int updatesectionowner(string section, string ownerid)
        {
            string sqlstr = "UPDATE `bbs`.`section` SET `ownerid` = '" + ownerid + "' WHERE (`sectionname` = '" + section + "');";
            int i = updateSQLData(sqlstr);
            return i;
        }

        public int starPost(string postid)
        {
            string sqlstr = "select isstar from post where postid='" + postid + "'";
            string isstar = getSQLData(sqlstr);
            if (isstar == "")
                sqlstr = "UPDATE `bbs`.`post` SET `isstar` = '精' WHERE (`postid` = '" + postid + "');";
            else
                sqlstr = "UPDATE `bbs`.`post` SET `isstar` = '' WHERE (`postid` = '" + postid + "');";
            int i = updateSQLData(sqlstr);
            return i;
        }

        public int deletePost(string postid)
        {
            string sqlstr = "delete from comment where postid='" + postid + "'";
            int i = updateSQLData(sqlstr);
            if (i == 1)
            {
                sqlstr = "delete from post where postid='" + postid + "'";
                i = updateSQLData(sqlstr);
                if (i == 1)
                    return 1;
                else
                    return 2;
            }
            else
                return 3;
        }

        public DataSet getUsersList()
        {
            DataSet ds = new DataSet();
            string sqlstr = "select * from users";
            MySqlDataAdapter myda = new MySqlDataAdapter();
            this.Conn.Open();
            MySqlCommand Comm = new MySqlCommand(sqlstr, this.Conn);
            myda.SelectCommand = Comm;
            myda.Fill(ds, "userslist");
            this.Conn.Close();
            return ds;
        }

        public int updateAdmin(string userid)
        {
            string sqlstr = "select isAdmin from users where userid='" + userid + "'";
            string isstar = getSQLData(sqlstr);
            if (isstar == "0")
                isstar = "1";
            else
                isstar = "0";
            sqlstr = "UPDATE `bbs`.`users` SET `isAdmin` = '" + isstar + "' WHERE (`userid` = '" + userid + "');";
            int i = updateSQLData(sqlstr);
            return i;
        }

        public int deleteUser(string userid)
        {
            string sqlstr = "delete from comment where postid in (select postid from post where authorid='" + userid + "')";
            int i = updateSQLData(sqlstr);
            if (i == 1)
            {
                sqlstr = "delete from post where authorid='" + userid + "'";
                i = updateSQLData(sqlstr);
                if (i == 1)
                {
                    sqlstr = "UPDATE `bbs`.`comment` SET `authorid` = '000', `text` = '【评论用户已被删除】' WHERE (`authorid` = '" + userid + "');";
                    i = updateSQLData(sqlstr);
                    if (i == 1)
                    {
                        sqlstr = "delete from users where userid='" + userid + "'";
                        i = updateSQLData(sqlstr);
                        if (i == 1)
                            return 1;
                        else
                            return 2;
                    }
                    else
                        return 3;
                }
                else
                    return 4;
            }
            else
                return 5;
        }
    }
}