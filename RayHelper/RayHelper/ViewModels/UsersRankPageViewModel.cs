using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using RayHelper.Models.Entities;

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
            LoadData();
        }

        private async void LoadData()
        {
            var users = await GetUsers();
            foreach (var user in users)
            {
                Users.Add(user);
            }
        }

        protected override string ClassName => nameof(UsersRankPageViewModel);

        private async Task<List<User>> GetUsers()
        {
            try
            {
                var users = await RayHelperClient.GetUsers().ConfigureAwait(false);
                foreach (var user in users.Where(u=>string.IsNullOrWhiteSpace(u.ImageSource)))
                {
                    user.ImageSource = DefaultImageSource;
                }
                users.Sort();
                return users;
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