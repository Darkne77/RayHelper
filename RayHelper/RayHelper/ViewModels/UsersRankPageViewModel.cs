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

        public UsersRankPageViewModel()
        {
            var users = new List<User>()
                        {
                            new User()
                            {
                                FirstName = "Иван",
                                LastName = "Бругой",
                                Rank = 5
                            },
                            new User()
                            {
                                FirstName = "Аван",
                                LastName = "Другой",
                                Rank = 5
                            },
                            new User()
                            {
                                FirstName = "Иван",
                                LastName = "Другой",
                                Rank = 3
                            },
                            new User()
                            {
                                FirstName = "Иван",
                                LastName = "Иванов",
                                Rank = 10
                            }
                        };
            //TODO add image source if prop is empty
            //users.Where(u=>string.IsNullOrWhiteSpace(u.ImageSource))
            users.Sort();
            Users = new ObservableCollection<User>(users);

            //LoadData();
        }

        protected override string ClassName => nameof(UsersRankPageViewModel);

        private async void LoadData()
        {
            try
            {
                var users = await DbContext.GetUsers().ConfigureAwait(false);
                
                foreach (var user in users)
                {
                    Users.Add(user);
                }
            }
            catch (Exception e)
            {
                Log.Add($"Class name: {ClassName}," +
                        $"Method: {nameof(LoadData)}," +
                        $"Error: {e}");
            }
        }
    }
}