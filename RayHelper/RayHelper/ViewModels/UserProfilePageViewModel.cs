using System;
using MvvmCross;
using RayHelper.Models;
using RayHelper.Models.Entities;

namespace RayHelper.ViewModels
{
    public class UserProfilePageViewModel : MainViewModel
    {
        private User AuthorizedUser => AuthorizationService.AuthorizedUser;
        
        protected override string ClassName => nameof(UserProfilePageViewModel);

        public bool IsUserAuthorized => AuthorizedUser != null;

        public string UserName => IsUserAuthorized ? $"{AuthorizedUser.FirstName} {AuthorizedUser.LastName}" : string.Empty;

        public string Login => IsUserAuthorized ? AuthorizedUser?.Email : string.Empty;
    }
}