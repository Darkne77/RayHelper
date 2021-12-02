using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using RayHelper.Models;

namespace RayHelper.ViewModels
{
    public class UsersRankPageViewModel : MainViewModel
    {
        private ObservableCollection<User> _users;
        public ObservableCollection<User> Users
        {
            get => _users;
            set => SetProperty(ref _users, value);
        }

        private const string DefaultImageSource = "https://thumb.cloud.mail.ru/weblink/thumb/xw1/ttUm/GJmToF8nj/defaultUser.png";
        
        public UsersRankPageViewModel()
        {
            Users = new ObservableCollection<User>();
            GetUsers();
        }

        protected override string ClassName => nameof(UsersRankPageViewModel);

        private async void GetUsers()
        {
            try
            {
                var users = await RayHelperClient.GetUsers().ConfigureAwait(false);
                
                users.Sort();
                
                foreach (var user in users.Where(u=>string.IsNullOrWhiteSpace(u.ImageSource)))
                {
                    user.ImageSource = DefaultImageSource;
                }
                
                foreach (var user in users)
                {
                    Users.Add(user);
                }
            }
            catch (Exception e)
            {
                Log.Add($"Class name: {ClassName}," +
                        $"Method: {nameof(GetUsers)}," +
                        $"Error: {e}");
            }
        }
    }
}