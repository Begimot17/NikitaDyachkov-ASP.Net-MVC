namespace Task_3new
{
    class User
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Pass { get; set; }
        public User()
        {
        }
        public User(string name, string email, string pass)
        {
            Name = name;
            Email = email;
            Pass = pass;
        }
        
    }
}
