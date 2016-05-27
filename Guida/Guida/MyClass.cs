using System;

namespace Guida
{
    public class User
    {
        public string username, password;
        public User(String username,String password)
        {
            this.username = username;
            this.password = password;
        }
    }

	public class MyClass
	{
        User user;
        public MyClass ()
		{
            user = new User("Sean", "123");
		}

        public bool authenticate(string username, string password)
        {
            if(username.Equals(user.username, StringComparison.CurrentCultureIgnoreCase)  && password == user.password) {
                return true;
            }else
            {
                return false;
            }
        }
	}
}

