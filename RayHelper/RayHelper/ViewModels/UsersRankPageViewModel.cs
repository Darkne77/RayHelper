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
            users.Sort();
            Users = new ObservableCollection<User>(users);

            //LoadData();
        }

        private void LoadData()
        {
            //TODO
        }
    }
}